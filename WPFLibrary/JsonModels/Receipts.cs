using System.Collections.Generic;
using System.Linq;

namespace WPFLibrary.JsonModels;

public class ReceiptsView
{
    public string Grade { get; set; }
    public List<ReceiptCard> ReceiptCards { get; set; } 
}

public class ReceiptCard
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Grade { get; set; }
    public List<string> Dishes { get; set; }
    public string Price { get; set; }
    
    public ReceiptCard(){}

    public ReceiptCard(ReceiptCardInput RCI)
    {
        var names = RCI.FullNameChildren.Split();
        FirstName = names[0];
        SecondName = names[1];
        Grade = RCI.Class;
        Dishes = RCI.Dishes;
        Price = RCI.Price.ToString() + " р";
    }
}

public class ReceiptCardInput
{
    public string FullNameChildren { get; set; }
    public string FullNameParent { get; set; }
    public string Class { get; set; }
    public List<string> Dishes { get; set; }
    public float Price { get; set; }
    public int Year { get; set; }
    public string Month { get; set; }
}