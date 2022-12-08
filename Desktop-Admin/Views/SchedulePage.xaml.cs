﻿using System.Windows;
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
        NavigationService?.Navigate(new MakeClassPage());
    }
    
    public void ToReceiptsButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new ReceiptsPage());
    }
}