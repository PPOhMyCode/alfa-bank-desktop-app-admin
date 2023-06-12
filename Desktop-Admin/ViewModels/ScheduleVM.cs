using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Desktop_Admin.Models;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Admin.ViewModels;

public class ScheduleVM : BaseVM
{
    private string selectedItem;
    public string SelectedClass
    {
        get { return selectedItem; }
        set
        {
            selectedItem = value;
            OnPropertyChanged("SelectedClass");
        }
    }
    public ObservableCollection<ListViewItem> Classes { get; private set; }
    public ObservableCollection<TimingView> Schedule { get; private set; }
    public RelayCommand SelectCategoryCommand { protected set; get; }
    public RelayCommand PostTimingCommand { protected set; get; }
    public List<string> GradeNameArray { get; set; }

    public List<Grade> Grades { get; set; }
    public void LoadComboBoxData()
    {
        foreach (var grade in Grades)
        {
            GradeNameArray.Add(grade.Name);
        }
    }
    public ScheduleVM()
    {
        SelectCategoryCommand = new RelayCommand(SelectCategory);
        PostTimingCommand = new RelayCommand(PostItems);
        Classes = new ObservableCollection<ListViewItem>();
        GradeNameArray = new List<string>();
        Grades = ApiServer.Get<List<Grade>>("grades");
        LoadComboBoxData();
        foreach (var item in GradeNameArray)
            Classes.Add(new ListViewItem
            {
                Content = new CheckBox()
                {
                    Content = item,
                    IsChecked = false,
                    Background = Application.Current.TryFindResource("GreenBrush") as Brush,
                    Style = Application.Current.TryFindResource("MaterialDesignFilterChipCheckBox") as Style,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    HorizontalContentAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(0, 0, 0, 0),
                    Command = SelectCategoryCommand,
                    CommandParameter = item
                },
                MinHeight = 25,
                Margin = new Thickness(10, 5, 10, 0),
                Padding = new Thickness(0)
            });

        SelectedClass = GradeNameArray[0];
        // TODO: заменить потом на выгрузку расписания для SelectedClass
        Schedule = new ObservableCollection<TimingView>()
        {
            new TimingView() {Time = "Класс не выбран", TypeMeal = "Завтрак"},
            new TimingView() {Time = "Класс не выбран", TypeMeal = "Обед"},
            new TimingView() {Time = "Класс не выбран", TypeMeal = "Полдник"}
        };
       

    }

    private Dictionary<string, int> typesData = new Dictionary<string, int>()
    {
        {"Завтрак",1},
        {"Обед",2},
        {"Полдник",3}
    };

    private List<string> types = new List<string>()
    {
        "Завтрак",
        "Обед",
        "Полдник"
    };
    public void SelectCategory(object param)
    {
        var item = param as string;
        if (selectedItem == item)
        {
            selectedItem = null;
        }
        else
        {
            selectedItem = item;
        }

        var arr = ApiServer.Get<List<TimingGet>>("/timings/grade/" + param);
        Schedule.Clear();
        for(int i = 0;i<3;i++)
        {
            if(arr != null && arr.Count > i)
                Schedule.Add(new TimingView() {Time = arr[i].Time, TypeMeal = types[i]});
            else
                Schedule.Add(new TimingView() {Time = "Не питаются", TypeMeal = types[i]});
        }   
        foreach (var clas in GradeNameArray)
        {
            if (clas == item) continue;
            var e = (from x in Classes
                            where (x.Content as CheckBox).Content.Equals(clas)
                            select (x.Content as CheckBox)).FirstOrDefault();
            e.IsChecked = false;
        }
    }

    public void PostItems(object param)
    {
        foreach (var sView in Schedule)
        {
            var data = new Timing()
            {
                TypeMealId = typesData[sView.TypeMeal],
                Time = sView.Time,
                GradeId = Grades.FirstOrDefault(x => x.Name == selectedItem)!.GradeId
            };
            ApiServer.Post(data, "/timings");
        }
    }
}