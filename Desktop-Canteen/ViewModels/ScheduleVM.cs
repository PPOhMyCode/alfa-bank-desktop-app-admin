using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Canteen.ViewModels;

public class ScheduleVM:BaseVM
{
    private List<Order> DayOrders { get; set; }
    public string SelectedData { get; set; }
    public string TodayMonth { get; set; }
    public ObservableCollection<ScheduleItem> Data { get; set; }
    public TextBlock NoDataPlugTextBlock;
    public Grid TableGrid;

    public ScheduleVM()
    {
        Data = new ObservableCollection<ScheduleItem>();
        DayOrders = new List<Order>();
        GetData();
    }

    public void CheckPlug()
    {
        if (Data != null && Data.Count > 0)
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
    
    public void GetData()
    {
        SelectedData = "2022-11-28";
        DayOrders = new List<Order>(ApiServer.Get<List<Order>>("orders/date/"+SelectedData));
        var Timings = new List<Timing>(ApiServer.Get<List<Timing>>("timings"));
        var textInfo = new CultureInfo("ru-RU").TextInfo;
        TodayMonth = textInfo.ToTitleCase(textInfo.ToLower(DateTime.Now.ToString("MMMM")));
        /*
        SelectedData = "11-19-2022";
        DayOrders = new List<SummaryOrderView>(ApiServer.Get<List<SummaryOrderView>>("Orders/Date/"+SelectedData));
        var Timings = DayOrders.Select(x=>x.Time).Distinct().ToList();
        foreach (var time in Timings)
        {
            var scheduleItem = new ScheduleItem(time);
            var grades = DayOrders.Where(x => x.Time == time).Select(x => x.Grade);
            //grades = new List<GradeView>(grades);
            grades = grades.DistinctBy(x => x.Name);
            foreach (var grade in grades)
            {
                var dishes = DayOrders
                    .Where(x => x.Time == time && x.Grade.Name == grade.Name)
                    .Select(x => x.Dish.Name).Distinct().ToList();
                List<(string, int)> DishCount = new List<(string, int)>();
                foreach (var dish in dishes)
                {
                    var count = DayOrders
                        .Count(x => x.Time == time && x.Grade.Name == grade.Name && x.Dish.Name == dish);
                    DishCount.Add((dish,count));
                }
                scheduleItem.AddScheduleInTimeItem(grade.Name,DishCount);
            }
            Data.Add(scheduleItem);
        }
        */
    }
}