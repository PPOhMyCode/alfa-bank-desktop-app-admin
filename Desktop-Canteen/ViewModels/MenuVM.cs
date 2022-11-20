using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Canteen.ViewModels;

public class MenuVM : BaseVM
{
    public String TodayDate { get; set; }
    public String TodayMonth { get; set; }
    private ObservableCollection<Dish> AllDishes { get; set; }
    public ObservableCollection<Dish> DishInMenu { get; set; }

    public MenuVM()
    {
        TodayDate = DateTime.Now.ToString("dd.MM");
        TodayMonth = DateTime.Now.ToString("MMMM");
        AllDishes = new ObservableCollection<Dish>(ApiServer.Get<List<Dish>>("Dish"));
        DishInMenu = new ObservableCollection<Dish>();
    }
}