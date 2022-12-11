using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Controls;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Admin.ViewModels;

public class ReceiptsVM : BaseVM
{
    private ComboBoxItem selectedItem;
    public DateTime Date { get; set; }
    public ObservableCollection<ComboBoxItem> Classes { get; private set; }
    public ObservableCollection<ChildrenView> ChildrenInSelectedClass { get; set; }

    public ComboBoxItem SelectedClass
    {
        get { return selectedItem; }
        set
        {
            selectedItem = value;
            OnPropertyChanged("SelectedClass");
        }
    }

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
            "5А"
        };
        return strArray;
    }

    public ReceiptsVM()
    {
        //list всех классов
        //var grades = ApiServer.Get<List<Grade>>("grades");
        
        //var childrens = ApiServer.Get<List<Children>>("grades/1/childrens");
        
        var today = (int)DateTime.Today.DayOfWeek;
        Date = DateTime.Today;
       
        
        Classes = new ObservableCollection<ComboBoxItem>();
        foreach (var item in LoadComboBoxData())
            Classes.Add(new ComboBoxItem { Content = item, MinHeight = 20 });

        SelectedClass = Classes[1];

        ChildrenInSelectedClass = new ObservableCollection<ChildrenView>()
        {
            new()
            {
                FirstName = "Екатерина",
                Patronymic = "Вячеславовна",
                SecondName = "Антонова",
                Grade = new GradeView(){Name = "1А"}
            },
            new()
            {
                FirstName = "Мария",
                Patronymic = "Вячеславовна",
                SecondName = "Синицина",
                Grade = new GradeView(){Name = "1А"}
            },
            new()
            {
                FirstName = "Анастасия",
                Patronymic = "Вячеславовна",
                SecondName = "Антонова",
                Grade = new GradeView(){Name = "1А"}
            },
            new()
            {
                FirstName = "Иван",
                Patronymic = "Вячеславовна",
                SecondName = "Иванов",
                Grade = new GradeView(){Name = "1А"}
            },
            new()
            {
                FirstName = "Екатерина",
                Patronymic = "Вячеславовна",
                SecondName = "Антонова",
                Grade = new GradeView(){Name = "1А"}
            },
            new()
            {
                FirstName = "Мария",
                Patronymic = "Вячеславовна",
                SecondName = "Синицина",
                Grade = new GradeView(){Name = "1А"}
            },
            new()
            {
                FirstName = "Анастасия",
                Patronymic = "Вячеславовна",
                SecondName = "Антонова",
                Grade = new GradeView(){Name = "1А"}
            },
            new()
            {
                FirstName = "Иван",
                Patronymic = "Вячеславовна",
                SecondName = "Иванов",
                Grade = new GradeView(){Name = "1А"}
            },
        };
    }
}