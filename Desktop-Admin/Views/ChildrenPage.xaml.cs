using System.Windows;
using System.Windows.Controls;

namespace Desktop_Admin.Views;

public partial class ChildrenPage : Page
{
    public ChildrenPage()
    {
        InitializeComponent();
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