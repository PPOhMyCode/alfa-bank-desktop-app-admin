using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
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
    
    public ObservableCollection<int> YearsList { get; set; }
    public ObservableCollection<string> MonthsList { get; set; }
    public ReceiptsVM()
    {
        Receipts = new ObservableCollection<ReceiptsView>()
        {
            new ReceiptsView()
            {
                Grade = "1А",
                ReceiptCards = new List<ReceiptCard>()
                {
                    new ReceiptCard()
                    {
                        FirstName = "Елизавета",
                        SecondName = "Пик",
                        Grade = "1А",
                        Dishes = new List<string>()
                        {
                            "Творожная запеканка", "Черный чай", "Творожная запеканка", "Черный чай",
                            "Творожная запеканка", "Черный чай", "Творожная запеканка"
                        },
                        Price = "653 р"
                    },
                    new ReceiptCard()
                    {
                        FirstName = "Елизавета",
                        SecondName = "Пик",
                        Grade = "1А",
                        Dishes = new List<string>()
                        {
                            "Творожная запеканка", "Черный чай", "Творожная запеканка", "Черный чай",
                            "Творожная запеканка", "Черный чай", "Творожная запеканка"
                        },
                        Price = "653 р"
                    },
                    new ReceiptCard()
                    {
                        FirstName = "Елизавета",
                        SecondName = "Пик",
                        Grade = "1А",
                        Dishes = new List<string>()
                        {
                            "Творожная запеканка", "Черный чай", "Творожная запеканка", "Черный чай",
                            "Творожная запеканка", "Черный чай", "Творожная запеканка"
                        },
                        Price = "653 р"
                    },
                    new ReceiptCard()
                    {
                        FirstName = "Елизавета",
                        SecondName = "Пик",
                        Grade = "1А",
                        Dishes = new List<string>()
                        {
                            "Творожная запеканка", "Черный чай", "Творожная запеканка", "Черный чай",
                            "Творожная запеканка", "Черный чай", "Творожная запеканка"
                        },
                        Price = "653 р"
                    }
                }
            },
            new ReceiptsView()
            {
                Grade = "5Б",
                ReceiptCards = new List<ReceiptCard>()
                {
                    new ReceiptCard()
                    {
                        FirstName = "Антон",
                        SecondName = "Беляев",
                        Grade = "5Б",
                        Dishes = new List<string>()
                        {
                            "Творожная запеканка", "Черный чай", "Творожная запеканка", "Черный чай",
                            "Творожная запеканка", "Черный чай", "Творожная запеканка"
                        },
                        Price = "603 р"
                    },
                    new ReceiptCard()
                    {
                        FirstName = "Антон",
                        SecondName = "Беляев",
                        Grade = "5Б",
                        Dishes = new List<string>()
                        {
                            "Творожная запеканка", "Черный чай", "Творожная запеканка", "Черный чай",
                            "Творожная запеканка", "Черный чай", "Творожная запеканка"
                        },
                        Price = "603 р"
                    },
                    new ReceiptCard()
                    {
                        FirstName = "Антон",
                        SecondName = "Беляев",
                        Grade = "5Б",
                        Dishes = new List<string>()
                        {
                            "Творожная запеканка", "Черный чай", "Творожная запеканка", "Черный чай",
                            "Творожная запеканка", "Черный чай", "Творожная запеканка"
                        },
                        Price = "603 р"
                    },
                    new ReceiptCard()
                    {
                        FirstName = "Антон",
                        SecondName = "Беляев",
                        Grade = "5Б",
                        Dishes = new List<string>()
                        {
                            "Творожная запеканка", "Черный чай", "Творожная запеканка", "Черный чай",
                            "Творожная запеканка", "Черный чай", "Творожная запеканка"
                        },
                        Price = "603 р"
                    }
                }
            }
        };
        isCheck = false;
        SelectedClasses = new ObservableCollection<string>();
        SelectCategoryCommand = new RelayCommand(SelectClass);
        YearsList = new ObservableCollection<int>(ApiServer.Get<List<int>>("/receipts/years"));
        MonthsList = new ObservableCollection<string>()
        {
            "Месяц",
            "Месяц",
            "Месяц",
            "Месяц",
            "Месяц",
            "Месяц"
        };
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
                    Command = SelectCategoryCommand,
                    CommandParameter = item
                },
                MinHeight = 25,
                Margin = new Thickness(10, 5, 10, 0),
                Padding = new Thickness(0)
            });
        
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
                    Command = SelectCategoryCommand,
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
    
    public void CheckPlug()
    {
        try
        {
            if (Receipts != null && Receipts.Count != 0)
            {
                NoSelectedClassesTextBlock.Visibility = Visibility.Hidden;
            }
            else
            {
                NoSelectedClassesTextBlock.Visibility = Visibility.Visible;
            }
        }
        catch (Exception e)
        {
            
        }
    }

    private void ChangeClassView()
    {
        Receipts.Clear();
        foreach (var selectedItem in SelectedClasses)
        {
            //TODO добавлять в Receipts новый элемент ReceiptsView для selectedItem (выбранного класса)
            
        }
    }
}