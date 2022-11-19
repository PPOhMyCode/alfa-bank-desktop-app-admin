using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Desktop_Admin.Models;
using DevExpress.Mvvm.Native;
using RestSharp;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Canteen.ViewModels;

public class MenuVM: BaseVM
{
    public DateTime Date;
    public int TypeMeal;
    private ObservableCollection<Dish> AllDishes { get; set; }
    private ObservableCollection<MenuView> Menu { get; set; }
    
    public ObservableCollection<Dish> DishInMenu { get; set; }
    public ObservableCollection<Dish> DishCanAddToMenu { get; set; }
    public RelayCommand GetMenuDateCommand { protected set; get; }
    public RelayCommand AddMenuDateCommand { protected set; get; }

    public MenuVM()
    {
        AllDishes = new ObservableCollection<Dish>(ApiServer.Get<List<Dish>>("Dish"));
        Menu = new ObservableCollection<MenuView>();
        DishInMenu = new ObservableCollection<Dish>();
        DishCanAddToMenu = new ObservableCollection<Dish>();
        GetMenuDateCommand = new RelayCommand(GetMenu);
        AddMenuDateCommand = new RelayCommand(AddDishToMenu);
        Date = DateTime.Today.Date;
        GetMenu();
    }
    
    /// <summary>
    /// Add Dish in Menu for day and Type
    /// </summary>
    /// <param name="param">DishId</param>
    public void AddDishToMenu(object param)
    {
        var menu = new MenuInput()
        {
            Date = (DateTime) Date,
            DishId = (int) param,
            TypeMealId = (int) TypeMeal
        };
        var responce = ApiServer.Post(menu, "Menu");
        GetMenu();
    }
    
    /// <summary>
    /// Delete Dish from Menu for day and Type
    /// </summary>
    /// <param name="param">DishId</param>
    public void DeleteDishToMenu(object param)
    {
    }
    
    /// <summary>
    /// Get menu for Date
    /// </summary>
    /// <param name="param">null</param>
    public void GetMenu(object param = null)
    {
        Menu.Clear();
        DishInMenu.Clear();
        var b = Date.ToString("MM-dd-yyyy");
        var menuDate = ApiServer.Get<List<Menu>>("Menu/Date/"+Date.ToString("MM-dd-yyyy"));
        //var  = new ObservableCollection<Menu>(ApiServer.Get<List<Menu>>("Menu"));
        if (menuDate != null)
        {
            foreach (var a in menuDate)
            {
                var dish = ApiServer.Get<Dish>("Dish/" + a.DishId);
                Menu.Add(new MenuView()
                {
                    Date = a.Date,
                    Dish = dish,
                    TypeMeal = ApiServer.Get<TypeMeal>("TypeMeal/"+a.TypeMealId),
                    Id = a.Id
                });
                DishInMenu.Add(dish);
            }
        }
        DishCanAddToMenu = AllDishes.Where(x=>!DishInMenu.Contains(x)).ToObservableCollection();
    }
}