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
using AdminTeaShopWpf.Models;
using AdminTeaShopWpf.Pages;
using Microsoft.Win32;

namespace AdminTeaShopWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        public User contextUser;

        public EditUserWindow(User users)
        {
            InitializeComponent();
            RoleTb.ItemsSource = App.db.Role.ToList();
            contextUser = users;
            DataContext = contextUser;
          
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(contextUser.LastName)) 
            {
                MessageBox.Show("Заполните поле фамилии");
                return;
            }
            else if (string.IsNullOrEmpty(contextUser.Name))
            {
                MessageBox.Show("Заполните поле имени");
                return;
            }
            else if (string.IsNullOrEmpty(contextUser.SurName))
            {
                MessageBox.Show("Заполните поле отчества");
                return;
            }
            else if (string.IsNullOrEmpty(contextUser.Login))
            {
                MessageBox.Show("Заполните поле логина");
                return;
            }
            else if (string.IsNullOrEmpty(contextUser.Password))
            {
                MessageBox.Show("Заполните поле пароля");
                return;
            }
            else if (contextUser.Role == null )
            {
                MessageBox.Show("Выберете роль");
                return;
            }
            else 
            {

                if (contextUser.Id == 0) 
                {
                    App.db.User.Add(contextUser);
                }
                App.db.SaveChanges();
                MessageBox.Show("Сохранено");
                DialogResult = true;
            }
        }

        private void EsitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                contextUser.Photo = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextUser;
            }
        }
    }
}
