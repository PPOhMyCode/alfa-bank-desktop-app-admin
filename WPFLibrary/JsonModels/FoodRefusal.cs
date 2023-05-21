using System;
using System.Collections.Generic;
using System.Windows.Documents;
using WPFLibrary.JsonModels;

namespace WPFLibrary.JsonModels;

public class FoodRefusal
{
   public string Grade { get; set; }
   public List<RefusalChildrenCard> ChildrenCards { get; set; } 
}

public class RefusalChildrenCard
{
   public string ChildrenName { get; set; }
   public string Class { get; set; }
   public string Cause { get; set; }
}