using System.Windows;
using System.Windows.Controls;
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

    public void EnterButtonClick(object sender, RoutedEventArgs e)
    {
        //проверка логина и пароля
        if (_authorizationVm.ValidAuthorization())
        {
            ErrorAuthorizationBlock.Visibility = Visibility.Hidden;
            NavigationService?.Navigate(new MakeClassPage());
        }
        else
        {
            ErrorAuthorizationBlock.Visibility = Visibility.Visible;
        }
        
        //NavigationService?.Navigate(new MenuPage());
    }
}