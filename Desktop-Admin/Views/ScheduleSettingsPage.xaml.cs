using System;
using System.Windows;
using System.Windows.Controls;
using Desktop_Admin.ViewModels;

namespace Desktop_Admin.Views;

public partial class ScheduleSettingsPage : Page
{
    private ScheduleVM _scheduleVM;
    public ScheduleSettingsPage()
    {
        InitializeComponent();
        _scheduleVM = new ScheduleVM();
        DataContext = _scheduleVM;
        SaveButton.IsEnabled = false;
    }
    
    public void ToMakeClassButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.GoBack();
        NavigationService?.Navigate(MainWindow.DictionaryPages["MakeClassPage"]);
    }
    
    public void ToReceiptsButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.GoBack();
        NavigationService?.Navigate(MainWindow.DictionaryPages["ReceiptsPage"]);
    }

    public void ToSheduleButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.GoBack();
        NavigationService?.Navigate(MainWindow.DictionaryPages["SchedulePage"]);
    }
    
    private void SelectCategoriesButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (Categories.Visibility == Visibility.Visible)
        {
            Categories.Visibility = Visibility.Hidden;
            if (_scheduleVM.SelectedClass != null)
                SaveButton.IsEnabled = true;
            else
                SaveButton.IsEnabled = false;
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

    private void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.GoBack();
    }
}