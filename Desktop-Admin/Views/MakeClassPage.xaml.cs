using System.Windows;
using System.Windows.Controls;
using Desktop_Admin.ViewModels;

namespace Desktop_Admin.Views;

public partial class MakeClassPage : Page
{
    private MainViewModel _mainVM;
    public MakeClassPage()
    {
        InitializeComponent();
        _mainVM = new MainViewModel()
        {
            ClassesPanel = ClassesStackPanel,
            NoSelectedClassesTextBlock = NoSelectedClassesPlug
        };
        DataContext = _mainVM;
        _mainVM.CheckPlug();
        //var a = ItemsControl;
    }
    
    public void ToReceiptsButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new ReceiptsPage());
    }
    
    public void ToScheduleButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new SchedulePage());
    }
}