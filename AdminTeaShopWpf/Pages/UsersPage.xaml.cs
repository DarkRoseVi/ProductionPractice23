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
using AdminTeaShopWpf.Pages;
using AdminTeaShopWpf.Models;

namespace AdminTeaShopWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        Role roles; 
        public UsersPage()
        {
            InitializeComponent();
            roles = null;
        }

        public void Reshresh() 
        {

            IEnumerable<User> userslist = App.db.User.ToList();
            if (PoiskTb.Text == null)
                return;
            if (PoiskTb.Text.Length > 0) 
            {
                userslist = userslist.ToList().Where(x => x.Name.ToLower().StartsWith(PoiskTb.Text.Trim())
                || x.LastName.ToLower().StartsWith(PoiskTb.Text.Trim())
                || x.SurName.ToLower().StartsWith(PoiskTb.Text.Trim()));
            }
            if(roles == null)
                UsersDg.ItemsSource = userslist.ToList();
            else if( roles != null)
                UsersDg.ItemsSource = userslist.Where(x=>x.RoleId == roles.Id).ToList();
        }
        private void AdminBtn_Click(object sender, RoutedEventArgs e)
        {
            roles = App.db.Role.FirstOrDefault(x => x.Id == 1);
            Reshresh();
        }

        private void OfBtn_Click(object sender, RoutedEventArgs e)
        {
            roles = App.db.Role.FirstOrDefault(x => x.Id == 2);
            Reshresh();
        }

        private void CourerBtn_Click(object sender, RoutedEventArgs e)
        {
            roles = App.db.Role.FirstOrDefault(x => x.Id == 3);
            Reshresh();
        }

        private void ClientBtn_Click(object sender, RoutedEventArgs e)
        {
            roles = App.db.Role.FirstOrDefault(x => x.Id == 4);
            Reshresh();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var us = (sender as Button).DataContext as User;
            var dialog = new EditUserWindow(us).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reshresh();
        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var us = (sender as Button).DataContext as User;
            App.db.User.Remove(us);
            App.db.SaveChanges();
            MessageBox.Show("Пользователь удален");
            roles = null;
            Reshresh();

        }

        private void AllBtn_Click(object sender, RoutedEventArgs e)
        {
            UsersDg.ItemsSource = App.db.User.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new EditUserWindow(new User()).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reshresh();
        }
    }
}
