﻿using System;
using System.Net;
using System.Windows.Controls;
using System.Windows.Navigation;
using Desktop_Admin.Views;
using Newtonsoft.Json;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Admin.ViewModels;

public class AuthorizationVM : BaseVM
{
    public UserAutorization UserAutorization { get; set; }
    private string autorizationError { get; set; }
    
    public string AutorizationError
    {
        get { return autorizationError; }
        set
        {
            autorizationError = value;
            OnPropertyChanged("AutorizationError");
        }
    }

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
        var response = ApiServer.Autorization(UserAutorization);
        //TODO: Переделать по нормальному 
        try
        {
            var str = response.Content;
            if (str == "System Error" || str == "Login or Password is incorrect")
                AutorizationError = "Null Data";
            return !(str == "System Error" || str == "Login or Password is incorrect");
        }
        catch (Exception e)
        {
            AutorizationError = response.Content;
            return false;
        }
    }
}