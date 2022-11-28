using System.Windows;
using System.Windows.Controls;
using Desktop_Canteen.ViewModels;

namespace Desktop_Canteen.Views;

public partial class SchedulePage : Page
{
    public SchedulePage()
    {
        InitializeComponent();
        DataContext = new ScheduleVM();
    }
    
    public void ToOrderingIngredientsButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new OrderingIngredientsPage());
    }
            
    public void ToAllDishesButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new AllDishesPage());
    }
    public void ToMenuButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new MenuPage());
    }
            
    public void ToChildrensButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new ChildrensPage());
    }
    
    public void ChangeStyleCircleButton(object sender, RoutedEventArgs e)
    {
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
}