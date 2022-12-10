using System.Windows;
using System.Windows.Controls;
using Desktop_Canteen.ViewModels;

namespace Desktop_Canteen.Views;

public partial class OrderingIngredientsPage : Page
{
    private OrderingIngredientsVM _orderingIngredientsVm;
    public OrderingIngredientsPage()
    {
        InitializeComponent();
        _orderingIngredientsVm = new OrderingIngredientsVM()
        {
            NoDataPlugTextBlock = NoDataPlug,
            TableGrid = TableGrid
        };
        DataContext = _orderingIngredientsVm;
        _orderingIngredientsVm.CheckPlug();
    }
    
    public void ToAllDishesButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new AllDishesPage());
    }
            
    public void ToMenuButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new MenuPage());
    }
    public void ToScheduleButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new SchedulePage());
    }
    
    public void ChangeStyleCircleButton(object sender, RoutedEventArgs e)
    {
        DefaultStyleToAllCircleButton();
        var isSelected = (sender as Button).Style.Equals(Application.Current.TryFindResource("SelectedCircleButton") as Style);
        if (isSelected)
        {
            (sender as Button).Style = Application.Current.TryFindResource("CircleButton") as Style;
        }
        else
        {
            (sender as Button).Style = Application.Current.TryFindResource("SelectedCircleButton") as Style;
        }
    }

    private void DefaultStyleToAllCircleButton()
    {
        Monday.Style = Application.Current.TryFindResource("CircleButton") as Style;
        Tuesday.Style = Application.Current.TryFindResource("CircleButton") as Style;
        Wednesday.Style = Application.Current.TryFindResource("CircleButton") as Style;
        Thursday.Style = Application.Current.TryFindResource("CircleButton") as Style;
        Friday.Style = Application.Current.TryFindResource("CircleButton") as Style;
    }
}