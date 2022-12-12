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
    public ObservableCollection<DishWithPhoto> Dishes { get; set; }
    public RelayCommand DeleteDishCommand { get; set; }

    public AllDishesPage()
    {
        Dishes = new ObservableCollection<DishWithPhoto>();
        DeleteDishCommand = new RelayCommand(DeleteDish);
        Refresh();
    }

    public void Refresh()
    {
        var dishes = new ObservableCollection<Dish>(ApiServer.Get<List<Dish>>("dishes"));
        foreach (var dish in dishes)
        {
            Dishes.Add(new DishWithPhoto(dish, ApiServer.GetImage(dish.DishId.ToString())));
        }
    }

    public void DeleteDish(object param)
    {
        ApiServer.Delete("dishes/" + param);
        Refresh();
    }
}