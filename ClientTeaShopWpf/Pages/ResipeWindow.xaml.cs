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
    /// Логика взаимодействия для ResipeWindow.xaml
    /// </summary>
    public partial class ResipeWindow : Window
    {
        Product contextproduct;
        public ResipeWindow(Product products)
        {
            InitializeComponent();
            contextproduct = products;
            DataContext = contextproduct;

            ResheptLw.ItemsSource = App.db.Recipe.Where(x => x.ProductId == contextproduct.Id).ToList();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void InfoBtn_Click(object sender, RoutedEventArgs e)
        {
            var s = (sender as Button).DataContext as Recipe;
            new InfoIngredientWindow(s).ShowDialog();
        }
    }
}
