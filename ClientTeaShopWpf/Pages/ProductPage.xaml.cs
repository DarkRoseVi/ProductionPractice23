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
using ClientTeaShopWpf.Pages;
using ClientTeaShopWpf.Models;

namespace ClientTeaShopWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
        }

        private void AddBasketBtn_Click(object sender, RoutedEventArgs e)
        {
            var prod = (sender as Button).DataContext as Product;
            if (prod.Count != null)
                HelpClass.prod.Add(prod);
            else MessageBox.Show("Данного продукта нет в наличии");
        }
        private void Reshres()
        {
            IEnumerable<Product> prodcutlist = App.db.Product.ToList();

            if (SortCb.SelectedIndex > 0)
            {
                if (SortCb.Tag == "1")
                    prodcutlist = prodcutlist.ToList();
                else if (SortCb.Tag == "2")
                    prodcutlist = prodcutlist.OrderBy(x => x.Cost); // возрастание
                else
                    prodcutlist = prodcutlist.OrderByDescending(x => x.Cost);// по убыванию 
            }

            if (PoiskTb.Text == null)
                return;

            if (PoiskTb.Text.Length > 0)
            {
                prodcutlist = prodcutlist.Where(z => z.Title.StartsWith(PoiskTb.Text));
            }
            ProdLw.ItemsSource = prodcutlist.ToList();
        }

        private void ViewReviewsBtn_Click(object sender, RoutedEventArgs e)
        {
            var prod = (sender as Button).DataContext as Product;
            new ViewReviewsWindow(prod).ShowDialog();
        }

        private void ResheptBtnBtn_Click(object sender, RoutedEventArgs e)
        {
            var prod = (sender as Button).DataContext as Product;
            new ResipeWindow(prod).ShowDialog();

        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reshres();
        }

        private void PoiskTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Reshres();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ProdLw.ItemsSource = App.db.Product.ToList();
        }

        private void IngoBtn_Click(object sender, RoutedEventArgs e)
        {
            var prod = (sender as Button).DataContext as Product;
            new InfoProductWindow(prod).ShowDialog();


        }
    }
}
