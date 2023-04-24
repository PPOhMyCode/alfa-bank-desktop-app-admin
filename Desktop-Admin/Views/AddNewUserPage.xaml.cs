using System.Windows;
using System.Windows.Controls;
using Desktop_Admin.ViewModels;

namespace Desktop_Admin.Views;

public partial class AddNewUserPage : Page
{
    private AddNewUserVM _addNewUserVm;
    public AddNewUserPage()
    {
        InitializeComponent();
        _addNewUserVm = new AddNewUserVM()
        {
            CategoriesDockPanel = Categories,
            PlugAdditionalInformation = PlugAdditionalInformation,
            AdditionalInformationAboutChildren = AdditionalInformationAboutChildren,
            AdditionalInformationAboutClass = AdditionalInformationAboutClass,
            NoNeedAdditionalInformation = NoNeedAdditionalInformation,
            AddInfoExpander = AddInfoExpander
        };
        DataContext = _addNewUserVm;
    }
    
    public void ToReceiptsButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new ReceiptsPage());
    }
    
    public void ToScheduleButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new SchedulePage());
    }
    
    public void ToMakeClassButtonClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new MakeClassPage());
    }

    private void AddNewUser_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new MakeClassPage());
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

    private void SelectChildrenButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (Children.Visibility == Visibility.Visible)
        {
            Children.Visibility = Visibility.Hidden;
        }
        else
        {
            Children.Visibility = Visibility.Visible;
        }
    }

    private void SelectClassButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (Classes.Visibility == Visibility.Visible)
        {
            Classes.Visibility = Visibility.Hidden;
        }
        else
        {
            Classes.Visibility = Visibility.Visible;
        }
    }
}