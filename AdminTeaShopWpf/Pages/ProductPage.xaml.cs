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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            //List<Tea> listtype = App.db.Tea.ToList();
            //listtype.Insert(0, new Tea { Title = "Все" });

            //SortCb.ItemsSource = listtype;
            //SortCb.SelectedIndex = 0;
            //SortCb.DisplayMemberPath = "Title";
        }
        private void Reshres()
        {
            IEnumerable<Product> prodcutlist = App.db.Product.ToList();

            if (SortCb.SelectedIndex > 0)
            {
                if (SortCb.Tag == "1")
                    prodcutlist = prodcutlist.ToList();
                else if(SortCb.Tag == "2")
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


   

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reshres();
        }

        private void ViewReviewsBtn_Click(object sender, RoutedEventArgs e)
        {
            var prod = (sender as Button).DataContext as Product;
            new RiewReviewsWindow(prod).ShowDialog();
        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var product = (sender as Button).DataContext as Product;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.db.Product.Remove(product);
            }
            App.db.SaveChanges();
            Reshres();
        }

        private void EditInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            var prod = (sender as Button).DataContext as Product;
            var dialog = new EditProductWindow(prod).ShowDialog();
            if(dialog.HasValue && dialog.Value)
                ProdLw.ItemsSource = App.db.Product.ToList();
        }

        private void ResheptBtnBtn_Click(object sender, RoutedEventArgs e)
        {
            var prod = (sender as Button).DataContext as Product;
            new ResipteWindow(prod).ShowDialog();
        }

        private void PoiskTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Reshres();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Reshres();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new EditProductWindow(new Product()).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                ProdLw.ItemsSource = App.db.Product.ToList();
        }
    }
}
