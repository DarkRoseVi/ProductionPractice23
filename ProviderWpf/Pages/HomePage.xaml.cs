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

namespace ProviderWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            Myframe.NavigationService.Navigate(new IngredientPage());
        }

        private void IngredientBtn_Click(object sender, RoutedEventArgs e)
        {
            Myframe.NavigationService.Navigate(new IngredientPage());
        }

        private void TeaBtn_Click(object sender, RoutedEventArgs e)
        {
            Myframe.NavigationService.Navigate(new TeaPage());
        }

        private void AkkBtn_Click(object sender, RoutedEventArgs e)
        {
            new AkkWindow().ShowDialog();
        }

        private void StaticprodBtn_Click(object sender, RoutedEventArgs e)
        {
            Myframe.NavigationService.Navigate(new StaticPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
           NavigationService.Navigate(new AutoPage());
        }

        private void Shipbtn_Click(object sender, RoutedEventArgs e)
        {
            Myframe.NavigationService.Navigate(new LaidingPage());
        }
    }
}
