using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Canteen.ViewModels;

public class ScheduleVM:BaseVM
{
    private List<Order> DayOrders { get; set; }
    public string SelectedData { get; set; }
    public ObservableCollection<ScheduleItem> Data { get; set; }

    public ScheduleVM()
    {
        Data = new ObservableCollection<ScheduleItem>();
        DayOrders = new List<Order>();
        GetData();
    }

    public void GetData()
    {
        SelectedData = "2022-11-28";
        DayOrders = new List<Order>(ApiServer.Get<List<Order>>("orders/date/"+SelectedData));
        var Timings = new List<Timing>(ApiServer.Get<List<Timing>>("timings"));
        /*
        foreach (var time in Timings)
        {
            var scheduleItem = new ScheduleItem(time);
            var grades = DayOrders.Where(x => x.Time == time).Select(x => x.Grade);
             
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