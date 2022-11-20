﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPFLibrary.JsonModels;

public class SummaryOrder : BaseModel
{
    public DateTime Date { get; set; }
    public int TimingId { get; set; }
    public int OrderId { get; set; }
    public int Count { get; set; }
}

public class SummaryOrderView: BaseModel
{
    public DateTime Date { get; set; }
    public int Count { get; set; }
    public TimeSpan Time { get; set; }
    public string TypeMeal { get; set; }
    public GradeView Grade { get; set; }
    public string StatusOrder  { get; set; }
    public Dish Dish  { get; set; }
    public ChildrenInfo Children { get; set; }
}

public class SummaryOrderDateIngrediets
{
    public DateTime Date { get; set; }
    public int Count { get; set; }
    public  DishIngredientView DishIngredientView { get; set; }
}