using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Canteen.ViewModels;

public class AllDishesPage : BaseVM
{
    public ObservableCollection<Dish> Dishes { get; set; }

    public AllDishesPage()
    {
        Dishes = new ObservableCollection<Dish>(ApiServer.Get<List<Dish>>("Dish"));
    }
}