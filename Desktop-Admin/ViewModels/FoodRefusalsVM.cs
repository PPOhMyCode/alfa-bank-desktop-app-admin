using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Admin.ViewModels;

public class FoodRefusalsVM : BaseVM
{
    public ObservableCollection<FoodRefusal> FoodRefusals { get; set; }
    public int allRefusalsCount { get; set; }
    public TextBlock NoDataPlug { get; set; }

    public RefusalChildrenCard _selectedCard;
    public RefusalChildrenCard SelectedCard
    {
        get { return _selectedCard; }
        set { _selectedCard = value; }
    }
    public string _childrenNameMoreWindow;
    public string ChildrenNameMoreWindow
    {
        get { return _childrenNameMoreWindow; }
        set { _childrenNameMoreWindow = SelectedCard.ChildrenName; }
    }
    public string _causeMoreWindow;
    public string CauseMoreWindow
    {
        get { return _causeMoreWindow; }
        set { _causeMoreWindow = SelectedCard.Cause; }
    }
    public FoodRefusalsVM()
    {
        FoodRefusals = new ObservableCollection<FoodRefusal>();
        var Grades = ApiServer.Get<List<Grade>>("grades");
        foreach (var grade in Grades)
        {
            var refusals = ApiServer.Get<List<RefusalChildrensGet>>("/refusal/grade/" + grade.GradeId);
            if (refusals.Count > 0)
            {
                var childrenCards = new List<RefusalChildrenCard>();
                foreach (var refusal in refusals)
                {
                    childrenCards.Add(new RefusalChildrenCard(refusal, grade.Name));
                }
                FoodRefusals.Add(new FoodRefusal(){ChildrenCards = childrenCards, Grade = grade.Name});
            }
        }
        allRefusalsCount = 0;
        if (FoodRefusals != null || FoodRefusals != new ObservableCollection<FoodRefusal>())
        {
            for (var i = 0; i < FoodRefusals.Count; i++)
            {
                allRefusalsCount += FoodRefusals[i].ChildrenCards.Count;
            }
        }
    }

    public void CheckPlug()
    {
        if (NoDataPlug != null && allRefusalsCount == 0) NoDataPlug.Visibility = Visibility.Visible; 
    }
}