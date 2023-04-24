using System.Windows;
using System.Windows.Controls;

namespace Desktop_Admin.Views;

public partial class UploadUsersFilePage : Page
{
    public UploadUsersFilePage()
    {
        InitializeComponent();
    }
    
    public void ToMakeClassButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new MakeClassPage());
    }
    
    public void ToReceiptsButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new ReceiptsPage());
    }
    
    public void ToScheduleButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new SchedulePage());
    }
}