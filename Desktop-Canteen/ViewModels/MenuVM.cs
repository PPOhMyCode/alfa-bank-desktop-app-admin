using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Desktop_Admin.Models;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Canteen.ViewModels;

public class MenuVM : BaseVM
{
    public int TypeMeal { get; set; }
    public DateTime Date { get; set; }
    public List<DateTime> Days { get; set; }
    private ObservableCollection<MenuView> Menu { get; set; }
    public string TodayDate { get; set; }
    public string TodayMonth { get; set; }
    private ObservableCollection<Dish> AllDishes { get; set; }
    public ObservableCollection<Dish> DishInMenu { get; set; }
    public RelayCommand SelectDayCommand { protected set; get; }
    public RelayCommand SelectTypeCommand { protected set; get; }
    
    public MenuVM()
    {
        Days = new List<DateTime>();
        var today = (int)DateTime.Today.DayOfWeek;
        Date = DateTime.Today;
        for (int i = 0; i < 5; i++)
            Days.Add(DateTime.Today.AddDays(i-today+1));
        TodayDate = DateTime.Now.ToString("dd.MM");
        TodayMonth = DateTime.Now.ToString("MMMM");
        //AllDishes = new ObservableCollection<Dish>(ApiServer.Get<List<Dish>>("dishes"));
        DishInMenu = new ObservableCollection<Dish>();
        Menu = new ObservableCollection<MenuView>();
        GetMenu();
        SelectDayCommand = new RelayCommand(SelectDay);
        SelectTypeCommand = new RelayCommand(SelectType);
    }

    public void SelectDay(object param)
    {
        Date = (DateTime)param;
        GetMenu();
    }
    
    public void SelectType(object param)
    {
        TypeMeal = int.Parse((string)param);
        GetMenu();
    }
    
    public void GetMenu(object param = null)
    {
        try
        {
            Menu.Clear();
            DishInMenu.Clear();
            var b = Date.ToString("MM-dd-yyyy");
            var menuDate = ApiServer.Get<List<Menu>>("menus");
            if (menuDate != null)
            {
                foreach (var a in menuDate.Where(x=>x.TypeMealId==TypeMeal))
                {
                    var dish = ApiServer.Get<Dish>("dishes/" + a.DishId);
                    DishInMenu.Add(dish);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}