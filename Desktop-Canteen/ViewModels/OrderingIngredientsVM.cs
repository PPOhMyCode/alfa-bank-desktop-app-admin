﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Mime;
using System.Windows.Controls;
using System.Globalization;
using System.Windows.Documents;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Canteen.ViewModels;

public class OrderingIngredientsVM : BaseVM
{
    public ObservableCollection<Order> SummaryOrderViews { get; set; }
    public string SelectedDate { get; set; }
    public string TodayMonth { get; set; }
    
    public Image TestImage { get; set; }

    public List<List<string>> Values { get; set; }
    public OrderingIngredientsVM()
    {
        SelectedDate = "2022-11-28";
        var textInfo = new CultureInfo("ru-RU").TextInfo;
        TodayMonth = textInfo.ToTitleCase(textInfo.ToLower(DateTime.Now.ToString("MMMM")));
        var data = ApiServer.Get<List<Order>>("orders/date/" + SelectedDate);
        SummaryOrderViews = new ObservableCollection<Order>();
        TestImage.Source = ApiServer.GetImage("https://storage.yandexcloud.net/systemimg/pasta.png");
        
        Values = new List<List<string>>();
    }
}