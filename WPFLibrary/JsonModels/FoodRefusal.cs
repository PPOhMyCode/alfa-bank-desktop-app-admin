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

   public RefusalChildrenCard(){}
   
   public RefusalChildrenCard(RefusalChildrensGet item, string grade)
   {
      Class = grade;
      ChildrenName = item.ChildrenName;
      Cause = item.Cause;
   }
}

public class RefusalChildrensGet
{
   public string ChildrenName { get; set; }
   public string Date { get; set; }
   public string Cause { get; set; }
}