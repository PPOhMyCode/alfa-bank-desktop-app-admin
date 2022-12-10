using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Xps.Packaging;
using Desktop_Admin.Models;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;

namespace Desktop_Canteen.ViewModels;

public class AllDishesVM : BaseVM
{
    public ObservableCollection<Dish> Dishes { get; set; }
    public RelayCommand DeleteDishCommand { get; set; }
    public TextBlock Plug { get; set; }

    public AllDishesVM()
    {
        Dishes = new ObservableCollection<Dish>();
        DeleteDishCommand = new RelayCommand(DeleteDish);
        Refresh();
    }

    public void Refresh()
    {
        Dishes = new ObservableCollection<Dish>(ApiServer.Get<List<Dish>>("dishes"));
        if (Plug == null) return;
        if (Dishes.Count == 0)
        {
            Plug.Visibility = Visibility.Visible;
        }
        else
        {
            Plug.Visibility = Visibility.Hidden;
        }
    }

    public void DeleteDish(object param)
    {
        if (MessageBox.Show("Вы уверены, что хотите удалить это блюдо?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
            ApiServer.Delete("dishes/" + param);
            Refresh();
        }
    }
}