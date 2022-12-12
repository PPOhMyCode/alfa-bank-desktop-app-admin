using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Desktop_Canteen.ViewModels;

namespace Desktop_Canteen.Views;

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
        if (e.Key == Key.Enter)
        {
            EnterButtonClick(null, null);
        } 
    }

    public void EnterButtonClick(object sender, RoutedEventArgs e)
    {
        //проверка логина и пароля
        if (_authorizationVm.ValidAuthorization())
        {
            ErrorAuthorizationBlock.Visibility = Visibility.Hidden;
            NavigationService?.Navigate(new MenuPage());
        }
        else
        {
            ErrorAuthorizationBlock.Visibility = Visibility.Visible;
        }
        
        //NavigationService?.Navigate(new MenuPage());
    }
}