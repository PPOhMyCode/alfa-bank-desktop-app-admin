using System.Windows;
using System.Windows.Controls;
using Desktop_Admin.ViewModels;
using WPFLibrary.JsonModels;

namespace Desktop_Admin.Views;

public partial class ReceiptsPage : Page
{
    private ReceiptsVM _vm;
    public ReceiptsPage()
    {
        InitializeComponent();
        _vm = new ReceiptsVM()
        {
            // ClassesPanel = ClassesStackPanel,
            NoSelectedClassesTextBlock = NoSelectedClassesPlug
        };
        DataContext = _vm;
        _vm.CheckPlug();
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
    
    public void MoreButtonClick(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        MoreWindow.Visibility = Visibility.Visible;
        _vm.SelectedCard = (ReceiptCard) button.DataContext;
    }
    
    public void CloseWindowButtonClick(object sender, RoutedEventArgs e)
    {
        MoreWindow.Visibility = Visibility.Hidden;
    }
}