using System.Windows;
using System.Windows.Controls;
using Desktop_Admin.ViewModels;

namespace Desktop_Admin.Views;

public partial class FoodRefusalsPage : Page
{
    private FoodRefusalsVM _refusalsVm;
    public FoodRefusalsPage()
    {
        InitializeComponent();
        _refusalsVm = new FoodRefusalsVM();
        DataContext = _refusalsVm;
    }
    
    public void ToMakeClassButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new MakeClassPage());
    }
    
    public void ToScheduleButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new SchedulePage());
    }
}