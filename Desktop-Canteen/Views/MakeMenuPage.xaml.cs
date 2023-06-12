using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using Desktop_Canteen.ViewModels;

namespace Desktop_Canteen.Views;

public partial class MakeMenuPage : Page
{
    private MakeMenuVM _makeMenuVm;
    public int SelectedPeriod;
        public MakeMenuPage()
        {
            InitializeComponent();
            _makeMenuVm = new MakeMenuVM();
            DataContext = _makeMenuVm;
            _makeMenuVm.PlugTextBlock = this.Plug;
            DatePicker1.Language = XmlLanguage.GetLanguage(System.Globalization.CultureInfo.CurrentCulture.IetfLanguageTag);
            DatePicker2.Language = XmlLanguage.GetLanguage(System.Globalization.CultureInfo.CurrentCulture.IetfLanguageTag);
        }
    
        public MakeMenuPage(int selectedPeriod)
        {
            InitializeComponent();
            _makeMenuVm = new MakeMenuVM(selectedPeriod);
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

        public void MenuButtonClick(object sender, RoutedEventArgs e)
        {
            Menu.Style = Application.Current.TryFindResource("TypeMealButton") as Style;
            DefaultMenu.Style = Application.Current.TryFindResource("TypeMealButton") as Style;
            
            (sender as Button).Style = Application.Current.TryFindResource("SelectedTypeMealButton") as Style;
        }
        
        public void ChangeStyleCircleButton(object sender, RoutedEventArgs e)
        {
            // DefaultStyleToAllCircleButton();
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
        
        // private void DefaultStyleToAllCircleButton()
        // {
        //     Monday.Style = Application.Current.TryFindResource("CircleButton") as Style;
        //     Tuesday.Style = Application.Current.TryFindResource("CircleButton") as Style;
        //     Wednesday.Style = Application.Current.TryFindResource("CircleButton") as Style;
        //     Thursday.Style = Application.Current.TryFindResource("CircleButton") as Style;
        //     Friday.Style = Application.Current.TryFindResource("CircleButton") as Style;
        // }
}