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
using ProviderWpf.Models;
using ProviderWpf.Pages;

namespace ProviderWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для IngredientPage.xaml
    /// </summary>
    public partial class IngredientPage : Page
    {
        public IngredientPage()
        {
            InitializeComponent();
            Reahres();
        }
        private void Reahres()
        {
            IngredientDg.ItemsSource = App.db.Ingredient.Where(x=>x.ManufacturerId  == HelpClass.AutoUset.Id).ToList();
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddIngredientWindow(new Ingredient()).ShowDialog();
            if (dialog.HasValue && dialog.Value)
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Reahres();
        }
    }
}
