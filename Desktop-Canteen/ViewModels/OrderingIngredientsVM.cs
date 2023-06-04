using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Mime;
using System.Windows.Controls;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Canteen.ViewModels;

public class OrderingIngredientsVM : BaseVM
{
    public ObservableCollection<OrderIngredient> SummaryOrderViews { get; set; }
    public string SelectedDate { get; set; }
    public string TodayMonth { get; set; }

    private List<Order> _orders { get; set; }

    public Image TestImage { get; set; }
    public TextBlock NoDataPlugTextBlock;
    public Grid TableGrid;

    public List<List<string>> Values { get; set; }
    public OrderingIngredientsVM()
    {
        //TODO:Сделать новый запрос и по-человечески
        SelectedDate = "test";
        var textInfo = new CultureInfo("ru-RU").TextInfo;
        //TodayMonth = textInfo.ToTitleCase(textInfo.ToLower(DateTime.Now.ToString("MMMM")));
        TodayMonth = "Июнь";
        _orders = ApiServer.Get<List<Order>>("orders/date/" + SelectedDate);
        SummaryOrderViews = new ObservableCollection<OrderIngredient>();
        Values = new List<List<string>>();
        Refresh();
    }

    private void Refresh()
    {
        SummaryOrderViews.Clear();
        var listId = new List<int>();
        foreach (var order in _orders)
        {
            if (listId.Contains(order.DishId))
            {
                var a = SummaryOrderViews.Where(x => x.Dish.DishId == order.DishId).FirstOrDefault();
                SummaryOrderViews.Remove(a);
                a.Count += 1;
                SummaryOrderViews.Add(a);
            }
            else
            {
                SummaryOrderViews.Add(new OrderIngredient()
                {
                    Count = 1,
                    Dish = ApiServer.Get<Dish>("dishes/"+order.DishId),
                    Ingredients = ApiServer.Get<List<IngredientCount>>("dishes/"+order.DishId+"/ingredients")
                    //TODO: надо исправить выгрузку ингредиентов в виде класса, содержащего Count, Measure, Quantity
                });
            }
            
        }
        foreach (var summaryOrderView in SummaryOrderViews)
        {
            var countOrders = summaryOrderView.Count;
            var resultList = new List<string>();
            foreach (var ingredientCount in summaryOrderView.Ingredients)
            {
                resultList.Add((Math.Round(ingredientCount.Count, 2) * Math.Round(ingredientCount.Quantity, 2) * countOrders).ToString() + " " +
                               ingredientCount.Measure);
            }
            Values.Add(resultList);
        }
    }

    public void CheckPlug()
    {
        if (SummaryOrderViews != null && SummaryOrderViews.Count > 0)
        {
            NoDataPlugTextBlock.Visibility = Visibility.Hidden;
            TableGrid.Visibility = Visibility.Visible;
        }
        else
        {
            NoDataPlugTextBlock.Visibility = Visibility.Visible;
            TableGrid.Visibility = Visibility.Hidden;
        }
    }
}