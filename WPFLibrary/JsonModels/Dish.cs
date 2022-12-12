using System.Windows.Media;
using System.Windows.Media.Imaging;

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

public class DishWithPhoto
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
    public ImageSource Image { get; set; }

    public DishWithPhoto(Dish dish, BitmapImage bitmap)
    {
        DishId = dish.DishId;
        Name = dish.Name;
        Description = dish.Description;
        Cost = dish.Cost;
        Weight = dish.Weight;
        Proteins = dish.Proteins;
        Fats = dish.Fats;
        Carbohydrates = dish.Carbohydrates;
        Calories = dish.Calories;
        Image = bitmap;
    }
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
