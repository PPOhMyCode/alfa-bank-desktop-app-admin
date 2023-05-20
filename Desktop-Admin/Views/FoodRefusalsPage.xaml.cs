using System.Windows;
using System.Windows.Controls;
using Desktop_Admin.ViewModels;
using WPFLibrary.JsonModels;

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

    public void MoreButtonClick(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        MoreWindow.Visibility = Visibility.Visible;
        _refusalsVm._selectedCard = (RefusalChildrenCard) button.DataContext;
        _refusalsVm.CauseMoreWindow = _refusalsVm._selectedCard.Cause;
        _refusalsVm.ChildrenNameMoreWindow = _refusalsVm._selectedCard.ChildrenName;
    }
    
    public void CloseWindowButtonClick(object sender, RoutedEventArgs e)
    {
        MoreWindow.Visibility = Visibility.Hidden;
    }
}