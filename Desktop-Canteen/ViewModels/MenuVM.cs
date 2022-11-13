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
    private ObservableCollection<Dish> Dishes { get; set; }
    private ObservableCollection<MenuView> Menu { get; set; }
    
    public ObservableCollection<Dish> DishInMenu { get; set; }
    public ObservableCollection<Dish> DishCanAddToMenu { get; set; }
    public RelayCommand GetMenuDateCommand { protected set; get; }
    public RelayCommand AddMenuDateCommand { protected set; get; }

    public MenuVM()
    {
        Dishes = new ObservableCollection<Dish>(ApiServer.Get<List<Dish>>("Dish"));
        GetMenuDateCommand = new RelayCommand(GetMenu);
        AddMenuDateCommand = new RelayCommand(AddDishToMenu);
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
    /// Get menu for Date
    /// </summary>
    /// <param name="param">null</param>
    public void GetMenu(object param = null)
    {
        Menu.Clear();
        DishInMenu.Clear();
        var menuDate = ApiServer.Get<List<Menu>>("Menu/Date"+Date.Date);
        //var  = new ObservableCollection<Menu>(ApiServer.Get<List<Menu>>("Menu"));
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
        DishCanAddToMenu = Dishes.Where(x=>!DishInMenu.Contains(x)).ToObservableCollection();
    }
}