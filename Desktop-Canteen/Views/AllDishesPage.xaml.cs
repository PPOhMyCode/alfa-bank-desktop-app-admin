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

    public void ToAddNewDishButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new AddNewDishPage());
    }
}