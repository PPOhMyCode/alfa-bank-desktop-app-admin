using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WPFLibrary.JsonModels;

namespace Desktop_Admin.ViewModels;

public class RecalculationRequestsVM
{
    public ObservableCollection<RecalculationRequest> Requests { get; set; }
    public int allRequestsCount { get; set; }
    public TextBlock NoDataPlug { get; set; }

    public RecalculationRequestsVM()
    {
        Requests = new ObservableCollection<RecalculationRequest>()
        {
            new RecalculationRequest()
            {
                Grade = "1А",
                ChildrenCards = new List<RecalculationRequestCard>()
                {
                    new RecalculationRequestCard()
                    {
                        Class = "1А",
                        ChildrenName = "Пик Елизавета",
                        Before = new List<string>(){"Творожная запеканка", "Черный чай"},
                        After = new List<string>(){"Творожная запеканка", "Черный чай"},
                        PriceDiff = "+67 р"
                    },
                    new RecalculationRequestCard()
                    {
                        Class = "1А",
                        ChildrenName = "Пик Елизавета",
                        Before = new List<string>(){"Творожная запеканка", "Черный чай"},
                        After = new List<string>(){"Творожная запеканка", "Черный чай"},
                        PriceDiff = "+67 р"
                    },
                    new RecalculationRequestCard()
                    {
                        Class = "1А",
                        ChildrenName = "Пик Елизавета",
                        Before = new List<string>(){"Творожная запеканка", "Черный чай"},
                        After = new List<string>(){"Творожная запеканка", "Черный чай"},
                        PriceDiff = "+67 р"
                    },
                    new RecalculationRequestCard()
                    {
                        Class = "1А",
                        ChildrenName = "Пик Елизавета",
                        Before = new List<string>(){"Творожная запеканка", "Черный чай"},
                        After = new List<string>(){"Творожная запеканка", "Черный чай"},
                        PriceDiff = "+67 р"
                    },
                    new RecalculationRequestCard()
                    {
                        Class = "1А",
                        ChildrenName = "Пик Елизавета",
                        Before = new List<string>(){"Творожная запеканка", "Черный чай"},
                        After = new List<string>(){"Творожная запеканка", "Черный чай"},
                        PriceDiff = "+67 р"
                    }
                }
            },
            new RecalculationRequest()
            {
                Grade = "5Б",
                ChildrenCards = new List<RecalculationRequestCard>()
                {
                    new RecalculationRequestCard()
                    {
                        Class = "5Б",
                        ChildrenName = "Беляев Антон",
                        Before = new List<string>(){"Творожная запеканка", "Черный чай"},
                        After = new List<string>(),
                        PriceDiff = "-112 р"
                    },
                    new RecalculationRequestCard()
                    {
                        Class = "5Б",
                        ChildrenName = "Беляев Антон",
                        Before = new List<string>(){"Творожная запеканка", "Черный чай"},
                        After = new List<string>(),
                        PriceDiff = "-112 р"
                    },
                    new RecalculationRequestCard()
                    {
                        Class = "5Б",
                        ChildrenName = "Беляев Антон",
                        Before = new List<string>(){"Творожная запеканка", "Черный чай"},
                        After = new List<string>(),
                        PriceDiff = "-112 р"
                    },
                    new RecalculationRequestCard()
                    {
                        Class = "5Б",
                        ChildrenName = "Беляев Антон",
                        Before = new List<string>(){"Творожная запеканка", "Черный чай"},
                        After = new List<string>(),
                        PriceDiff = "-112 р"
                    }
                }
            }
        };

        allRequestsCount = 0;
        if (Requests != null || Requests != new ObservableCollection<RecalculationRequest>())
        {
            for (var i = 0; i < Requests.Count; i++)
            {
                allRequestsCount += Requests[i].ChildrenCards.Count;
            }
        }
    }
    
    public void CheckPlug()
    {
        if (NoDataPlug != null && allRequestsCount == 0) NoDataPlug.Visibility = Visibility.Visible; 
    }
}