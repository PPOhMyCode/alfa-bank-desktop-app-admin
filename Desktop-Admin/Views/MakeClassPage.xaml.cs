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
        NavigationService?.Navigate(MainWindow.DictionaryPages["ReceiptsPage"]);
    }
    
    public void ToScheduleButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(MainWindow.DictionaryPages["SchedulePage"]) ;
    }

    private void SelectCategoriesButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (Categories.Visibility == Visibility.Visible)
        {
            Categories.Visibility = Visibility.Hidden;
        }
        else
        {
            Categories.Visibility = Visibility.Visible;
        }
    }

    private void DoneButton_OnClick(object sender, RoutedEventArgs e)
    {
        Categories.Visibility = Visibility.Hidden;
        this.Dispatcher.InvokeAsync(() =>
            {
                _mainVM.CheckPlug();
                _mainVM.ChangeClassView();
            }
        );
    }

    private void AddNewUser_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(MainWindow.DictionaryPages["UploadUsersFilePage"]);
    }
}