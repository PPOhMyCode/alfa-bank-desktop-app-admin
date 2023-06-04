using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Desktop_Admin.Models;
using WPFLibrary;
using WPFLibrary.JsonModels;
using WPFLibrary.Models;
using Menu = WPFLibrary.JsonModels.Menu;

namespace Desktop_Canteen.ViewModels;

public class MenuVM : BaseVM
{
    public TextBlock MenuPlugTextBlock;
    public int TypeMeal { get; set; }
    public DateTime Date { get; set; }
    public List<DateTime> Days { get; set; }
    private ObservableCollection<MenuView> Menu { get; set; }
    public string TodayDate { get; set; }
    public string TodayMonth { get; set; }
    private ObservableCollection<DishWithPhoto> AllDishes { get; set; }
    public ObservableCollection<DishWithPhoto> DishInMenu { get; set; }
    public RelayCommand SelectDayCommand { protected set; get; }
    public RelayCommand SelectTypeCommand { protected set; get; }
    public List<ImageSource> TypeMealImages { get; set; }
    
    public MenuVM()
    {
        Days = new List<DateTime>();
        var today = (int)DateTime.Today.DayOfWeek;
        Date = DateTime.Today;
        for (int i = 0; i < 5; i++)
            Days.Add(DateTime.Today.AddDays(i-today+1));
        TodayDate = DateTime.Now.ToString("dd.MM");
        var textInfo = new CultureInfo("ru-RU").TextInfo;
        TodayMonth = textInfo.ToTitleCase(textInfo.ToLower(DateTime.Now.ToString("MMMM")));
        var dishes = ApiServer.Get<List<Dish>>("dishes");
        AllDishes = new ObservableCollection<DishWithPhoto>();
        foreach (var dish in dishes)
        {
            AllDishes.Add(new DishWithPhoto(dish, ApiServer.GetImage(dish.DishId.ToString())));
        }
        DishInMenu = new ObservableCollection<DishWithPhoto>();
        Menu = new ObservableCollection<MenuView>();
        SelectDayCommand = new RelayCommand(SelectDay);
        SelectTypeCommand = new RelayCommand(SelectType);
        TypeMeal = 1;
        TypeMealImages = new List<ImageSource>()
        {
            ApiServer.GetImage("typeMealButtons/1"),
            ApiServer.GetImage("typeMealButtons/2"),
            ApiServer.GetImage("typeMealButtons/3")
        };
    }

    public void SelectDay(object param)
    {
        Date = (DateTime) param;
    }
    
    public async void SelectType(object param)
    {
        TypeMeal = int.Parse((string) param);
    }
    
    public async void GetMenu(object param = null)
    {
        try
        {
            MenuPlugTextBlock.Visibility = Visibility.Hidden;
            Menu.Clear();
            DishInMenu.Clear();
            var b = Date.ToString("yyyy-MM-dd");
            var menuDate = ApiServer.Get<List<Menu>>("menus");
            if (menuDate != null)
            {
                foreach (var a in menuDate.Where(x=>x.TypeMealId==TypeMeal && x.Date == b))
                {
                    var date = a.Date;
                    var dish = await Task.Run(()=>ApiServer.Get<Dish>("dishes/" + a.DishId));
                    DishInMenu.Add(new DishWithPhoto(dish, ApiServer.GetImage(dish.DishId.ToString())));
                }
            }

            if (MenuPlugTextBlock != null)
            {
                if (DishInMenu.Count > 0) MenuPlugTextBlock.Visibility = Visibility.Hidden;
                else MenuPlugTextBlock.Visibility = Visibility.Visible;
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}