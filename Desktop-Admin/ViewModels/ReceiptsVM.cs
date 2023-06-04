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
    private ObservableCollection<string> SelectedClasses { get; set; }
    public StackPanel ClassesPanel;
    private bool isCheck;
    public TextBlock NoSelectedClassesTextBlock;
    public DateTime Date { get; set; }
    public ObservableCollection<ListViewItem> Classes { get; private set; }
    public ObservableCollection<ListViewItem> Years { get; private set; }
    public ObservableCollection<ListViewItem> Months { get; private set; }
    public ObservableCollection<ChildrenView> ChildrenInSelectedClass { get; set; }
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
        //list всех классов
        //var grades = ApiServer.Get<List<Grade>>("grades");
        
        //var childrens = ApiServer.Get<List<Children>>("grades/1/childrens");
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
        
        ChildrenInSelectedClass = new ObservableCollection<ChildrenView>()
        {
            new()
            {
                FirstName = "Иван",
                Patronymic = "Иванов",
                SecondName = "Иванов",
                Grade = new GradeView(){Name = "5Б"}
            },
            new()
            {
                FirstName = "Аслан",
                Patronymic = "Масуд оглы",
                SecondName = "Рзаев",
                Grade = new GradeView(){Name = "5Б"}
            },
            new()
            {
                FirstName = "Мария",
                Patronymic = "Александровна",
                SecondName = "Синицина",
                Grade = new GradeView(){Name = "5Б"}
            }
        };
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
            if (ClassesPanel != null && ClassesPanel.Children.Count != 0)
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
        if (ClassesPanel == null)
            return;
        ClassesPanel.Children.Clear();
        foreach (var selectedItem in SelectedClasses)
        {
            var dockPanel = new DockPanel()
            {
                Margin = new Thickness(40, 25, 30, 0)
            };

            var mainGrid = new Grid()
            {
                Margin = new Thickness(0, 0, 0, 20)
            };

            mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40) });
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            var className = new TextBlock()
            {
                Text = selectedItem + ":",
                Style = Application.Current.TryFindResource("Medium23Text") as Style,
                Foreground = Application.Current.TryFindResource("DarkTextBrush") as Brush,
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(className, 0);
            Grid.SetRow(className, 0);
            mainGrid.Children.Add(className);

            var dataTemplateXaml = "<DataTemplate> " +
                                   "<Grid> " +
                                   "<Border Background=\"Transparent\" " +
                                   "BorderThickness=\"2\" " +
                                   "BorderBrush=\"{StaticResource LightGreenBrush}\" " +
                                   "CornerRadius=\"15\" " +
                                   "Margin=\"0, 0, 45, 30\" " +
                                   "Padding=\"0\" " +
                                   "Width=\"365\" " +
                                   "Height=\"180\" " +
                                   "HorizontalAlignment=\"Left\" " +
                                   "VerticalAlignment=\"Center\"> " +
                                   "<Grid VerticalAlignment=\"Center\"> " +
                                   "<Grid.RowDefinitions> " +
                                   "<RowDefinition Height=\"44\" /> " +
                                   "<RowDefinition Height=\"17\" /> " +
                                   "<RowDefinition Height=\"63\" /> " +
                                   "<RowDefinition Height=\"59\" /> " +
                                   "</Grid.RowDefinitions> " +
                                   "<Grid.ColumnDefinitions> " +
                                   "<ColumnDefinition Width=\"120\" /> " +
                                   "<ColumnDefinition Width=\"186\" /> " +
                                   "<ColumnDefinition Width=\"57\" /> " +
                                   "</Grid.ColumnDefinitions> " +

                                   "<Viewbox Grid.RowSpan=\"3\" VerticalAlignment=\"Bottom\" Margin=\"10, 0, 10, 0\"> " +
                                   "<Ellipse Fill=\"{StaticResource LightGrayBrush}\" Width=\"84\" Height=\"84\"/> " +
                                   "</Viewbox> " +

                                   "<TextBlock Grid.Row=\"0\" Grid.Column=\"1\" Style=\"{StaticResource RegularText}\" " +
                                   "Foreground=\"{StaticResource DarkGreenTextBrush}\" FontSize=\"16\" " +
                                   "Margin=\"5, 0, 5, 5\" TextWrapping=\"Wrap\" VerticalAlignment=\"Bottom\" > " +
                                   "<TextBlock.Text> <MultiBinding StringFormat=\"{}{0} {1}\"> <Binding Path=\"SecondName\"/> <Binding Path=\"FirstName\"/> </MultiBinding> </TextBlock.Text> " +
                                   "</TextBlock> " +

                                   "<TextBlock Grid.Row=\"1\" Grid.Column=\"1\" Style=\"{StaticResource RegularText}\" Foreground=\"{StaticResource DarkTextBrush}\" " +
                                   "FontSize=\"14\" Margin=\"5, 0\" Text=\"{Binding Grade.Name}\" VerticalAlignment=\"Center\" /> " +
                                   "<StackPanel Grid.Row=\"3\" Grid.Column=\"0\" Orientation=\"Horizontal\" Margin=\"10, 0, 10, 10\" " +
                                   "VerticalAlignment=\"Center\" HorizontalAlignment=\"Center\"> " +
                                   "<TextBlock Style=\"{StaticResource RegularText}\" Foreground=\"{StaticResource DarkTextBrush}\" FontSize=\"28\" Text=\"600\" /> " +
                                   "<TextBlock Style=\"{StaticResource RegularText}\" Foreground=\"{StaticResource DarkTextBrush}\" FontSize=\"28\" Margin=\"10,0,0,0\" Text=\"р\" /> " +
                                   "</StackPanel> " +

                                   "<Button Grid.Row=\"0\" Grid.Column=\"2\" Style=\"{StaticResource TransparentButton}\" VerticalAlignment=\"Bottom\"> " +
                                   "<materialDesign:PackIcon Kind=\"PencilOutline\" Height=\"20\" Width=\"20\" Foreground=\"{StaticResource DarkGreenTextBrush}\" /> " +
                                   "</Button> </Grid> </Border> </Grid> </DataTemplate>";
            
            var panelTempXaml = "<ItemsPanelTemplate> <WrapPanel Orientation=\"Horizontal\" /> </ItemsPanelTemplate>";

            var sr1 = new MemoryStream(Encoding.ASCII.GetBytes(panelTempXaml));
            var sr = new MemoryStream(Encoding.UTF8.GetBytes(dataTemplateXaml));
            var pc = new ParserContext();
            pc.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            pc.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
            pc.XmlnsDictionary.Add("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            pc.XmlnsDictionary.Add("d", "http://schemas.microsoft.com/expression/blend/2008");
            pc.XmlnsDictionary.Add("viewModels", "clr-namespace:Desktop_Admin.ViewModels");
            pc.XmlnsDictionary.Add("materialDesign", "http://materialdesigninxaml.net/winfx/xaml/themes");

            var dataTemplate = (DataTemplate)XamlReader.Load(sr, pc);
            var panelTemplate = (ItemsPanelTemplate)XamlReader.Load(sr1, pc);

            var itemsControl = new ItemsControl()
            {
                ItemsSource = ChildrenInSelectedClass
            };

            itemsControl.ItemTemplate = dataTemplate;
            itemsControl.ItemsPanel = panelTemplate;

            Grid.SetColumn(itemsControl, 0);
            Grid.SetRow(itemsControl, 1);
            mainGrid.Children.Add(itemsControl);
            
            dockPanel.Children.Add(mainGrid);
            DockPanel.SetDock(mainGrid, Dock.Top);

            ClassesPanel.Children.Add(dockPanel);
        }
    }
}