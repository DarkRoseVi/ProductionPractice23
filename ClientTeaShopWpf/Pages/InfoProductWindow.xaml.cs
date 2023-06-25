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
using System.Windows.Shapes;
using ClientTeaShopWpf.Models;

namespace ClientTeaShopWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для InfoProductWindow.xaml
    /// </summary>
    public partial class InfoProductWindow : Window
    {
        Product contextproduct;
        public InfoProductWindow(Product products)
        {
            InitializeComponent();
            contextproduct = products;
            DataContext = contextproduct;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
