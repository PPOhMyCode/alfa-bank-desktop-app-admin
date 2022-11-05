namespace WPFLibrary.JsonModels;

public class Ingredient: BaseModel
{
    public string Name { set; get; }
    public double Quantity { set; get; }
    public string Measure { set; get; }
}

public class IngredientView
{
    public string Name { set; get; }
    public double Quantity { set; get; }
    public string Measure { set; get; }
}