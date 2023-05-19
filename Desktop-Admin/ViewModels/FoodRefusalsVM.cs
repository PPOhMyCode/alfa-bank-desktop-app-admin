using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Admin.ViewModels;

public class FoodRefusalsVM : BaseVM
{
    public ObservableCollection<FoodRefusal> FoodRefusals { get; set; }
    public int allRefusalsCount { get; set; }
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
                        Cause = "В связи с тем, что ребенок не употребляет пищу столовой",
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
        
    }
}