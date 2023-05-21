using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
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
        FoodRefusals = new ObservableCollection<FoodRefusal>()
        {
            new FoodRefusal()
            {
                Grade = "1А",
                ChildrenCards = new List<RefusalChildrenCard>()
                {
                    new RefusalChildrenCard()
                    {
                        Cause = "В связи с тем, что ребенок не употребляет пищу столовой",
                        Class = "1А",
                        ChildrenName = "Пик Елизавета"
                    },
                    new RefusalChildrenCard()
                    {
                        Cause = "В связи с тем, что ребенок не употребляет пищу столовой",
                        Class = "1А",
                        ChildrenName = "Пик Елизавета"
                    },
                    new RefusalChildrenCard()
                    {
                        Cause = "В связи с тем, что ребенок не употребляет пищу столовой",
                        Class = "1А",
                        ChildrenName = "Пик Елизавета"
                    },
                    new RefusalChildrenCard()
                    {
                        Cause = "В связи с тем, что ребенок не употребляет пищу столовой",
                        Class = "1А",
                        ChildrenName = "Пик Елизавета"
                    },
                    new RefusalChildrenCard()
                    {
                        Cause = "Диета",
                        Class = "1А",
                        ChildrenName = "Антонова Екатерина"
                    }
                }
            },
            new FoodRefusal()
            {
                Grade = "5Б",
                ChildrenCards = new List<RefusalChildrenCard>()
                {
                    new RefusalChildrenCard()
                    {
                        Cause = "В связи с тем, что ребенок не употребляет пищу столовой, В связи с тем, что ребенок не употребляет пищу столовой, В связи с тем, что ребенок не употребляет пищу столовой",
                        Class = "5Б",
                        ChildrenName = "Беляев Антон"
                    },
                    new RefusalChildrenCard()
                    {
                        Cause = "Диета",
                        Class = "5Б",
                        ChildrenName = "Антонова Екатерина"
                    },
                    new RefusalChildrenCard()
                    {
                        Cause = "Диета",
                        Class = "5Б",
                        ChildrenName = "Антонова Екатерина"
                    },
                    new RefusalChildrenCard()
                    {
                        Cause = "Диета",
                        Class = "5Б",
                        ChildrenName = "Антонова Екатерина"
                    }
                }
            }
        };

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