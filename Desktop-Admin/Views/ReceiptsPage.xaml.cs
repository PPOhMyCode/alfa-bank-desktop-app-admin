using System.Windows;
using System.Windows.Controls;
using Desktop_Admin.ViewModels;

namespace Desktop_Admin.Views;

public partial class ReceiptsPage : Page
{
    private ReceiptsVM _childrenVm;
    public ReceiptsPage()
    {
        InitializeComponent();
        _childrenVm = new ReceiptsVM();
        DataContext = _childrenVm;
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