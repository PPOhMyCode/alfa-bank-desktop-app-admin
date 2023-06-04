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
        NavigationService?.Navigate(new MakeMenuPage());
    }
    
    public void PeriodButtonClick(object sender, RoutedEventArgs e)
    {
        Period1.Style = Application.Current.TryFindResource("TypeMealButton") as Style;
        Period2.Style = Application.Current.TryFindResource("TypeMealButton") as Style;
        Period3.Style = Application.Current.TryFindResource("TypeMealButton") as Style;
        Period4.Style = Application.Current.TryFindResource("TypeMealButton") as Style;
        var selectedPeriodButton = sender as Button;
        selectedPeriodButton.Style = Application.Current.TryFindResource("SelectedTypeMealButton") as Style;
    }
}