using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Desktop_Admin.Models;
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
    public ObservableCollection<string> Timings { get; private set; }
    public ObservableCollection<Children> ChildrenInSelectedClass { get; set; }
    public RelayCommand SelectCategoryCommand { protected set; get; }
    public string[] LoadComboBoxData()
    {
        string[] strArray =
        {
            "1A",
            "1Б",
            "1В",
            "2А",
            "2Б",
            "3А",
            "4А",
            "5А",
            "5Б"
        };
        return strArray;
    }

    public ScheduleVM()
    {
        SelectCategoryCommand = new RelayCommand(SelectCategory);
        Classes = new ObservableCollection<ListViewItem>();
        foreach (var item in LoadComboBoxData())
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

        SelectedClass = LoadComboBoxData()[0];
        // TODO: заменить потом на выгрузку расписания для SelectedClass
        Timings = new ObservableCollection<string>()
        {
            "9:30",
            "10:30",
            "14:30"
        };
        
    }
    
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
        foreach (var clas in LoadComboBoxData())
        {
            if (clas == item) continue;
            var e = (from x in Classes
                            where (x.Content as CheckBox).Content.Equals(clas)
                            select (x.Content as CheckBox)).FirstOrDefault();
            e.IsChecked = false;
        }
        
        //ChangeClassView();
        //CheckPlug();
    }
}