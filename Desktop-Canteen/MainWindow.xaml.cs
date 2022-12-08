using System;
using System.Windows;
using Desktop_Canteen.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Desktop_Canteen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new AuthorizationPage();
        }
    }
}