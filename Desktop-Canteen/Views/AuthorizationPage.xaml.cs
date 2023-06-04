using System.Collections.Generic;
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
        // if (e.Key == Key.Enter)
        // {
        //     EnterButtonClick(null, null);
        // } 
    }

    public void EnterButtonClick(object sender, RoutedEventArgs e)
    {
        //проверка логина и пароля
        this.Dispatcher.Invoke(() =>
        {
            EnterButtonText.Visibility = Visibility.Hidden;
            ProgressBar.Visibility = Visibility.Visible;
            if (_authorizationVm.ValidAuthorization())
            {
                MainWindow.DictionaryPages = new Dictionary<string, Page>()
                {
                    {"Menu", new MenuPage()},
                    {"Dishes", new AllDishesPage()},
                    {"Ingredients", new OrderingIngredientsPage()},
                    {"Schedule", new SchedulePage()},
                };
                ErrorAuthorizationBlock.Visibility = Visibility.Hidden;
                NavigationService?.Navigate( MainWindow.DictionaryPages["Menu"]);
            }
            else
            {
                EnterButtonText.Visibility = Visibility.Visible;
                ProgressBar.Visibility = Visibility.Hidden;
                ErrorAuthorizationBlock.Visibility = Visibility.Visible;
            }
        });
        
    }
}