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
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            Myframe.NavigationService.Navigate(new ProductPage());
        }

        private void ProductBtn_Click(object sender, RoutedEventArgs e)
        {
            Myframe.NavigationService.Navigate(new ProductPage());
        }

        private void IngredientBtn_Click(object sender, RoutedEventArgs e)
        {
            Myframe.NavigationService.Navigate(new ImgredientPage());

        }

        private void TeaBtn_Click(object sender, RoutedEventArgs e)
        {
            Myframe.NavigationService.Navigate(new TeaPage());
        }

        private void ProviderBtn_Click(object sender, RoutedEventArgs e)
        {
            Myframe.NavigationService.Navigate(new ProviderPage());
        }

        private void UserBtn_Click(object sender, RoutedEventArgs e)
        {
            Myframe.NavigationService.Navigate(new UsersPage());
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            Myframe.NavigationService.Navigate(new OrderPage());
        }

        private void StaticOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            Myframe.NavigationService.Navigate(new StaticPage());
        }

        private void StaticprodBtn_Click(object sender, RoutedEventArgs e)
        {
            Myframe.NavigationService.Navigate(new StaticPage1());
        }

        private void PostBtn_Click(object sender, RoutedEventArgs e)
        {
            Myframe.NavigationService.Navigate(new ShipmentPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AutoPage());
        }
    }
}
