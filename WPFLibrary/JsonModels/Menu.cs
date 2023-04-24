using System;

namespace WPFLibrary.JsonModels;

public class Menu : BaseModel
{
    public DateTime Date { get; set; }
    public int DishId { get; set; }
    public int TypeMealId { get; set; }
}

public class MenuInput
{
    public string Date { get; set; }
    public int DishId { get; set; }
    public int TypeMealId { get; set; }
}


public class MenuView : BaseModel
{
    public DateTime Date { get; set; }
    public Dish Dish { get; set; }
    public TypeMeal TypeMeal { get; set; }
}