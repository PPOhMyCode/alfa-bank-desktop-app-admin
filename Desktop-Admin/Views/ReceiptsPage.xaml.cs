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
        _childrenVm = new ReceiptsVM()
        {
            ClassesPanel = ClassesStackPanel,
            NoSelectedClassesTextBlock = NoSelectedClassesPlug
        };
        DataContext = _childrenVm;
        _childrenVm.CheckPlug();
    }

    public void ToMakeClassButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new MakeClassPage());
    }
    
    public void ToScheduleButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new SchedulePage());
    }
    
    public void ToRefusalsButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new FoodRefusalsPage());
    }
    
    public void ToRecalculationButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new RecalculationRequestsPage());
    }
    
    private void SelectCategoriesButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (Categories.Visibility == Visibility.Visible)
        {
            Categories.Visibility = Visibility.Hidden;
        }
        else
        {
            Categories.Visibility = Visibility.Visible;
        }
    }
    
    private void DoneButton_OnClick(object sender, RoutedEventArgs e)
    {
        Categories.Visibility = Visibility.Hidden;
    }

    private void SelectYearButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (Years.Visibility == Visibility.Visible)
        {
            Years.Visibility = Visibility.Hidden;
        }
        else
        {
            Years.Visibility = Visibility.Visible;
        }
    }
    
    private void DoneButton1_OnClick(object sender, RoutedEventArgs e)
    {
        Years.Visibility = Visibility.Hidden;
    }
    
    private void SelectMonthButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (Month.Visibility == Visibility.Visible)
        {
            Month.Visibility = Visibility.Hidden;
        }
        else
        {
            Month.Visibility = Visibility.Visible;
        }
    }
    
    private void DoneButton2_OnClick(object sender, RoutedEventArgs e)
    {
        Month.Visibility = Visibility.Hidden;
    }
}