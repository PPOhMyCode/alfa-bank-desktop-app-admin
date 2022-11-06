using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Canteen.ViewModels;

public class OrderingIngredientsVM : BaseVM
{
    public ObservableCollection<SummaryOrderView> SummaryOrderViews { get; set; }
    //experimental format
    public ObservableCollection<DishOrder> DishOrders { get; set; }

    public OrderingIngredientsVM()
    {
        //SummaryOrderViews = new ObservableCollection<SummaryOrderView>(ApiServer.Get<List<SummaryOrderView>>("SummaryOrderView"));
        DishOrders = new ObservableCollection<DishOrder>();
        var row = new DishOrder(
            new Dish
            {
                Name = "Каша овсяная"
            },
            511,
            new List<Ingredient>
            {
                new Ingredient { Name = "Крупа овсяная", Measure = "г", Quantity = 100 },
                new Ingredient { Name = "Молоко", Measure = "мл", Quantity = 100 }
            },
            new List<double>
            {
                1.0,
                0.5
            }
        );
        DishOrders.Add(row);
    }
}