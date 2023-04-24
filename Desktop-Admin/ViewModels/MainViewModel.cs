using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Desktop_Admin.Models;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Admin.ViewModels;

public class MainViewModel : BaseVM, INotifyPropertyChanged
{
    private ObservableCollection<string> SelectedItems { get; set; }
    public StackPanel ClassesPanel;
    private bool isCheck;

    public TextBlock NoSelectedClassesTextBlock;
    public ObservableCollection<ListViewItem> Classes { get; private set; }
    public ObservableCollection<Children> ChildrenInSelectedClass { get; set; }
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

    public MainViewModel()
    {
        isCheck = false;
        SelectedItems = new ObservableCollection<string>();
        SelectCategoryCommand = new RelayCommand(SelectCategory);
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

        ChildrenInSelectedClass = new ObservableCollection<Children>();
    }

    public void SelectCategory(object param)
    {
        var item = param as string;
        if (item == "Все классы")
        {
            SelectedItems.Clear();
            foreach (var clas in GradeNameArray)
            {
                if (clas == "Все классы" ) continue;
                SelectedItems.Add(clas);
                var e = (from x in Classes
                    where (x.Content as CheckBox).Content.Equals(clas)
                        select (x.Content as CheckBox)).FirstOrDefault();
                e.IsChecked = false;
            }
        }
        else
        {
            if (SelectedItems.Contains(item))
            {
                SelectedItems.Remove(item);
            }
            else
            {
                SelectedItems.Add(item);
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
        foreach (var selectedItem in SelectedItems)
        {
            // добавить выгрузку класса/категории по названию, т.е. по selectedItem
            // выгружать учителя и список детей
            var dockPanel = new DockPanel()
            {
                Margin = new Thickness(50, 25, 30, 0)
            };

            var mainGrid = new Grid()
            {
                Margin = new Thickness(0, 0, 0, 20)
            };

            mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40) });
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(175) });
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            var editButtonGrid = new Grid()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 335
            };
            editButtonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(40)});
            editButtonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            
            var pen = new Button()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                Style = Application.Current.TryFindResource("TransparentButton") as Style,
                Content = new PackIcon
                {
                    Kind = PackIconKind.PencilOutline,
                    Height = 20,
                    Width = 20,
                    Foreground = Application.Current.TryFindResource("DarkGrayBrush") as Brush
                }
            };
            Grid.SetColumn(pen, 0);
            Grid.SetRow(pen, 0);
            editButtonGrid.Children.Add(pen);
            
            var editText = new TextBlock()
            {
                Text = "Редактировать список класса",
                Style = Application.Current.TryFindResource("Medium23Text") as Style,
                FontSize = 17,
                Foreground = Application.Current.TryFindResource("DarkGrayBrush") as Brush,
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(editText, 1);
            Grid.SetRow(editText, 0);
            editButtonGrid.Children.Add(editText);
            
            var editClassButton = new Button()
            {
                Width = 335,
                Height = 40,
                HorizontalAlignment = HorizontalAlignment.Left,
                Style = Application.Current.TryFindResource("LightBaseButton") as Style,
                Content = editButtonGrid
            };
            Grid.SetColumn(editClassButton, 0);
            Grid.SetRow(editClassButton, 1);
            mainGrid.Children.Add(editClassButton);

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

            var teacherGrid = new Grid()
            {
                VerticalAlignment = VerticalAlignment.Center
            };
            teacherGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(67) });
            teacherGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(25) });
            teacherGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(48) });

            teacherGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(120) });
            teacherGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(186) });
            teacherGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(57) });
            
            var teacher = new Border()
            {
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(2),
                BorderBrush = Application.Current.TryFindResource("DarkGreenBrush") as Brush,
                CornerRadius = new CornerRadius(15),
                Margin = new Thickness(0, 0, 0, 30),
                Padding = new Thickness(0),
                Width = 365,
                Height = 140,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Child = teacherGrid
            };
            Grid.SetColumn(teacher, 0);
            Grid.SetRow(teacher, 2);
            mainGrid.Children.Add(teacher);

            //вместо фото аватарки пока просто прямоугольник
            var picture = new Rectangle()
            {
                Width = 100,
                Height = 100,
                Fill = Application.Current.TryFindResource("LightGrayBrush") as Brush,
                RadiusX = 10,
                RadiusY = 10
            };

            var avatar = new Viewbox()
            {
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10, 0, 10, 0),
                Child = picture
            };

            Grid.SetColumn(avatar, 0);
            Grid.SetRow(avatar, 0);
            Grid.SetRowSpan(avatar, 3);
            teacherGrid.Children.Add(avatar);
            var teacherUser = ApiServer.Get<User>("users/" + Grades
                .FirstOrDefault(x => x.Name == selectedItem).TeacherID); 
            var teacherName = new TextBlock()
            {
                Text = teacherUser.SecondName+ " " + teacherUser.FirstName + " " + teacherUser.Patronymic, 
                Style = Application.Current.TryFindResource("RegularText") as Style,
                Foreground = Application.Current.TryFindResource("DarkTextBrush") as Brush,
                VerticalAlignment = VerticalAlignment.Top,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(5, 18, 5, 0),
                FontSize = 15
            };
            Grid.SetColumn(teacherName, 1);
            Grid.SetRow(teacherName, 0);
            teacherGrid.Children.Add(teacherName);

            var classNameInCard = new TextBlock()
            {
                Text = selectedItem,
                Style = Application.Current.TryFindResource("RegularText") as Style,
                Foreground = Application.Current.TryFindResource("DarkTextBrush") as Brush,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(5, 0, 5, 10),
                FontSize = 14
            };
            Grid.SetColumn(classNameInCard, 1);
            Grid.SetRow(classNameInCard, 1);
            teacherGrid.Children.Add(classNameInCard);

            var tag = new Rectangle()
            {
                Width = 145,
                Height = 20,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Fill = Application.Current.TryFindResource("LightYellowBrush") as Brush,
                RadiusX = 5,
                RadiusY = 5
            };
            Grid.SetColumn(tag, 1);
            Grid.SetRow(tag, 2);
            teacherGrid.Children.Add(tag);

            var tagText = new TextBlock()
            {
                Text = "Классный руководитель",
                Style = Application.Current.TryFindResource("RegularText") as Style,
                Foreground = Application.Current.TryFindResource("DarkTextBrush") as Brush,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(9, 4, 9, 4),
                FontSize = 10,
                Height = 20,
                Width = 145
            };
            Grid.SetColumn(tagText, 1);
            Grid.SetRow(tagText, 2);
            teacherGrid.Children.Add(tagText);

            var pencil = new Button()
            {
                Style = Application.Current.TryFindResource("TransparentButton") as Style,
                Content = new PackIcon
                {
                    Kind = PackIconKind.PencilOutline,
                    Height = 20,
                    Width = 20,
                    Foreground = Application.Current.TryFindResource("DarkTextBrush") as Brush
                }
            };
            Grid.SetColumn(pencil, 2);
            Grid.SetRow(pencil, 0);
            teacherGrid.Children.Add(pencil);

            var xaml = "<DataTemplate>" +
                       "<Border Background=\"Transparent\" " +
                       "BorderThickness=\"2\" " +
                       "BorderBrush=\"{StaticResource LightGreenBrush}\" " +
                       "CornerRadius=\"15\" " +
                       "Margin=\"0, 0, 45, 30\" " +
                       "Padding=\"0\" " +
                       "Width=\"365\" " +
                       "Height=\"140\" " +
                       "HorizontalAlignment=\"Left\" " +
                       "VerticalAlignment=\"Center\"> " +
                       "<Grid VerticalAlignment=\"Center\"> " +
                       "<Grid.RowDefinitions> " +
                       "<RowDefinition Height=\"67\" /> " +
                       "<RowDefinition Height=\"25\" /> " +
                       "<RowDefinition Height=\"48\" /> " +
                       "</Grid.RowDefinitions> " +
                       "<Grid.ColumnDefinitions> " +
                       "<ColumnDefinition Width=\"120\" /> " +
                       "<ColumnDefinition Width=\"186\" /> " +
                       "<ColumnDefinition Width=\"57\" /> " +
                       "</Grid.ColumnDefinitions> " +

                       "<Viewbox Grid.RowSpan=\"3\" " +
                       "VerticalAlignment=\"Center\" " +
                       "Margin=\"10, 0, 10, 0\"> " +
                       "<Rectangle Fill=\"{StaticResource LightGrayBrush}\" " +
                       "Width=\"100\" Height=\"100\" " +
                       "RadiusX=\"10\" RadiusY=\"10\" /> " +
                       "</Viewbox> " +

                       "<TextBlock Grid.Row=\"0\" Grid.Column=\"1\" Style=\"{StaticResource RegularText}\" " +
                       "Foreground=\"{StaticResource DarkTextBrush}\" " +
                       "FontSize=\"15\" Margin=\"5, 18, 5, 0\" TextWrapping=\"Wrap\" VerticalAlignment=\"Top\" > " +
                       "<TextBlock.Text> <MultiBinding StringFormat=\"{}{0} {1} {2}\"> <Binding Path=\"FirstName\"/> <Binding Path=\"SecondName\"/> <Binding Path=\"Patronymic\"/> </MultiBinding> </TextBlock.Text> " +
                       "</TextBlock> " +

                       "<TextBlock Grid.Row=\"1\" Grid.Column=\"1\" Style=\"{StaticResource RegularText}\" Foreground=\"{StaticResource DarkTextBrush}\" " +
                       "FontSize=\"14\" Margin=\"5, 0, 5, 10\" Text=\"" + selectedItem + "\" VerticalAlignment=\"Center\" /> " +

                       "<Rectangle Grid.Row=\"2\" Grid.Column=\"1\" Height=\"20\" Width=\"55\" VerticalAlignment=\"Top\" HorizontalAlignment=\"Left\" " +
                       "Fill=\"{StaticResource GreenTagBrush}\" RadiusX=\"5\" RadiusY=\"5\" /> " +
                       "<TextBlock Grid.Row=\"2\" Grid.Column=\"1\" Style=\"{StaticResource RegularText}\" " +
                       "Foreground=\"{StaticResource DarkTextBrush}\" FontSize=\"10\" Height=\"20\" " +
                       "Width=\"53\" VerticalAlignment=\"Top\" HorizontalAlignment=\"Left\" " +
                       $"Margin=\"9, 4\" " +
                       "Text=\"Ученик\" /> " +

                       "<Button Grid.Row=\"0\" Grid.Column=\"2\" Style=\"{StaticResource TransparentButton}\"> " +
                       "<materialDesign:PackIcon Kind=\"PencilOutline\" Height=\"20\" Width=\"20\" Foreground=\"{StaticResource DarkTextBrush}\" /> " +
                       "</Button> " +

                       "</Grid> " +
                       "</Border> " +
                       "</DataTemplate> ";

            var panelTempXaml = "<ItemsPanelTemplate> <WrapPanel Orientation=\"Horizontal\" /> </ItemsPanelTemplate>";

            var sr1 = new MemoryStream(Encoding.ASCII.GetBytes(panelTempXaml));
            var sr = new MemoryStream(Encoding.UTF8.GetBytes(xaml));
            var pc = new ParserContext();
            pc.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            pc.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
            pc.XmlnsDictionary.Add("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            pc.XmlnsDictionary.Add("d", "http://schemas.microsoft.com/expression/blend/2008");
            pc.XmlnsDictionary.Add("viewModels", "clr-namespace:Desktop_Admin.ViewModels");
            pc.XmlnsDictionary.Add("materialDesign", "http://materialdesigninxaml.net/winfx/xaml/themes");

            var dataTemplate = (DataTemplate)XamlReader.Load(sr, pc);
            var panelTemplate = (ItemsPanelTemplate)XamlReader.Load(sr1, pc);
            var a = Grades.Where(x => x.Name == selectedItem);
            var children = ApiServer.Get<List<Children>>("grades/" +
                                                         Grades
                                                             .FirstOrDefault(x => x.Name == selectedItem).GradeId + "/childrens");
            var itemsControl = new ItemsControl()
            {
                ItemsSource = new ObservableCollection<Children>(children)
            };

            itemsControl.ItemTemplate = dataTemplate;
            itemsControl.ItemsPanel = panelTemplate;

            Grid.SetColumn(itemsControl, 0);
            Grid.SetRow(itemsControl, 3);
            mainGrid.Children.Add(itemsControl);

            dockPanel.Children.Add(mainGrid);
            DockPanel.SetDock(mainGrid, Dock.Top);

            ClassesPanel.Children.Add(dockPanel);
        }
    }
}