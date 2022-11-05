using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WPFLibrary;
using WPFLibrary.JsonModels;

namespace Desktop_Canteen.Views;

public partial class AllDishesPage : Page
{
    
    public AllDishesPage()
    {
        List<Dish> items = new List<Dish>();
        items = ApiServer.Get<List<Dish>>("Dishes");
        Dishes.ItemsSource = items;
        InitializeComponent();
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