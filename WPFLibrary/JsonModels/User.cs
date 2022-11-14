﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace WPFLibrary.JsonModels;

public class User: BaseModel
{
    public string Login { set; get; }
    public string Password { set; get; }
    public  string FirstName { set; get; }
    public  string SecondName { set; get; }
    public string Patronymic { set; get; }
    public int RoleId { set; get; }
}

public class UserAutorization
{
    public string Login { set; get; }
    public string Password { set; get; }
}

public class UserDataView: BaseModel
{
    public string Login { set; get; }
    public string Password { set; get; }
    public  string FirstName { set; get; }
    public  string SecondName { set; get; }
    public string Patronymic { set; get; }
    public Role Role { set; get; }
}

public class UserView:BaseModel
{
    public  string FirstName { set; get; }
    public  string SecondName { set; get; }
    public string Patronymic { set; get; }
    public int RoleId { set; get; }
}