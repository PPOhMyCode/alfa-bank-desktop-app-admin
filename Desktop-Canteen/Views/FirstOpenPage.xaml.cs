using System;
using System.Windows;
using System.Windows.Controls;

namespace Desktop_Canteen.Views;

public partial class FirstOpenPage : Page
{
    public int selectedPeriod;
    public FirstOpenPage()
    {
        InitializeComponent();
        selectedPeriod = 2;
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
        NavigationService?.Navigate(new MakeMenuPage(selectedPeriod));
        
    }
    
    public void PeriodButtonClick(object sender, RoutedEventArgs e)
    {
        Period1.Style = Application.Current.TryFindResource("TypeMealButton") as Style;
        Period2.Style = Application.Current.TryFindResource("TypeMealButton") as Style;
        Period3.Style = Application.Current.TryFindResource("TypeMealButton") as Style;
        Period4.Style = Application.Current.TryFindResource("TypeMealButton") as Style;
        var selectedPeriodButton = sender as Button;
        selectedPeriodButton.Style = Application.Current.TryFindResource("SelectedTypeMealButton") as Style;
        selectedPeriod = Convert.ToInt32(selectedPeriodButton.CommandParameter);
    }
}