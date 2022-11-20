using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using WPFLibrary.JsonModels;

namespace WPFLibrary.Models;

public class ScheduleItem
{
    public string Time { get; set; } 
    public List<ScheduleInTimeItem> Data { get; set; }

    public ScheduleItem(TimeSpan time)
    {
        Time = time.ToString();
        Data = new List<ScheduleInTimeItem>();
    }

    public void AddScheduleInTimeItem(string gradeName, List<(string, int)> DishCount)
    {
        Data.Add(new ScheduleInTimeItem(gradeName,DishCount));
    }
}

public class ScheduleInTimeItem
{
    public string GradeName { get; set; }
    public int AllCount { get; set; }
    public List<RequestsItem> RequestsItems { get; set; }

    public ScheduleInTimeItem(string gradeName, List<(string, int)> DishCount)
    {
        GradeName = gradeName;
        RequestsItems = new List<RequestsItem>();
        AllCount = DishCount.Sum(x => x.Item2);
        foreach (var dTuple in DishCount)
        {
            RequestsItems.Add(new RequestsItem(dTuple.Item1, dTuple.Item2));
        }
    }
}

public class RequestsItem
{
    public string DishName { get; set; }
    public int Count { get; set; }

    public RequestsItem(string dishName, int count)
    {
        DishName = dishName;
        Count = count;
    }

    public override string ToString() =>
        $"{DishName} - {Count} шт.";
} 