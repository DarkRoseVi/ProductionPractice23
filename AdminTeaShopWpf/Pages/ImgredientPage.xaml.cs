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
    /// Логика взаимодействия для ImgredientPage.xaml
    /// </summary>
    public partial class ImgredientPage : Page
    {
        public ImgredientPage()
        {
            InitializeComponent();
            Reahres();
        }
        private void Reahres()
        {
            IngredientDg.ItemsSource = App.db.Ingredient.ToList();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Reahres();
        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var ing = (sender as Button).DataContext as Ingredient;
            App.db.Ingredient.Remove(ing);
            MessageBox.Show("Удалено");
            App.db.SaveChanges();
            Reahres();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var ingredient = (sender as Button).DataContext as Ingredient;
            var dialog = new AddIngredientWindow(ingredient).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reahres();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddIngredientWindow(new Ingredient()).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reahres();
        }
    }
}
