namespace WPFLibrary.JsonModels;

public class Dish
{
    public int DishId { set; get; }
    public string Name { set; get; }
    public string Description { set; get; }
    public double Cost { set; get; }
    public double Weight { set; get; }
    public double Proteins { set; get; }
    public double Fats { set; get; }
    public double Carbohydrates { set; get; }
    public double Calories { set; get; }
}

public class DishInput
{
    public string Name { set; get; }
    public string Description { set; get; }
    public double Cost { set; get; }
    public double Weight { set; get; }
    public double Calories { set; get; }
    public double Proteins { set; get; }
    public double Fats { set; get; }
    public double Carbohydrates { set; get; }
}
