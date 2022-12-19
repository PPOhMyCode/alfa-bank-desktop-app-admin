using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Desktop_Admin.Models;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Canteen.ViewModels;

public class ScheduleVM:BaseVM
{
    public DateTime Date { get; set; }
    public List<DateTime> Days { get; set; }
    private List<Order> DayOrders { get; set; }
    public string TodayMonth { get; set; }
    public ObservableCollection<ScheduleItem> Data { get; set; }
    public TextBlock NoDataPlugTextBlock;
    public Grid TableGrid;

    public RelayCommand SelectDayCommand { protected set; get; }
    public ScheduleVM()
    {
        Days = new List<DateTime>();
        var today = (int)DateTime.Today.DayOfWeek;
        Date = DateTime.Today;
        for (int i = 0; i < 5; i++)
            Days.Add(DateTime.Today.AddDays(i-today+1));
        Data = new ObservableCollection<ScheduleItem>();
        DayOrders = new List<Order>();
        SelectDayCommand = new RelayCommand(SelectDay);
        GetData();
    }
    
    public void SelectDay(object param)
    {
        Date = (DateTime)param;
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
        var a = Date.ToString("yyyy-MM-dd");
        DayOrders = new List<Order>(ApiServer.Get<List<Order>>("orders/date/"+Date.ToString("yyyy-MM-dd")));
        var Timings = new List<Timing>(ApiServer.Get<List<Timing>>("timings"));
        var textInfo = new CultureInfo("ru-RU").TextInfo;
        TodayMonth = textInfo.ToTitleCase(textInfo.ToLower(DateTime.Now.ToString("MMMM")));
        var times = Timings.Select(x => x.Time).ToList();
        times = times.Distinct().ToList();
        foreach (var time in times)
        {
            var scheduleItem = new ScheduleItem(time);
            var gradesId = Timings.Where(x => x.Time == time).Select(x => x.GradeId);
            foreach (var gradeId in gradesId)
            {
                var typeMealId = Timings.Where(x => x.Time == time).Select(x => x.TimingId).FirstOrDefault();
                var orders = ApiServer.Get<List<Order>>("orders/date/" + Date.ToString("yyyy-MM-dd") + "/grades/" + gradeId + "/type/" +
                                                        typeMealId).Where(x => x.StatusId == 2).ToList();
                
                var dishesId = orders?.Select(x => x.DishId).Distinct().ToList();
                List<(string, int)> DishCount = new List<(string, int)>();
                if (dishesId == null)
                    break;
                foreach (var dishId in dishesId)
                {
                    
                    var count = orders.Count(x => x.DishId == dishId);
                    DishCount.Add((ApiServer.Get<Dish>("dishes/"+dishId).Name,count));
                }
                var b = orders?.Select(x => x.ChildrenId).Distinct().ToList();
                var c = ApiServer.Get<Grade>("grades/" + gradeId);
                scheduleItem.AddScheduleInTimeItem(ApiServer.Get<Grade>("grades/" + gradeId).Name,
                    orders.Select(x => x.ChildrenId).Distinct().ToList().Count, DishCount);
            }
            Data.Add(scheduleItem);
        }
    }
}