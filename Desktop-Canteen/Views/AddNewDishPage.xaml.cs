using System;
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
    public AddNewDishPage()
    {
        
        InitializeComponent();
        _AddNewDishVm = new AddNewDishVM();
        DataContext  = _AddNewDishVm;
        _AddNewDishVm.IngredientsStackPanel = this.Ingredients;
        _AddNewDishVm.AddNewIngredientButton = this.AddNewIngredientButton;
       
    }
    
    public void SaveClick(object sender, RoutedEventArgs e)
    {
        try
        {
            _AddNewDishVm.ExecuteAddDish();
            var page = MainWindow.DictionaryPages["Dishes"] as AllDishesPage;
            page.Refresh();
            NavigationService?.Navigate(MainWindow.DictionaryPages["Dishes"]);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }

    public void ToAllDishesButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(MainWindow.DictionaryPages["Dishes"]);
    }
    
    public void ToOrderingIngredientsButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(MainWindow.DictionaryPages["Ingredients"]);
    }
            
    public void ToMenuButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(MainWindow.DictionaryPages["Menu"]);
    }
    public void ToScheduleButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(MainWindow.DictionaryPages["Schedule"]);
    }
}