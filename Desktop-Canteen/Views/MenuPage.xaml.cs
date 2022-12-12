﻿using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Desktop_Canteen.ViewModels;
using WPFLibrary;

namespace Desktop_Canteen.Views
{
    public partial class MenuPage : Page
    {
        private MenuVM _menuVm;
        public MenuPage()
        {
            InitializeComponent();
            _menuVm = new MenuVM()
            {
                MenuPlugTextBlock = MenuPlug
            };
            _menuVm.GetMenu();
            DataContext = _menuVm;
            Monday.Style = Application.Current.TryFindResource("SelectedCircleButton") as Style;
            BreakfastButton.Style = Application.Current.TryFindResource("SelectedTypeMealButton") as Style;
        }
    
        public void ToMenuButtonClick(object sender, RoutedEventArgs e)
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
            Monday.Style = Application.Current.TryFindResource("CircleButton") as Style;
            Tuesday.Style = Application.Current.TryFindResource("CircleButton") as Style;
            Wednesday.Style = Application.Current.TryFindResource("CircleButton") as Style;
            Thursday.Style = Application.Current.TryFindResource("CircleButton") as Style;
            Friday.Style = Application.Current.TryFindResource("CircleButton") as Style;
        }
        
        public async  void ToMakeMenuPage(object sender, RoutedEventArgs e)
        {
            await Task.Delay(2000);
            NavigationService?.Navigate(new MakeMenuPage());
        }
    }
}