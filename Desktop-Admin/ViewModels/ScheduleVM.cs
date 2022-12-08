using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Admin.ViewModels;

public class ScheduleVM : BaseVM
{
    private ComboBoxItem selectedItem;
    public ComboBoxItem SelectedClass
    {
        get { return selectedItem; }
        set
        {
            selectedItem = value;
            OnPropertyChanged("SelectedClass");
        }
    }
    public ObservableCollection<ComboBoxItem> Classes { get; private set; }
    public ObservableCollection<string> Timings { get; private set; }
    public ObservableCollection<Children> ChildrenInSelectedClass { get; set; }
    public string[] LoadComboBoxData()
    {
        string[] strArray =
        {
            "Все классы",
            "1A",
            "1Б",
            "1В",
            "2А",
            "2Б",
            "3А",
            "4А",
            "5А",
            "5Б"
        };
        return strArray;
    }

    public ScheduleVM()
    {
        Classes = new ObservableCollection<ComboBoxItem>();
        foreach (var item in LoadComboBoxData())
            Classes.Add(new ComboBoxItem { Content = item, MinHeight = 20 });

        SelectedClass = Classes[1];

        Timings = new ObservableCollection<string>()
        {
            "9:30 - 10:00",
            "13:00 - 13:30",
            "15:00 - 15:30"
        };
        
        ChildrenInSelectedClass = new ObservableCollection<Children>()
        {
            new()
            {
                FirstName = "Екатерина",
                GradeID = 1,
                Id = 1,
                ParentID = 1,
                Patronymic = "Вячеславовна",
                SecondName = "Антонова"
            },
            new()
            {
                FirstName = "Мария",
                GradeID = 1,
                Id = 2,
                ParentID = 1,
                Patronymic = "Вячеславовна",
                SecondName = "Синицина"
            },
            new()
            {
                FirstName = "Анастасия",
                GradeID = 1,
                Id = 3,
                ParentID = 1,
                Patronymic = "Вячеславовна",
                SecondName = "Антонова"
            },
            new()
            {
                FirstName = "Иван",
                GradeID = 1,
                Id = 4,
                ParentID = 1,
                Patronymic = "Вячеславовна",
                SecondName = "Иванов"
            },
        };
    }
}