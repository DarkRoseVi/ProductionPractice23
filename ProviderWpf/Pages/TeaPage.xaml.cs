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
    /// Логика взаимодействия для TeaPage.xaml
    /// </summary>
    public partial class TeaPage : Page
    {
        public TeaPage()
        {
            InitializeComponent();
        }
        private void Reahres()
        {
            TeaDg.ItemsSource = App.db.Tea.Where(x=>x.ManufacturerId == HelpClass.AutoUset.Id).ToList();
        }
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var tea = (sender as Button).DataContext as Tea;
            var dialog = new EditTeaWindow(tea).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reahres();
        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var tea = (sender as Button).DataContext as Tea;
            App.db.Tea.Remove(tea);
            App.db.SaveChanges();
            MessageBox.Show("чай был удален");
            Reahres();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new EditTeaWindow(new Tea()).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reahres();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Reahres();
        }
    }
}
