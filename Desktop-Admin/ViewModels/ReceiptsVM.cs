using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Desktop_Admin.Models;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Admin.ViewModels;

public class ReceiptsVM : BaseVM
{
    public ObservableCollection<ReceiptsView> Receipts { get; set; }
    public ReceiptCard _selectedCard;

    public ReceiptCard SelectedCard
    {
        get { return _selectedCard; }
        set
        {
            _selectedCard = value;
            OnPropertyChanged("SelectedCard");
        }
    }
    private ObservableCollection<string> SelectedClasses { get; set; }
    private bool isCheck;
    public TextBlock NoSelectedClassesTextBlock;
    public DateTime Date { get; set; }
    public ObservableCollection<ListViewItem> Classes { get; private set; }
    public ObservableCollection<ListViewItem> Years { get; private set; }
    public ObservableCollection<ListViewItem> Months { get; private set; }
    public RelayCommand SelectCategoryCommand { protected set; get; }
    public RelayCommand SelectYearCommand { protected set; get; }
    public RelayCommand SelectMonthCommand { protected set; get; }
    public List<string> GradeNameArray { get; set; }

    public List<Grade> Grades { get; set; }
    public void LoadComboBoxData()
    {
        GradeNameArray.Add("Все классы");
        foreach (var grade in Grades)
        {
            GradeNameArray.Add(grade.Name);
        }
    }
    
    public string SelectedYear { get; set; }
    public string SelectedMonth { get; set; }
    
    public ObservableCollection<int> YearsList { get; set; }
    public ObservableCollection<string> MonthsList { get; set; }
    public ReceiptsVM()
    {
        Receipts = new ObservableCollection<ReceiptsView>();
        isCheck = false;
        SelectedClasses = new ObservableCollection<string>();
        SelectCategoryCommand = new RelayCommand(SelectClass);
        SelectYearCommand = new RelayCommand(SelectYear);
        SelectMonthCommand = new RelayCommand(SelectMonth);
        YearsList = new ObservableCollection<int>(ApiServer.Get<List<int>>("/receipts/years"));
        MonthsList = new ObservableCollection<string>();
        var today = (int)DateTime.Today.DayOfWeek;
        Date = DateTime.Today;
        GradeNameArray = new List<string>();
        Grades = ApiServer.Get<List<Grade>>("grades");
        LoadComboBoxData();
        Classes = new ObservableCollection<ListViewItem>();
        foreach (var item in GradeNameArray)
            Classes.Add(new ListViewItem
            {
                Content = new CheckBox()
                {
                    Content = item,
                    IsChecked = isCheck,
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
        SelectedYear = "";
        SelectedMonth = "";
        SetYears();
        SetMonths();
    }

    private void SetYears()
    {
        Years = new ObservableCollection<ListViewItem>();
        foreach (var item in YearsList)
            Years.Add(new ListViewItem
            {
                Content = new CheckBox()
                {
                    Content = item,
                    IsChecked = isCheck,
                    Background = Application.Current.TryFindResource("GreenBrush") as Brush,
                    Style = Application.Current.TryFindResource("MaterialDesignFilterChipCheckBox") as Style,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    HorizontalContentAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(0, 0, 0, 0),
                    Command = SelectYearCommand,
                    CommandParameter = item
                },
                MinHeight = 25,
                Margin = new Thickness(10, 5, 10, 0),
                Padding = new Thickness(0)
            });
    }

    private void SetMonths()
    {
        Months = new ObservableCollection<ListViewItem>();
        foreach (var item in MonthsList)
            Months.Add(new ListViewItem
            {
                Content = new CheckBox()
                {
                    Content = item,
                    IsChecked = isCheck,
                    Background = Application.Current.TryFindResource("GreenBrush") as Brush,
                    Style = Application.Current.TryFindResource("MaterialDesignFilterChipCheckBox") as Style,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    HorizontalContentAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(0, 0, 0, 0),
                    Command = SelectMonthCommand,
                    CommandParameter = item
                },
                MinHeight = 25,
                Margin = new Thickness(10, 5, 10, 0),
                Padding = new Thickness(0)
            });
    }

    public void SelectClass(object param)
    {
        var item = param as string;
        if (item == "Все классы")
        {
            SelectedClasses.Clear();
            foreach (var clas in GradeNameArray)
            {
                if (clas == "Все классы" ) continue;
                SelectedClasses.Add(clas);
                var e = (from x in Classes
                    where (x.Content as CheckBox).Content.Equals(clas)
                    select (x.Content as CheckBox)).FirstOrDefault();
                e.IsChecked = false;
            }
        }
        else
        {
            if (SelectedClasses.Contains(item))
            {
                SelectedClasses.Remove(item);
            }
            else
            {
                SelectedClasses.Add(item);
            }
        }
        ChangeClassView();
        CheckPlug();
    }
    
    public void SelectYear(object param)
    {
        var item = param.ToString();
        SelectedYear = item;
        var a = ApiServer.Get<List<List<string>>>("/receipts/years/" + item);
        MonthsList = new ObservableCollection<string>(a.Select(x=>x[1]));
        SetMonths();
        ChangeClassView();
        CheckPlug();
    }
    
    public void SelectMonth(object param)
    {
        var item = param.ToString();
        SelectedMonth = item;
        ChangeClassView();
        CheckPlug();
    }
    
    public void CheckPlug()
    {
        try
        {
            // if (Receipts != null && Receipts.Count != 0)
            // {
            //     NoSelectedClassesTextBlock.Visibility = Visibility.Hidden;
            // }
            // else
            // {
            //     NoSelectedClassesTextBlock.Visibility = Visibility.Visible;
            // }
        }
        catch (Exception e)
        {
            
        }
    }

    public Dictionary<string, int> DictionaryMonth = new Dictionary<string, int>()
    {
        {"Январь", 1},
        {"Февраль", 2},
        {"Март", 3},
        {"Апрель", 4},
        {"Май", 5},
        {"Июнь", 6},
        {"Июль", 7},
        {"Август", 8},
        {"Сентябрь", 9},
        {"Октябрь", 10},
        {"Ноябрь", 11},
        {"Декабрь",12}
    };
    private async void ChangeClassView()
    {
        Receipts.Clear();
        if (SelectedYear != "" && SelectedMonth != "" && SelectedClasses.Count > 0)
        {
            foreach (var selectedItem in SelectedClasses)
            {
                var gradeId = Grades.FirstOrDefault(x => x.Name == selectedItem).GradeId;
                var childrens = await Task.Run(() => 
                    ApiServer.Get<List<Children>>("/grades/" + gradeId + "/childrens"));
                if (childrens.Count > 0)
                {
                    var childrenCards = new List<ReceiptCard>();
                    foreach (var children in childrens)
                    {
                        var receipt = ApiServer.Get<ReceiptCardInput>("/receipts/years/" + SelectedYear + "/month/" +
                                                                      DictionaryMonth[SelectedMonth] + "/children/" + children.ChildrenId);
                        if(receipt != null)
                            childrenCards.Add(new ReceiptCard(receipt));
                    }
                    Receipts.Add(new ReceiptsView(){ReceiptCards = childrenCards, Grade = selectedItem});
                }
            }    
        }
    }
}