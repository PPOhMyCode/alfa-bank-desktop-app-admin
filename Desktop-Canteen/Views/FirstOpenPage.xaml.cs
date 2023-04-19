using System.Windows;
using System.Windows.Controls;

namespace Desktop_Canteen.Views;

public partial class FirstOpenPage : Page
{
    public FirstOpenPage()
    {
        InitializeComponent();
    }
    
    public void StartButtonClick(object sender, RoutedEventArgs e)
    {
        PlugPanel.Visibility = Visibility.Hidden;
        InstructionsGrid.Visibility = Visibility.Visible;
        DatesPanel.Visibility = Visibility.Visible;
        PeriodPanel.Visibility = Visibility.Visible;
    }
    
    public void SaveButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new MenuPage());
    }
}