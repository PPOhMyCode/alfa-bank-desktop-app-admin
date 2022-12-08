using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Desktop_Admin.Models;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Data;
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
    private ComboBoxItem selectedItem;
    public StackPanel ClassesPanel;
    public ObservableCollection<ComboBoxItem> Classes { get; private set; }
    public ObservableCollection<Children> ChildrenInSelectedClass { get; set; }

    public ComboBoxItem SelectedClass
    {
        get { return selectedItem; }
        set
        {
            selectedItem = value;
            OnPropertyChanged("SelectedClass");
            ChangeClassView();
        }
    }

    public string[] LoadComboBoxData()
    {
        string[] strArray =
        {
            "Все классы",
            "1A",
            "1Б",
            "1В",
            "2А",
            "2Б",
            "3А",
            "4А",
            "5А"
        };
        return strArray;
    }

    public MainViewModel()
    {
        Classes = new ObservableCollection<ComboBoxItem>();
        foreach (var item in LoadComboBoxData())
            Classes.Add(new ComboBoxItem { Content = item, MinHeight = 20 });

        SelectedClass = Classes[1];

        ChildrenInSelectedClass = new ObservableCollection<Children>()
        {
            new()
            {
                FirstName = "Екатерина",
                GradeID = 1,
                ChildrenId = 1,
                ParentID = 1,
                Patronymic = "Вячеславовна",
                SecondName = "Антонова"
            },
            new()
            {
                FirstName = "Мария",
                GradeID = 1,
                ChildrenId = 2,
                ParentID = 1,
                Patronymic = "Вячеславовна",
                SecondName = "Синицина"
            },
            new()
            {
                FirstName = "Анастасия",
                GradeID = 1,
                ChildrenId = 3,
                ParentID = 1,
                Patronymic = "Вячеславовна",
                SecondName = "Антонова"
            },
            new()
            {
                FirstName = "Иван",
                GradeID = 1,
                ChildrenId = 4,
                ParentID = 1,
                Patronymic = "Вячеславовна",
                SecondName = "Иванов"
            },
        };
    }

    private void ChangeClassView()
    {
        if (ClassesPanel == null) 
            return;
        ClassesPanel.Children.Clear();
        var dockPanel = new DockPanel()
        {
            Margin = new Thickness(40, 30, 30, 0)
        };
        
        var mainGrid = new Grid()
        {
            Margin = new Thickness(0, 0, 0, 20)
        };

        mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40) });
        mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(150) });
        mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        var className = new TextBlock()
        {
            Text = selectedItem.Content.ToString(),
            Style = Application.Current.TryFindResource("Medium23Text") as Style,
            Foreground = Application.Current.TryFindResource("DarkTextBrush") as Brush,
            VerticalAlignment = VerticalAlignment.Center
        };
        Grid.SetColumn(className, 0);
        Grid.SetRow(className, 0);
        mainGrid.Children.Add((className));
        
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
            Margin = new Thickness(0),
            Padding = new Thickness(0),
            Width = 365,
            Height = 140,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Center,
            Child = teacherGrid
        };
        Grid.SetColumn(teacher, 0);
        Grid.SetRow(teacher, 1);
        mainGrid.Children.Add((teacher));

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
        
        var teacherName = new TextBlock()
        {
            Text = "Омарова Ольга Михайловна", // заглушка
            Style = Application.Current.TryFindResource("RegularText") as Style,
            Foreground = Application.Current.TryFindResource("DarkTextBrush") as Brush,
            VerticalAlignment = VerticalAlignment.Bottom,
            TextWrapping = TextWrapping.Wrap,
            Margin = new Thickness(5, 0, 5, 0),
            FontSize = 16
        };
        Grid.SetColumn(teacherName, 1);
        Grid.SetRow(teacherName, 0);
        teacherGrid.Children.Add(teacherName);
        
        var classNameInCard = new TextBlock()
        {
            Text = selectedItem.Content.ToString(),
            Style = Application.Current.TryFindResource("RegularText") as Style,
            Foreground = Application.Current.TryFindResource("DarkTextBrush") as Brush,
            VerticalAlignment = VerticalAlignment.Bottom,
            Margin = new Thickness(5, 0, 5, 0),
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

        // string Xaml = "<DataTemplate>" +
        //                     "<Border Background=\"Transparent\"" +
        //                     "BorderThickness=\"2\"" +
        //                     "BorderBrush=\"{StaticResource LightGreenBrush}\"" +
        //                     "CornerRadius=\"15\"" +
        //                     "Margin=\"0, 0, 20, 10\"" +
        //                     "Padding=\"0\"" +
        //                     "Width=\"365\"" +
        //                     "Height=\"140\"" +
        //                     "HorizontalAlignment=\"Left\"" +
        //                     "VerticalAlignment=\"Center\">" +
        //                     "<Grid VerticalAlignment=\"Center\">" +
        //                     "<Grid.RowDefinitions>" +
        //                     "<RowDefinition Height=\"67\" />" +
        //                     "<RowDefinition Height=\"25\" />" +
        //                     "<RowDefinition Height=\"48\" />" +
        //                     "</Grid.RowDefinitions>" +
        //                     "<Grid.ColumnDefinitions>" +
        //                     "<ColumnDefinition Width=\"120\" />" +
        //                     "<ColumnDefinition Width=\"186\" />" +
        //                     "<ColumnDefinition Width=\"57\" />" +
        //                     "</Grid.ColumnDefinitions>" +
        //
        //                     "<Viewbox Grid.RowSpan=\"3\"" +
        //                     "VerticalAlignment=\"Center\"" +
        //                     "Margin=\"10, 0, 10, 0\">" +
        //                     "<Rectangle Fill=\"{StaticResource LightGrayBrush}\"" +
        //                     "Width=\"100\" Height=\"100\"" +
        //                     "RadiusX=\"10\" RadiusY=\"10\" />" +
        //                     "</Viewbox>" +
        //
        //                     "<TextBlock Grid.Row=\"0\" Grid.Column=\"1\" Style=\"{StaticResource RegularText}\"" +
        //                     "Foreground=\"{StaticResource DarkTextBrush}\"" +
        //                     "FontSize=\"16\" Margin=\"5, 0\" Text=\"{Binding FirstName}\" TextWrapping=\"Wrap\" VerticalAlignment=\"Bottom\" />" +
        //
        //                     "<TextBlock Grid.Row=\"1\" Grid.Column=\"1\" Style=\"{StaticResource RegularText}\" Foreground=\"{StaticResource DarkTextBrush}\"" +
        //                     "FontSize=\"14\" Margin=\"5, 0\" Text=\"{Binding GradeID}\" VerticalAlignment=\"Center\" />" +
        //
        //                     "<Rectangle Grid.Row=\"2\" Grid.Column=\"1\" Height=\"20\" Width=\"55\" VerticalAlignment=\"Top\" HorizontalAlignment=\"Left\"" +
        //                     "Fill=\"{StaticResource GreenTagBrush}\" RadiusX=\"5\" RadiusY=\"5\" />" +
        //                     "<TextBlock Grid.Row=\"2\" Grid.Column=\"1\" Style=\"{StaticResource RegularText}\"" +
        //                     "Foreground=\"{StaticResource DarkTextBrush}\" FontSize=\"10\" Height=\"20\"" +
        //                     "Width=\"53\" VerticalAlignment=\"Top\" HorizontalAlignment=\"Left\"" +
        //                     "Margin=\"9, 4\" Text=\"Ученик\" />" +
        //
        //                     "<Button Grid.Row=\"0\" Grid.Column=\"2\" Style=\"{StaticResource TransparentButton}\">" +
        //                     "<materialDesign:PackIcon Kind=\"PencilOutline\" Height=\"20\" Width=\"20\" Foreground=\"{StaticResource DarkTextBrush}\" />" +
        //                     "</Button>" +
        //
        //                     "</Grid>" +
        //                     "</Border>" +
        //                     "</DataTemplate>";
        //
        //
        // var sr = new MemoryStream(Encoding.ASCII.GetBytes(Xaml));
        // var pc = new ParserContext();
        // pc.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
        // pc.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
        //
        // DataTemplate datatemplate = (DataTemplate)XamlReader.Load(sr, pc);

        var itemsControl = new ItemsControl()
        {
            ItemsSource = ChildrenInSelectedClass
        };
        //itemsControl.ItemTemplate = datatemplate;
        Grid.SetColumn(itemsControl, 0);
        Grid.SetRow(itemsControl, 2);
        mainGrid.Children.Add(itemsControl);

        var wp = new WrapPanel() { Orientation = Orientation.Horizontal };
        itemsControl.ItemsPanel = (ItemsPanelTemplate)wp.DataContext;
        
        var childGrid = new Grid()
        {
            VerticalAlignment = VerticalAlignment.Center
        };
        childGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(67) });
        childGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(25) });
        childGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(48) });
        
        childGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(120) });
        childGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(186) });
        childGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(57) });
        
        var itemTemplate = new Border()
        {
            Background = Brushes.Transparent,
            BorderThickness = new Thickness(2),
            BorderBrush = Application.Current.TryFindResource("LightGreenBrush") as Brush,
            CornerRadius = new CornerRadius(15),
            Margin = new Thickness(0, 0, 15, 5),
            Padding = new Thickness(0),
            Width = 365,
            Height = 140,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Center,
            Child = childGrid
        };
        DataTemplate dt = new DataTemplate(typeof(ItemsControl));
        itemsControl.ItemTemplate = dt;

        //вместо фото аватарки пока просто прямоугольник
        var picture1 = new Rectangle()
        {
            Width = 100,
            Height = 100,
            Fill = Application.Current.TryFindResource("LightGrayBrush") as Brush,
            RadiusX = 10,
            RadiusY = 10
        };
        
        var avatar1 = new Viewbox()
        {
            VerticalAlignment = VerticalAlignment.Center,
            Margin = new Thickness(10, 0, 10, 0),
            Child = picture1
        };
        
        Grid.SetColumn(avatar1, 0);
        Grid.SetRow(avatar1, 0);
        Grid.SetRowSpan(avatar1, 3);
        childGrid.Children.Add(avatar1);
        
        var childName = new TextBlock()
        {
            Text = "FirstName", // заглушка
            Style = Application.Current.TryFindResource("RegularText") as Style,
            Foreground = Application.Current.TryFindResource("DarkTextBrush") as Brush,
            VerticalAlignment = VerticalAlignment.Bottom,
            TextWrapping = TextWrapping.Wrap,
            Margin = new Thickness(5, 0, 5, 0),
            FontSize = 16
        };
        Grid.SetColumn(childName, 1);
        Grid.SetRow(childName, 0);
        childGrid.Children.Add(childName);
        
        Grid.SetColumn(classNameInCard, 1);
        Grid.SetRow(classNameInCard, 1);
        childGrid.Children.Add(classNameInCard);
        
        var tagChild = new Rectangle()
        {
            Width = 55,
            Height = 20,
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Left,
            Fill = Application.Current.TryFindResource("GreenTagBrush") as Brush,
            RadiusX = 5,
            RadiusY = 5
        };
        Grid.SetColumn(tagChild, 1);
        Grid.SetRow(tagChild, 2);
        childGrid.Children.Add(tagChild);
        
        var tagTextChild = new TextBlock()
        {
            Text = "Ученик",
            Style = Application.Current.TryFindResource("RegularText") as Style,
            Foreground = Application.Current.TryFindResource("DarkTextBrush") as Brush,
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Left,
            Margin = new Thickness(9, 4, 9, 4),
            FontSize = 10,
            Height = 20,
            Width = 53
        };
        Grid.SetColumn(tagTextChild, 1);
        Grid.SetRow(tagTextChild, 2);
        childGrid.Children.Add(tagTextChild);
        
        Grid.SetColumn(pencil, 2);
        Grid.SetRow(pencil, 0);
        childGrid.Children.Add(pencil);
        
        
        dockPanel.Children.Add(mainGrid);
        DockPanel.SetDock(mainGrid, Dock.Top);
        
        ClassesPanel.Children.Add(dockPanel);
    }
}