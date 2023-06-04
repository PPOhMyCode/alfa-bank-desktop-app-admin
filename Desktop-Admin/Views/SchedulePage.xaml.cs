using System.Windows;
using System.Windows.Controls;
using Desktop_Admin.ViewModels;

namespace Desktop_Admin.Views;

public partial class SchedulePage : Page
{
    private ScheduleVM _scheduleVM;
    public SchedulePage()
    {
        InitializeComponent();
        _scheduleVM = new ScheduleVM();
        DataContext = _scheduleVM;
    }
    
    public void ToMakeClassButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(MainWindow.DictionaryPages["MakeClassPage"]);
    }
    
    public void ToReceiptsButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(MainWindow.DictionaryPages["ReceiptsPage"]);
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

    private void ChangeScheduleButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new ScheduleSettingsPage());
    }
}