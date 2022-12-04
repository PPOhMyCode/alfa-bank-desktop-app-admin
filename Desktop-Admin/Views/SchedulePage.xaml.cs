using System.Windows;
using System.Windows.Controls;

namespace Desktop_Admin.Views;

public partial class SchedulePage : Page
{
    public SchedulePage()
    {
        InitializeComponent();
    }
    
    public void ToMakeClassButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new MakeClassPage());
    }
    
    public void ToChildrenClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new ChildrenPage());
    }
}