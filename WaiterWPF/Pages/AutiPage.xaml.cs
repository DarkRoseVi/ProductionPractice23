﻿using System;
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
using WaiterWPF.Pages;
using WaiterWPF.Models;

namespace WaiterWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutiPage.xaml
    /// </summary>
    public partial class AutiPage : Page
    {
        public AutiPage()
        {
            InitializeComponent();
        }

        private void VxodBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBtn.Text.Trim();
            string password = PasswordTb.Text.Trim();
            if (login.Length > 0)
            {
                if (password.Length > 0)
                {
                    var users = App.db.User.Where(z => z.Login == login && z.Password == password).FirstOrDefault();
                    if (users != null && users.RoleId == 2 || users.RoleId == 3)
                    {

                        HelpClass.AutoUset = users;
                        MessageBox.Show($"Добро пожаловать ");
                        NavigationService.Navigate(new HomePage());
                    }
                    else MessageBox.Show("Извините у вас нет прав для входа в систему");
                }
                else MessageBox.Show("Заполните поле пароля");
            }
            else MessageBox.Show("Заполните поле логина");

        }

   
    }
}
