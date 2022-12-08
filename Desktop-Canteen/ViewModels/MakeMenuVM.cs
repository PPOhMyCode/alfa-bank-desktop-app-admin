﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using Desktop_Admin.Models;
using DevExpress.Mvvm.Native;
using RestSharp;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;
using Menu = WPFLibrary.JsonModels.Menu;

namespace Desktop_Canteen.ViewModels;

public class MakeMenuVM: BaseVM
{
    public DateTime Date;
    public int TypeMeal;
    public TextBlock PlugTextBlock;
    private ObservableCollection<Dish> AllDishes { get; set; }
    private ObservableCollection<MenuView> Menu { get; set; }
    public ObservableCollection<Dish> DishInMenu { get; set; }
    public ObservableCollection<Dish> DishCanAddToMenu { get; set; }
    public RelayCommand GetMenuDateCommand { protected set; get; }
    public RelayCommand AddMenuDateCommand { protected set; get; }
    public RelayCommand DeleteMenuDateCommand { protected set; get; }
    
    public RelayCommand SelectDayCommand { protected set; get; }
    public RelayCommand SelectTypeCommand { protected set; get; }

    public MakeMenuVM()
    {
        AllDishes = new ObservableCollection<Dish>(
            ApiServer.Get<List<Dish>>("dishes") == null ? new List<Dish>():ApiServer.Get<List<Dish>>("dishes"));
        Menu = new ObservableCollection<MenuView>();
        DishInMenu = new ObservableCollection<Dish>();
        DishCanAddToMenu = new ObservableCollection<Dish>();
        this.GetMenuDateCommand = new RelayCommand(GetMenu);
        this.AddMenuDateCommand = new RelayCommand(AddDishToMenu);
        this.DeleteMenuDateCommand = new RelayCommand(DeleteDishToMenu);
        SelectDayCommand = new RelayCommand(SelectDay);
        SelectTypeCommand = new RelayCommand(SelectType);
        Date = DateTime.Today.Date;
        GetMenu();
        
        //если даты четверти не выбраны, то листы с блюдами заполнять пока не надо, а PlugTextBlock.Visability = Visible
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
        var responce = ApiServer.Post(menu, "menus");
        GetMenu();
    }
    
    /// <summary>
    /// Delete Dish from Menu for day and Type
    /// </summary>
    /// <param name="param">DishId</param>
    public void DeleteDishToMenu(object param)
    {
        var id = Menu.FirstOrDefault(x => x.Dish.DishId == (int)param).Id;
        ApiServer.Delete("menus/"+id);
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
        DishCanAddToMenu.Clear();
        var b = Date.ToString("yyyy-mm-dd");
        var menuDate = ApiServer.Get<List<Menu>>("menus/date/"+Date.ToString("yyyy-mm-dd"));
        //var  = new ObservableCollection<Menu>(ApiServer.Get<List<Menu>>("menus"));
        if (menuDate != null)
        {
            foreach (var a in menuDate.Where(x=>x.TypeMealId==TypeMeal))
            {
                var dish = ApiServer.Get<Dish>("dishes/" + a.DishId);
                Menu.Add(new MenuView()
                {
                    Date = a.Date,
                    Dish = dish,
                    TypeMeal = ApiServer.Get<TypeMeal>("typeMeals/"+a.TypeMealId),
                    Id = a.Id
                });
                DishInMenu.Add(dish);
            }
        }
        var valuesToExclude = DishInMenu.Select(x => x.DishId).ToArray();
        DishCanAddToMenu = AllDishes.Where(x => !valuesToExclude.Contains(x.DishId)).ToObservableCollection();
    }
}