using System.Windows;
using System.Windows.Controls;
using Desktop_Admin.ViewModels;

namespace Desktop_Admin.Views;

public partial class ChildrenPage : Page
{
    private ChildrenVM _childrenVm;
    public ChildrenPage()
    {
        InitializeComponent();
        _childrenVm = new ChildrenVM();
        DataContext = _childrenVm;
    }

    public void ToMakeClassButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new MakeClassPage());
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
}