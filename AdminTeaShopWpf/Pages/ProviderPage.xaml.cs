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
    /// Логика взаимодействия для ProviderPage.xaml
    /// </summary>
    public partial class ProviderPage : Page
    {
        public ProviderPage()
        {
            InitializeComponent();
        }

        private void Reshres() 
        {
            ProviderDg.ItemsSource = App.db.Manufacturer.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Reshres();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var prov = (sender as Button).DataContext as Manufacturer;
            var dialog = new AddProviderWindow(prov).ShowDialog();
            if (dialog.HasValue && dialog.Value)
            Reshres();
        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var prov = (sender as Button).DataContext as Manufacturer;
            App.db.Manufacturer.Remove(prov);
            MessageBox.Show("Удалено");
            App.db.SaveChanges();
                Reshres();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
  
            var dialog = new AddProviderWindow(new Manufacturer()).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reshres();
        }
    }
}
