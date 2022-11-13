using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Desktop_Canteen.ViewModels;
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
            
    public void ToChildrensButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new ChildrensPage());
    }
}