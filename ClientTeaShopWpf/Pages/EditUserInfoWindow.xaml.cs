using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using ClientTeaShopWpf.Pages;
using ClientTeaShopWpf.Models;

namespace ClientTeaShopWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditUserInfoWindow.xaml
    /// </summary>
    public partial class EditUserInfoWindow : Window
    {
        User contextuser;
        public EditUserInfoWindow(User users)
        {
            InitializeComponent();
            contextuser = users;
            DataContext = contextuser;
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                contextuser.Photo = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextuser;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            App.db.SaveChanges();
            DialogResult = true;
        }

        private void EsitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
