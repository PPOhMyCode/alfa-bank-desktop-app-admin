using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Desktop_Admin.ViewModels;
using Desktop_Admin.Views;

namespace Desktop_Admin
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