using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Desktop_Canteen.ViewModels;
using WPFLibrary;
using WPFLibrary.JsonModels;

namespace Desktop_Canteen.Views;

public partial class AllDishesPage : Page
{
    private AllDishesVM _allDishesVm;
    public AllDishesPage()
    {
        InitializeComponent();
        _allDishesVm = new AllDishesVM()
        {
            Plug = Plug,
            ProgressBar = ProgressBar
        };
        DataContext = _allDishesVm;
        _allDishesVm.Refresh();
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