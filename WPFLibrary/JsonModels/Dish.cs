namespace WPFLibrary.JsonModels;

public class Dish: BaseModel
{
    public string Name { set; get; }
    public string Discription { set; get; }
    public double Cost { set; get; }
    public double Weight { set; get; }
    public double Calories { set; get; }
}

public class DishView
{
    public string Name { set; get; }
    public string Discription { set; get; }
    public double Cost { set; get; }
    public double Weight { set; get; }
    public double Calories { set; get; }
}