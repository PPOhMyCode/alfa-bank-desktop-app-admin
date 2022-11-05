using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Desktop_Admin.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Admin.ViewModels;

public class MainViewModel : BaseVM, INotifyPropertyChanged
{
    private ComboBoxItem selectedItem;
    public ObservableCollection<ComboBoxItem > Classes { get; private set; }

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

    public MainViewModel()
    {
        Classes = new ObservableCollection<ComboBoxItem >();
        foreach (var item in LoadComboBoxData())
            Classes.Add(new ComboBoxItem  {Content = item, MinHeight = 20});
    }
}