using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
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
            DatePicker1.Language = XmlLanguage.GetLanguage(System.Globalization.CultureInfo.CurrentCulture.IetfLanguageTag);
            DatePicker2.Language = XmlLanguage.GetLanguage(System.Globalization.CultureInfo.CurrentCulture.IetfLanguageTag);
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
            Monday1.Style = Application.Current.TryFindResource("CircleButton") as Style;
            Tuesday1.Style = Application.Current.TryFindResource("CircleButton") as Style;
            Wednesday1.Style = Application.Current.TryFindResource("CircleButton") as Style;
            Thursday1.Style = Application.Current.TryFindResource("CircleButton") as Style;
            Friday1.Style = Application.Current.TryFindResource("CircleButton") as Style;
            Monday2.Style = Application.Current.TryFindResource("CircleButton") as Style;
            Tuesday2.Style = Application.Current.TryFindResource("CircleButton") as Style;
            Wednesday2.Style = Application.Current.TryFindResource("CircleButton") as Style;
            Thursday2.Style = Application.Current.TryFindResource("CircleButton") as Style;
            Friday2.Style = Application.Current.TryFindResource("CircleButton") as Style;
        }
}