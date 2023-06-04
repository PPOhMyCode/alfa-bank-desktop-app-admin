using System.Collections.Generic;
using System.Windows.Documents;

namespace WPFLibrary.JsonModels;

public class RecalculationRequest
{
    public string Grade { get; set; }
    public List<RecalculationRequestCard> ChildrenCards { get; set; } 
}

public class RecalculationRequestCard
{
    public string ChildrenName { get; set; }
    public string Date { get; set; }
    public string Class { get; set; }
    public List<string> Before { get; set; }
    public List<string> After { get; set; }
    public string PriceDiff { get; set; }
}