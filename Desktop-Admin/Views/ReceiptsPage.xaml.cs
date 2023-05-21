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
        NavigationService?.Navigate(MainWindow.DictionaryPages["MakeClassPage"]);
    }
    
    public void ToScheduleButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(MainWindow.DictionaryPages["SchedulePage"]);
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
}