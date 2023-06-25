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
using AdminTeaShopWpf.Pages;
using AdminTeaShopWpf.Models;


namespace AdminTeaShopWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для RiewReviewsWindow.xaml
    /// </summary>
    public partial class RiewReviewsWindow : Window
    {
        public Product contentProduct;
        public RiewReviewsWindow(Product products)
        {
            InitializeComponent();
            contentProduct = products;
            DataContext = contentProduct;
            ReviewLw.ItemsSource = App.db.Feedback.Where(x => x.ProductId == contentProduct.Id).ToList();
        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var reviewcont = (sender as Button).DataContext as Feedback;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.db.Feedback.Remove(reviewcont);
            }
            App.db.SaveChanges();
            ReviewLw.ItemsSource = App.db.Feedback.Where(x => x.ProductId == contentProduct.Id).ToList();
            DialogResult = true;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;

        }
    }
}
