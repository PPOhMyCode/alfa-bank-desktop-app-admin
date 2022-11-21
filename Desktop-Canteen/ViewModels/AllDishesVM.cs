using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Xps.Packaging;
using Desktop_Admin.Models;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Canteen.ViewModels;

public class AllDishesPage : BaseVM
{
    public ObservableCollection<Dish> Dishes { get; set; }
    public RelayCommand DeleteDishCommand { get; set; }

    public AllDishesPage()
    {
        Dishes = new ObservableCollection<Dish>(ApiServer.Get<List<Dish>>("Dish"));
        DeleteDishCommand = new RelayCommand(DeleteDish);
    }

    public void DeleteDish(object param)
    {
        ApiServer.Delete("Dish/" + param);
    }
}