using System.Windows;
using System.Windows.Controls;
using Desktop_Canteen.ViewModels;

namespace Desktop_Canteen.Views;

public partial class SchedulePage : Page
{
    private ScheduleVM _scheduleVm;
    public SchedulePage()
    {
        InitializeComponent();
        _scheduleVm = new ScheduleVM()
        {
            NoDataPlugTextBlock = NoDataPlug,
            TableGrid = TableGrid
        };
        DataContext = _scheduleVm;
        _scheduleVm.CheckPlug();
    }
    
    public void ToOrderingIngredientsButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(MainWindow.DictionaryPages["Ingredients"]);
    }
            
    public void ToAllDishesButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(MainWindow.DictionaryPages["Dishes"]);
    }
    public void ToMenuButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(MainWindow.DictionaryPages["Menu"]);
    }

    public void ChangeStyleCircleButton(object sender, RoutedEventArgs e)
    {
        DefaultStyleToAllCircleButton();
        var isSelected = (sender as Button).Style.Equals(Application.Current.TryFindResource("SelectedCircleButton") as Style);
        if (isSelected)
        {
            (sender as Button).Style = Application.Current.TryFindResource("CircleButton") as Style;
        }
        else
        {
            (sender as Button).Style = Application.Current.TryFindResource("SelectedCircleButton") as Style;
        }
    }

    private void DefaultStyleToAllCircleButton()
    {
        Monday.Style = Application.Current.TryFindResource("CircleButton") as Style;
        Tuesday.Style = Application.Current.TryFindResource("CircleButton") as Style;
        Wednesday.Style = Application.Current.TryFindResource("CircleButton") as Style;
        Thursday.Style = Application.Current.TryFindResource("CircleButton") as Style;
        Friday.Style = Application.Current.TryFindResource("CircleButton") as Style;
    }
}