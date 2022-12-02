﻿using System;
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
    public string SelectedDate { get; set; }

    public List<List<string>> Values { get; set; }
    public OrderingIngredientsVM()
    {
        SelectedDate = "2022-11-28";
        var data = ApiServer.Get<List<DishIngredientView>>("order/date/" + SelectedDate + "/ingredients");
        SummaryOrderViews = new ObservableCollection<DishIngredientView>();

        Values = new List<List<string>>();
        if (data != null)
        {
            SummaryOrderViews= new ObservableCollection<DishIngredientView>(data);
            foreach (var summaryOrderView in SummaryOrderViews)
            {
                var countOrders = summaryOrderView.CountOrders;
                var resultList = new List<string>();
                foreach (var ingredientCount in summaryOrderView.Ingredients)
                {
                    resultList.Add((ingredientCount.Count * ingredientCount.Ingredient.Quantity * countOrders).ToString() + " " +
                                   ingredientCount.Ingredient.Measure);
                }
                Values.Add(resultList);
            }
        }
    }
}