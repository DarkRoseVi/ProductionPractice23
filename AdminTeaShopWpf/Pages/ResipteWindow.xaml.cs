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
using AdminTeaShopWpf.Models;
using AdminTeaShopWpf.Pages;

namespace AdminTeaShopWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для ResipteWindow.xaml
    /// </summary>
    public partial class ResipteWindow : Window
    {
        Product contextproduct;
        public ResipteWindow(Product products)
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

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
          var dialog =  new AddResheptWindow(contextproduct).ShowDialog();
            if(dialog.HasValue && dialog.Value)
                ResheptLw.ItemsSource = App.db.Recipe.Where(x => x.ProductId == contextproduct.Id).ToList();
        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var ing = (sender as Button).DataContext as Recipe;
            App.db.Recipe.Remove(ing);
            MessageBox.Show("Удалено");
            App.db.SaveChanges();
            ResheptLw.ItemsSource = App.db.Recipe.Where(x => x.ProductId == contextproduct.Id).ToList();
        }
    }
}
