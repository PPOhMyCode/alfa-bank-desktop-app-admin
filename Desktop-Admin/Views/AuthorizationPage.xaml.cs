using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Desktop_Admin.ViewModels;

namespace Desktop_Admin.Views;

public partial class AuthorizationPage : Page
{
    private AuthorizationVM _authorizationVm { get; set; }
    public AuthorizationPage()
    {
        InitializeComponent();
        _authorizationVm = new AuthorizationVM();
        DataContext  =_authorizationVm;
    }

    public void OnKeyDownHandler(object sender, KeyEventArgs e)
    {
        // if (e.Key == Key.Enter)
        // {
        //     EnterButtonClick(sender, null);
        // } 
    }
    
    public void EnterButtonClick(object sender, EventArgs e)
    {
        //проверка логина и пароля
        EnterButtonText.Visibility = Visibility.Hidden;
        ProgressBar.Visibility = Visibility.Visible;
        if (_authorizationVm.ValidAuthorization())
        {
            MainWindow.DictionaryPages = new Dictionary<string, Page>()
            {
                {"MakeClassPage", new MakeClassPage()},
                {"ReceiptsPage", new ReceiptsPage()},
                {"SchedulePage", new SchedulePage()},
                {"UploadUsersFilePage", new UploadUsersFilePage()},
            };
            ErrorAuthorizationBlock.Visibility = Visibility.Hidden;
            NavigationService?.Navigate(MainWindow.DictionaryPages["MakeClassPage"]);
        }
        else
        {
            EnterButtonText.Visibility = Visibility.Visible;
            ProgressBar.Visibility = Visibility.Hidden;
            ErrorAuthorizationBlock.Visibility = Visibility.Visible;
        }
    }
}