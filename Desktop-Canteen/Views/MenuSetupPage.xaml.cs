using System.Windows;
using System.Windows.Controls;

namespace Desktop_Canteen.Views;

public partial class MenuSetup : Page
{
    public MenuSetup()
    {
        InitializeComponent();
    }
    
    public void ToAllDishesButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new AllDishesPage());
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
    
    public void ToOrderingIngredientsButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new OrderingIngredientsPage());
    }
    
    public void Save(object sender, RoutedEventArgs e)
    {
        //save
        
        NavigationService?.Navigate(new MakeMenuPage());
    }
    
}