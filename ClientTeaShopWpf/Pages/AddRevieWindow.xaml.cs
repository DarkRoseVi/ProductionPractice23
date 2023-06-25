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
using ClientTeaShopWpf.Pages;
using ClientTeaShopWpf.Models;

namespace ClientTeaShopWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddRevieWindow.xaml
    /// </summary>
    public partial class AddRevieWindow : Window
    {
        ProductOrder contextproductorder;
        public AddRevieWindow(ProductOrder productorders)
        {
            InitializeComponent();
            contextproductorder = productorders;
            DataContext = contextproductorder;
            UserTb.Text = contextproductorder.Order.User.FullName;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            App.db.Feedback.Add(new Feedback
            {
                UserId = contextproductorder.Order.User.Id,
                ProductId = contextproductorder.Product.Id,
                Context = ContextTb.Text.Trim(),
            });
            App.db.SaveChanges();
            MessageBox.Show("Сохранить");
            DialogResult = true;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
