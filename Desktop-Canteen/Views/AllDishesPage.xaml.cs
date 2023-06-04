using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Desktop_Canteen.ViewModels;
using WPFLibrary;
using WPFLibrary.JsonModels;

namespace Desktop_Canteen.Views;

public partial class AllDishesPage : Page
{
    private AllDishesVM _allDishesVm;
    public AllDishesPage()
    {
        InitializeComponent();
        _allDishesVm = new AllDishesVM()
        {
            Plug = Plug,
            ProgressBar = ProgressBar,
            ToRef = ToRefactorDishButtonClick()
        };
        DataContext = _allDishesVm;
        _allDishesVm.Refresh();
    }

    public void Refresh()
    {
        _allDishesVm.Refresh();
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

    public void ToAddNewDishButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new AddNewDishPage());
    }
    
    public System.Action ToRefactorDishButtonClick()
    {

        return (() => NavigationService?.Navigate(new AddNewDishPage(_allDishesVm.selectId)));
    }
}