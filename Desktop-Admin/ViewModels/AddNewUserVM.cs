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

public class AddNewUserVM : BaseVM
{
    public ObservableCollection<ListViewItem> Categories { get; set; }
    public ObservableCollection<ListViewItem> Classes { get; private set; }
    public ObservableCollection<ListViewItem> Children { get; private set; }
    private List<string> _categoriesNames;
    private string _selectedCategory;
    public StackPanel PlugAdditionalInformation;
    public StackPanel NoNeedAdditionalInformation;
    public StackPanel AdditionalInformationAboutChildren;
    public StackPanel AdditionalInformationAboutClass;
    public DockPanel CategoriesDockPanel;
    public Expander AddInfoExpander;
    public Brush CategoryBrush { get; set; }
    public string SelectedCategory
    {
        get { return _selectedCategory; }
        set
        {
            _selectedCategory = value;
            OnPropertyChanged("SelectedCategory");
        }
    }
    public List<string> GradeNameArray { get; set; }
    public List<Grade> Grades { get; set; }
    public RelayCommand SelectCategoryCommand { protected set; get; }
    public void LoadComboBoxData()
    {
        GradeNameArray.Add("Все классы");
        foreach (var grade in Grades.OrderBy(x => x.Name))
        {
            GradeNameArray.Add(grade.Name);
        }
    }
    
    public AddNewUserVM()
    {
        _selectedCategory = "Выберите категорию";
        CategoryBrush = new SolidColorBrush(Color.FromRgb(157, 156, 156));
        SelectCategoryCommand = new RelayCommand(SelectCategory);
        Categories = new ObservableCollection<ListViewItem>();
        _categoriesNames = new List<string>()
        {
            "Работник столовой",
            "Администратор",
            "Учитель",
            "Родитель"
        };
        foreach (var item in _categoriesNames)
            Categories.Add(new ListViewItem
            {
                Content = new Button()
                {
                    Content = item,
                    Style = Application.Current.TryFindResource("DefaultTransparentButton") as Style,
                    HorizontalContentAlignment = HorizontalAlignment.Left,
                    FontFamily = Application.Current.TryFindResource("Montserrat-Regular") as FontFamily,
                    FontSize = 19,
                    Command = SelectCategoryCommand,
                    CommandParameter = item
                },
                MinHeight = 25,
                Padding = new Thickness(0)
            });
        
        GradeNameArray = new List<string>();
        Grades = ApiServer.Get<List<Grade>>("grades");
        LoadComboBoxData();
        Classes = new ObservableCollection<ListViewItem>();
        foreach (var item in GradeNameArray)
            Classes.Add(new ListViewItem
            {
                Content = new Button()
                {
                    Content = item,
                    Style = Application.Current.TryFindResource("DefaultTransparentButton") as Style,
                    HorizontalContentAlignment = HorizontalAlignment.Left,
                    FontFamily = Application.Current.TryFindResource("Montserrat-Regular") as FontFamily,
                    FontSize = 19,
                    Command = SelectCategoryCommand,
                    CommandParameter = item
                },
                MinHeight = 25,
                Padding = new Thickness(0)
            });
    }

    public void SelectCategory(object param)
    {
        _selectedCategory = param as string;
        CategoriesDockPanel.Visibility = Visibility.Hidden;
        CategoryBrush = Application.Current.TryFindResource("DarkGrayBrush") as Brush;
        OnPropertyChanged("CategoryBrush");
        OnPropertyChanged("SelectedCategory");
        if (SelectedCategory == _categoriesNames[0] || SelectedCategory == _categoriesNames[1])
        {
            HideAllAdditionalInfo();
            NoNeedAdditionalInformation.Visibility = Visibility.Visible;
        }
        else if (SelectedCategory == _categoriesNames[2])
        {
            HideAllAdditionalInfo();
            AdditionalInformationAboutClass.Visibility = Visibility.Visible;
            AddInfoExpander.IsExpanded = true;
        }
        else
        {
            HideAllAdditionalInfo();
            AdditionalInformationAboutChildren.Visibility = Visibility.Visible;
            AddInfoExpander.IsExpanded = true;
        }
    }

    public void HideAllAdditionalInfo()
    {
        PlugAdditionalInformation.Visibility = Visibility.Hidden;
        NoNeedAdditionalInformation.Visibility = Visibility.Hidden;
        AdditionalInformationAboutChildren.Visibility = Visibility.Hidden;
        AdditionalInformationAboutClass.Visibility = Visibility.Hidden;
        
    }
    
}