using System.Windows;
using System.Windows.Controls;
using Desktop_Canteen.ViewModels;

namespace Desktop_Canteen.Views;

public partial class MakeMenuPage : Page
{
    private MakeMenuVM _makeMenuVm;
        public MakeMenuPage()
        {
            InitializeComponent();
            _makeMenuVm = new MakeMenuVM();
            DataContext = _makeMenuVm;
            _makeMenuVm.PlugTextBlock = this.Plug;

        }
    
        public void ToMenuPage(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new MenuPage());
        }
        
        public void ToOrderingIngredientsButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new OrderingIngredientsPage());
        }
            
        public void ToAllDishesButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AllDishesPage());
        }
        public void ToScheduleButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new SchedulePage());
        }
            
        public void ToChildrensButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ChildrensPage());
        }

        public void BreakfastButtonClick(object sender, RoutedEventArgs e)
        {
            BreakfastButton.Style = Application.Current.TryFindResource("SelectedTypeMealButton") as Style;
            DinnerButton.Style = Application.Current.TryFindResource("TypeMealButton") as Style;
            AfternoonSnackButton.Style = Application.Current.TryFindResource("TypeMealButton") as Style;
        }
        
        public void DinnerButtonClick(object sender, RoutedEventArgs e)
        {
            DinnerButton.Style = Application.Current.TryFindResource("SelectedTypeMealButton") as Style;
            BreakfastButton.Style = Application.Current.TryFindResource("TypeMealButton") as Style;
            AfternoonSnackButton.Style = Application.Current.TryFindResource("TypeMealButton") as Style;
        }
        
        public void AfternoonSnackButtonClick(object sender, RoutedEventArgs e)
        {
            AfternoonSnackButton.Style = Application.Current.TryFindResource("SelectedTypeMealButton") as Style;
            DinnerButton.Style = Application.Current.TryFindResource("TypeMealButton") as Style;
            BreakfastButton.Style = Application.Current.TryFindResource("TypeMealButton") as Style;
        }

        public void ChangeStyleCircleButton(object sender, RoutedEventArgs e)
        {
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
        
        public void ToMenuSetupPage(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new MenuSetup());
        }
}