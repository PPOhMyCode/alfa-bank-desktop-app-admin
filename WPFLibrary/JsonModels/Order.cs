using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPFLibrary.JsonModels;

public class Order
{ 
    public int OrderId { get; set; }
    public int ChildrenId { get; set; }
    public int DishId { get; set; }
    public int StatusId { get; set; }
    public int TypeId { get; set; }
    public DateTime Date { get; set; }
}


public class OrderView
{
    public ChildrenView Children { get; set; }
    public Dish Dish  { get; set; }
    public string TypeMeal { get; set; }
    public string StatusOrder  { get; set; }
}