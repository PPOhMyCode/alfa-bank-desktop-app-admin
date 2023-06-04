using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace WPFLibrary.JsonModels;

public class User
{
    public int UserId { set; get; }
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

public class UserDataView
{
    public string UserId { set; get; }
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

public class UserPost:BaseModel
{
    public  string FirstName { set; get; }
    public  string SecondName { set; get; }
    public string Patronymic { set; get; }
    public string Role { set; get; }
}