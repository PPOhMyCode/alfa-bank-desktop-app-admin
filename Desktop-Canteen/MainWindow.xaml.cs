using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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
        public static Dictionary<string, Page> DictionaryPages;
        public MainWindow()
        {
            InitializeComponent();
            DictionaryPages = new Dictionary<string, Page>()
            {
                {"Authorization",new AuthorizationPage()},
            };
            
            MainFrame.Content = DictionaryPages["Authorization"];
        }
    }
}