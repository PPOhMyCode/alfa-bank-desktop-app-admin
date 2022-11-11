using System.Windows;
using System.Windows.Controls;

namespace Desktop_Canteen.Views;

public partial class AuthorizationPage : Page
{
    public AuthorizationPage()
    {
        InitializeComponent();
    }

    public void EnterButtonClick(object sender, RoutedEventArgs e)
    {
        //проверка логина и пароля
        NavigationService?.Navigate(new MenuPage());
    }
}