using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Desktop_Canteen.ViewModels;
using WPFLibrary;
using WPFLibrary.JsonModels;

namespace Desktop_Canteen.Views;

public partial class AddNewDishPage : Page
{
    public AddNewDishVM _AddNewDishVm;
    public AddNewDishPage(int id = -1)
    {
        InitializeComponent();
        if (id != -1)
        {
            Dish dish = ApiServer.Get<Dish>("dishes/" + id);
            _AddNewDishVm = new AddNewDishVM()
            {
                Name = dish.Name,
                Discription = dish.Description,
                Cost = dish.Cost,
                Calories = dish.Calories,
                Weight = dish.Weight,
                Fats = dish.Fats,
                Proteins = dish.Proteins,
                Carbohydrates = dish.Carbohydrates,
                DishId = id
            };
            _AddNewDishVm.IngredientsStackPanel = this.Ingredients;
            _AddNewDishVm.AddNewIngredientButton = this.AddNewIngredientButton;
            int[] arr = new[] {0, 1, 2};
            var ing = ApiServer.Get<List<IngredientCount>>("/dishes/"+id+"/ingredients");
            foreach (var i in ing)
            {
                _AddNewDishVm._selectedItem = new Ingredient()
                {
                    IngredientId = i.IngredientId,
                    Name = i.Name,
                    Measure = i.Measure
                };
                _AddNewDishVm.AddSelectedIngredient(MathF.Round((float)i.Quantity*(float)i.Count, 2));
            }
        }
        else
        {
            _AddNewDishVm = new AddNewDishVM();
            _AddNewDishVm.IngredientsStackPanel = this.Ingredients;
            _AddNewDishVm.AddNewIngredientButton = this.AddNewIngredientButton;
        }
        
        DataContext  = _AddNewDishVm;
    }
    
    public void SaveClick(object sender, RoutedEventArgs e)
    {
        try
        {
            _AddNewDishVm.ExecuteAddDish();
            NavigationService?.Navigate(new AllDishesPage());
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }

    public void ToAllDishesButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new AllDishesPage());
    }
    
    public void ToOrderingIngredientsButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new OrderingIngredientsPage());
    }
            
    public void ToMenuButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new MenuPage());
    }
    public void ToScheduleButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new SchedulePage());
    }
}