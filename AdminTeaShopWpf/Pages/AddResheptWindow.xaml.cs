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
    /// Логика взаимодействия для AddResheptWindow.xaml
    /// </summary>
    public partial class AddResheptWindow : Window
    {
        Product contextProduct;
        public AddResheptWindow(Product products)
        {
            InitializeComponent();
            contextProduct = products;
            DataContext = contextProduct;
          var  ing = App.db.Recipe.Where(x => x.ProductId == contextProduct.Id).Select(x => x.Ingredient).Select(z=>z.Id);
                //App.db.Recipe.Where(x => x.ProductId == contextProduct.Id).Select(x => x.IngredientId).ToList();
            ingredietnCb.ItemsSource = App.db.Ingredient.Where(z => ing.Contains(z.Id) == false).ToList();
            TeaCb.ItemsSource = App.db.Recipe.Where(x => x.Id == contextProduct.Id).Select(x => x.Tea).ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            App.db.Recipe.Add(new Recipe
            {

                ProductId = contextProduct.Id,
                Tea = TeaCb.SelectedItem as Tea,
                Ingredient = ingredietnCb.SelectedItem as Ingredient,
                Count = int.Parse(CountTb.Text.Trim())
            }) ;
         
            App.db.SaveChanges();
            DialogResult = true;
        }

        private void EsitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void CountTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) 
            {
                e.Handled = true;
            }
        }
    }
}
