using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Admin.ViewModels;

public class RecalculationRequestsVM : BaseVM
{
    public ObservableCollection<RecalculationRequest> Requests { get; set; }
    public int allRequestsCount { get; set; }
    public TextBlock NoDataPlug { get; set; }
    public RecalculationRequestCard _selectedCard;
    public RecalculationRequestCard SelectedCard 
    {
        get { return _selectedCard; }
        set
        {
            _selectedCard = value;
            OnPropertyChanged("SelectedCard");
        }
    }
    // public string _childrenNameMoreWindow;
    // public string ChildrenNameMoreWindow 
    // {
    //     get { return _childrenNameMoreWindow; }
    //     set { _childrenNameMoreWindow = SelectedCard.ChildrenName; }
    // }
    //
    // public List<string> _beforeMoreWindow;
    // public List<string> BeforeMoreWindow 
    // {
    //     get { return _beforeMoreWindow; }
    //     set { _beforeMoreWindow = SelectedCard.Before; }
    // }
    // public ObservableCollection<string> _afterMoreWindow;
    // public ObservableCollection<string> AfterMoreWindow
    // {
    //     get { return _afterMoreWindow; }
    //     set { _afterMoreWindow = new ObservableCollection<string>(SelectedCard.After); }
    // }

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
                        Before = new List<string>(){"Творожная запеканка", "Черный чай", "Творожная запеканка", "Черный чай"},
                        After = new List<string>(){"Творожная запеканка", "Черный чай", "Творожная запеканка", "Черный чай", "Творожная запеканка", "Черный чай", "Творожная запеканка"},
                        PriceDiff = "+67 р",
                        Date = "20.06.2023"
                    },
                    new RecalculationRequestCard()
                    {
                        Class = "1А",
                        ChildrenName = "Пик Елизавета",
                        Before = new List<string>(){"Творожная запеканка", "Черный чай"},
                        After = new List<string>(){"Творожная запеканка", "Черный чай"},
                        PriceDiff = "+67 р",
                        Date = "20.06.2023"
                    },
                    new RecalculationRequestCard()
                    {
                        Class = "1А",
                        ChildrenName = "Пик Елизавета",
                        Before = new List<string>(){"Творожная запеканка", "Черный чай"},
                        After = new List<string>(){"Творожная запеканка", "Черный чай"},
                        PriceDiff = "+67 р",
                        Date = "20.06.2023"
                    },
                    new RecalculationRequestCard()
                    {
                        Class = "1А",
                        ChildrenName = "Пик Елизавета",
                        Before = new List<string>(){"Творожная запеканка", "Черный чай"},
                        After = new List<string>(){"Творожная запеканка", "Черный чай"},
                        PriceDiff = "+67 р",
                        Date = "20.06.2023"
                    },
                    new RecalculationRequestCard()
                    {
                        Class = "1А",
                        ChildrenName = "Пик Елизавета",
                        Before = new List<string>(){"Творожная запеканка", "Черный чай"},
                        After = new List<string>(){"Творожная запеканка", "Черный чай"},
                        PriceDiff = "+67 р",
                        Date = "20.06.2023"
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
                        PriceDiff = "-112 р",
                        Date = "20.06.2023"
                    },
                    new RecalculationRequestCard()
                    {
                        Class = "5Б",
                        ChildrenName = "Беляев Антон",
                        Before = new List<string>(){"Творожная запеканка", "Черный чай"},
                        After = new List<string>(),
                        PriceDiff = "-112 р",
                        Date = "20.06.2023"
                    },
                    new RecalculationRequestCard()
                    {
                        Class = "5Б",
                        ChildrenName = "Беляев Антон",
                        Before = new List<string>(){"Творожная запеканка", "Черный чай"},
                        After = new List<string>(),
                        PriceDiff = "-112 р",
                        Date = "20.06.2023"
                    },
                    new RecalculationRequestCard()
                    {
                        Class = "5Б",
                        ChildrenName = "Беляев Антон",
                        Before = new List<string>(){"Творожная запеканка", "Черный чай"},
                        After = new List<string>(),
                        PriceDiff = "-112 р",
                        Date = "20.06.2023"
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