using NaukaApp.Secondary_Windows;
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

namespace NaukaApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow pw = new ProductWindow();
            pw.Show();
        }

        private void ProviderButton_Click(object sender, RoutedEventArgs e)
        {
            ProviderWindow pw = new ProviderWindow();
            pw.Show();
        }

        private void WarehouseButton_Click(object sender, RoutedEventArgs e)
        {
            WarehouseWindow ww = new WarehouseWindow();
            ww.Show();
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow ow = new OrderWindow();
            ow.Show();
        }
    }
}
