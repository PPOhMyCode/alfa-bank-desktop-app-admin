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
    public ObservableCollection<DishIngredientView> SummaryOrderViews { get; set; }
    
    public ObservableCollection<SummaryOrderDateIngrediets> ListOrders { get; set; }
    public OrderingIngredientsVM()
    {
        SummaryOrderViews = new ObservableCollection<DishIngredientView>(ApiServer.Get<List<DishIngredientView>>("Orders/Date/11-28-2022/Ingredients"));
    }
}