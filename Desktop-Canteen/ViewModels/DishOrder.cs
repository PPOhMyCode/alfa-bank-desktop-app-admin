using System.Collections.Generic;
using WPFLibrary.JsonModels;

namespace Desktop_Canteen.ViewModels;

public class DishOrder
{
    public Dish Dish { get; set; } // непосредственно блюдо
    public int Count { get; set; } // количество порций, которое надо приготовить
    public List<Ingredient> Ingredients { get; set; } // список ингредиентов для приготовления блюда
    public List<string> Values { get; set; } // строки формата "вес продукта + единица измерения"
    public List<double> CountInDish {get; set; } //количество ингредиента для одной порции блюда, из таблицы Dish-Ingredient 
    
    public DishOrder(Dish dish, int count, List<Ingredient> ingredients, List<double> countInDish)
    {
        Dish = dish;
        Count = count;
        Ingredients = ingredients;
        Values = new List<string>();
        CountInDish = countInDish;
        for (int i = 0; i < Ingredients.Count; ++i)
        {
            // собираем вот такие строки "51100 мл"
            Values.Add((Ingredients[i].Quantity * Count * CountInDish[i]).ToString() + " " + Ingredients[i].Measure);
        }
    }

}