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
using AdminTeaShopWpf.Models;
using AdminTeaShopWpf.Pages;


namespace AdminTeaShopWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
           
        }
        private void Reshres()
        {
            OrderLw.ItemsSource = App.db.Order.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var ord = (sender as Button).DataContext as Order;
            var dialog = new EditOrdersWindow(ord).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reshres();
        }

        private void DeleBtn_Click(object sender, RoutedEventArgs e)
        {
            var orders = (sender as Button).DataContext as Order;
            App.db.Order.Remove(orders);
            App.db.SaveChanges();
            MessageBox.Show("Заказ удален");
            Reshres();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Reshres();
        }
    }
}
