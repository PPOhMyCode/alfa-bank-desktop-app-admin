using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Desktop_Canteen.ViewModels;

namespace Desktop_Canteen.Views;

public partial class AddNewDishPage : Page
{
    public AddNewDishPage()
    {
        
        InitializeComponent();
        DataContext  = new AddNewDishVM();
    }
    
    public void ToAllDishesButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new AllDishesPage());
    }
    
    public void ToOrderingIngredientsButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new OrderingIngredientsPage());
    }
            
    public void ToMenuButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new MenuPage());
    }
    public void ToScheduleButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new SchedulePage());
    }
            
    public void ToChildrensButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new ChildrensPage());
    }
}