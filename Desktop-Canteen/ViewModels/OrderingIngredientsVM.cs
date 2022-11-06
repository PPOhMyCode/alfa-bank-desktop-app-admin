using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Canteen.ViewModels;

public class OrderingIngredientsVM : BaseVM
{
    public ObservableCollection<SummaryOrderView> SummaryOrderViews { get; set; }
    

    public OrderingIngredientsVM()
    {
        SummaryOrderViews = new ObservableCollection<SummaryOrderView>(ApiServer.Get<List<SummaryOrderView>>("SummaryOrderView"));
        // Заглушка, не суди строго
        // SummaryOrderViews = new ObservableCollection<SummaryOrderView>();
        // var s = new SummaryOrderView();
        // s.Date = DateTime.Today;
        // s.Dish = new DishView
        // {
        //     Name = "Каша"
        // };
        // SummaryOrderViews.Add(s);
    }
}