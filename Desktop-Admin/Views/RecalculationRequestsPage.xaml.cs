using System.Windows;
using System.Windows.Controls;
using Desktop_Admin.ViewModels;
using WPFLibrary.JsonModels;

namespace Desktop_Admin.Views;

public partial class RecalculationRequestsPage : Page
{
    private RecalculationRequestsVM _vm;
    public RecalculationRequestsPage()
    {
        InitializeComponent();
        _vm = new RecalculationRequestsVM()
        {
            NoDataPlug = NoDataPlug
        };
        DataContext = _vm;
        _vm.CheckPlug();
    }
    
    public void ToMakeClassButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new MakeClassPage());
    }
    
    public void ToScheduleButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new SchedulePage());
    }
    
    public void ToReceiptsButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new ReceiptsPage());
    }
    
    public void MoreButtonClick(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        MoreWindow.Visibility = Visibility.Visible;
        _vm.SelectedCard = (RecalculationRequestCard) button.DataContext;
    }
    
    public void CloseWindowButtonClick(object sender, RoutedEventArgs e)
    {
        MoreWindow.Visibility = Visibility.Hidden;
    }
}