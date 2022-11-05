using System.Windows;
using System.Windows.Controls;

namespace Desktop_Canteen.Views;

public partial class ChildrensPage : Page
{
    public ChildrensPage()
    {
        InitializeComponent();
    }
    
    public void ToOrderingIngredientsButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new OrderingIngredientsPage());
    }
            
    public void ToAllDishesButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new AllDishesPage());
    }
    public void ToScheduleButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new SchedulePage());
    }
            
    public void ToMenuButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new MenuPage());
    }
}