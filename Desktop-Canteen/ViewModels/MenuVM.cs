using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Desktop_Admin.Models;
using RestSharp;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Canteen.ViewModels;

public class MenuVM: BaseVM
{
    public DateTime Date;
    public int TypeMeal;
    public ObservableCollection<Dish> Dishes { get; set; }
    public ObservableCollection<MenuView> Menu { get; set; }
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
        ApiServer.Post(menu, "Menu");
    }
    /// <summary>
    /// Get menu for Date
    /// </summary>
    /// <param name="param">null</param>
    public void GetMenu(object param)
    {
        Menu.Clear();
        var menuDate = ApiServer.Get<List<Menu>>("Menu/Date"+Date.Date);
        //var  = new ObservableCollection<Menu>(ApiServer.Get<List<Menu>>("Menu"));
        foreach (var a in menuDate)
        {
            Menu.Add(new MenuView()
            {
                Date = a.Date,
                Dish = ApiServer.Get<Dish>("Dish/"+a.DishId),
                TypeMeal = ApiServer.Get<TypeMeal>("TypeMeal/"+a.TypeMealId),
                Id = a.Id
            });
        }

    }
}