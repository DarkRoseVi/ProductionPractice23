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

namespace AdminTeaShopWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShipmentPage.xaml
    /// </summary>
    public partial class ShipmentPage : Page
    {
        public ShipmentPage()
        {
            InitializeComponent();
            ShipmentLw.ItemsSource = App.db.Shipment.ToList();
            ProviderCb.ItemsSource = App.db.Manufacturer.ToList();
            var prov = ProviderCb.SelectedItem as Manufacturer;
            //IngredientCb.ItemsSource = App.db.Ingredient.Where(z=>z.ManufacturerId == prov.Id).ToList();
            //TeaCb.ItemsSource = App.db.Tea.Where(z => z.ManufacturerId == prov.Id).ToList();
          //  var ungredient = IngredientCb.SelectedItem as Ingredient;
          //    int count =int.Parse( CountTb.Text.Trim());

            //       SumTb.Text = Convert.ToString( count * ungredient.Count);
        }

        private void CountTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) 
            {
                e.Handled = true;
                    
                    }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
           
            var type = TypeProduct.SelectedItem as ComboBoxItem;
            if (type.Tag.ToString() == "1")
            {
                int qountiti = int.Parse(CountTb.Text.Trim());
                var tea = TeaCb.SelectedItem as Tea;
                tea.Count += qountiti;
          
                decimal sums = (decimal)(decimal.Parse(CountTb.Text.Trim()) * tea.Cost);
                App.db.Shipment.Add(
                new Shipment
                {
                    Date = DateDt.SelectedDate,
                    Count = int.Parse(CountTb.Text.Trim()),
                    Manufacturer = ProviderCb.SelectedItem as Manufacturer,
                    Tea = TeaCb.SelectedItem as Tea,
                    Sum = sums
                });
            App.db.SaveChanges();
                
            ShipmentLw.ItemsSource = App.db.Shipment.ToList();
            }
          else  if (type.Tag.ToString() == "2")
            {
                int qountiti = int.Parse(CountTb.Text.Trim());
                var ingred = IngredientCb.SelectedItem as Ingredient;
                ingred.Count += qountiti;

                decimal sums = (decimal)(decimal.Parse(CountTb.Text.Trim()) * ingred.Cost);

                App.db.Shipment.Add(
                new Shipment
                {
                    Date = DateDt.SelectedDate,
                    Count = int.Parse(CountTb.Text.Trim()),
                    Manufacturer = ProviderCb.SelectedItem as Manufacturer,
                    Ingredient = IngredientCb.SelectedItem as Ingredient,
                    Sum = sums
                }); ;
                App.db.SaveChanges();
                ShipmentLw.ItemsSource = App.db.Shipment.ToList();
            }

        }

        private void ProviderCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var prov = ProviderCb.SelectedItem as Manufacturer;
            IngredientCb.ItemsSource = App.db.Ingredient.Where(x => x.ManufacturerId == prov.Id).ToList();
        }

        private void TypeProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProviderCb.ItemsSource = App.db.Manufacturer.ToList();
            var prov = ProviderCb.SelectedItem as Manufacturer;
            var type = TypeProduct.SelectedItem as ComboBoxItem;
            if (type.Tag.ToString() == "1") 
            {
                TeaSt.Visibility = Visibility.Visible;
                IngredSt.Visibility = Visibility.Collapsed;
                TeaCb.ItemsSource = App.db.Tea.Where(z => z.ManufacturerId == prov.Id).ToList();
            }
            else if (type.Tag.ToString() == "2") 
            {
                TeaSt.Visibility = Visibility.Collapsed;
                IngredSt.Visibility = Visibility.Visible;
                IngredientCb.ItemsSource = App.db.Ingredient.Where(z => z.ManufacturerId == prov.Id).ToList();

            }
        }
    }
}
