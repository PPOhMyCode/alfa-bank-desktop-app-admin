using System;
using System.Windows;

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
        }

        public void ToOrderingIngredientsButtonClick(object sender, RoutedEventArgs e)
        {
            var window = new OrderingIngredientsWindow();
            Visibility = Visibility.Hidden;
            window.Show();
        }
    }
}