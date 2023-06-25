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
using ClientTeaShopWpf.Models;
using ClientTeaShopWpf.Pages;

namespace ClientTeaShopWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для AkkPage.xaml
    /// </summary>
    public partial class AkkPage : Page
    {
        public byte[] image;
        public User contextuser;
        public AkkPage()
        {
            InitializeComponent();
            contextuser = HelpClass.AutoUset;
            OrderLw.ItemsSource = App.db.Order.Where(s => s.ClientId == contextuser.Id).SelectMany(x => x.ProductOrder).Where(s => s.StatusId == 3).ToList();
            DataContext = contextuser;
            ChekLw.ItemsSource = App.db.Chek.Where(x => x.UserId == contextuser.Id).ToList();
        }
        public void Refresh()
        {
            contextuser = HelpClass.AutoUset;
            ChekLw.ItemsSource = App.db.Chek.Where(x => x.UserId == contextuser.Id).ToList();

        }
        private void EditInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new EditUserInfoWindow(contextuser).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ChekWindow(new Chek()).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Refresh();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var chek = (sender as Button).DataContext as Chek;
            var dialog = new ChekWindow(chek).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Refresh();
        }

        private void InfoOrrderBtn_Click(object sender, RoutedEventArgs e)
        {
            var prod = (sender as Button).DataContext as ProductOrder;
            var dialo = new UnfoOrderWindow(prod).ShowDialog();
            if (dialo.HasValue && dialo.Value)
                Refresh();
        }
    }
}
