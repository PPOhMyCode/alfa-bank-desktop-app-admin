using System;
using System.Net;
using System.Windows.Controls;
using System.Windows.Navigation;
using Desktop_Canteen.Views;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Canteen.ViewModels;

public class AuthorizationVM : BaseVM
{
    public UserAutorization UserAutorization { get; set; }

    #region UserData

    public string Login
    {
        get { return UserAutorization.Login; }
        set
        {
            UserAutorization.Login = value;
            OnPropertyChanged("Login");
        }
    }
    
    public string Password
    {
        get { return UserAutorization.Password; }
        set
        {
            UserAutorization.Password = value;
            OnPropertyChanged("Password");
        }
    }

    #endregion
    public AuthorizationVM()
    {
        UserAutorization = new UserAutorization();
    }

    public bool ValidAuthorization()
    {
        var response = ApiServer.Post(UserAutorization, "Autorization");
        return response.StatusCode == HttpStatusCode.OK;
    }
}