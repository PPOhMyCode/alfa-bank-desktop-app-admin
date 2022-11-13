﻿namespace WPFLibrary.JsonModels;

public class Ingredient: BaseModel
{
    public string Name { set; get; }
    public double Quantity { set; get; }
    public string Measure { set; get; }
}

public class IngredientView:BaseModel
{
    public string Name { set; get; }
    public double Quantity { set; get; }
    public string Measure { set; get; }

    public IngredientView(Ingredient ingredient)
    {
        Id = ingredient.Id;
        Name = ingredient.Name;
        Quantity = ingredient.Quantity;
        Measure = ingredient.Measure;
    }
}

public class IngredientCount
{
    public Ingredient Ingredient { get; set; }
    public double Count { set; get; }
}

public class IngredientCountInput
{
    public int IngredientId { get; set; }
    public double Count { set; get; }
}