using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Admin.ViewModels;

public class RecalculationRequestsVM : BaseVM
{
    public ObservableCollection<RecalculationRequest> Requests { get; set; }
    public int allRequestsCount { get; set; }
    public TextBlock NoDataPlug { get; set; }
    public RecalculationRequestCard _selectedCard;
    public List<Grade> Grades { get; set; }

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
        Requests = new ObservableCollection<RecalculationRequest>();
        Grades = ApiServer.Get<List<Grade>>("grades");
        var requests = ApiServer.Get<List<RecalculationRequestCard>>("/recalculation");
        foreach (var grade in Grades)
        {
            var items = requests.Where(x => x.Class == grade.Name).ToArray();
            if (items.Length > 0)
            {
                var r = new RecalculationRequest() { Grade = grade.Name, ChildrenCards = new List<RecalculationRequestCard>()};
                foreach (var item in items)
                {
                    r.ChildrenCards.Add(item);
                }   
                Requests.Add(r);
            }
        }

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