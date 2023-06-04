using System.Collections.Generic;

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
}