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
    /// Логика взаимодействия для LaidingPage.xaml
    /// </summary>
    public partial class LaidingPage : Page
    {
        public LaidingPage()
        {
            InitializeComponent();
           
        }

        private void Reshres() 
        {
            LandinbgLw.ItemsSource = App.db.Shipment.Where(x => x.ManufacturerId == HelpClass.AutoUset.Id).ToList();
        }

        private void DeleBtn_Click(object sender, RoutedEventArgs e)
        {
            var land = (sender as Button).DataContext as Shipment;
            App.db.Shipment.Remove(land);
            App.db.SaveChanges();
            MessageBox.Show("Удалено");
            Reshres();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Reshres();
        }
    }
}
