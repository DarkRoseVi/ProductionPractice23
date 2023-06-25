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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            string lastname = LastNameTb.Text.Trim();
            string name = NameTb.Text.Trim();
            string surname = SurNameTb.Text.Trim();
            string login = LoginBtn.Text.Trim();
            string password = PasswordTb.Text.Trim();

            if (lastname.Length > 0)
            {
                if (name.Length > 0)
                {
                    if (surname.Length > 0)
                    {
                        if (login.Length > 0)
                        {
                            if (password.Length > 0)
                            {
                                var users = App.db.User.Where(x => x.LastName == lastname && x.Name == name && x.SurName == surname).FirstOrDefault();
                                if (users == null)
                                {
                                    App.db.User.Add(new User
                                    {
                                        Password = password,
                                        Name = name,
                                        SurName = surname,
                                        LastName = lastname,
                                        Login = login,
                                    });
                                    App.db.SaveChanges();
                                    MessageBox.Show("Пользователь зарегистрирован");
                                    NavigationService.Navigate(new AutoPage());
                                }
                                else MessageBox.Show("Введенный данные уже имеются в системе");
                            }
                            else MessageBox.Show("Заполните поле пароля");
                        }
                        else MessageBox.Show("Заполните поле логина");
                    }
                    else MessageBox.Show("Заполните поле отчества");
                }
                else MessageBox.Show("Заполните поле имени");
            }
            else MessageBox.Show("Заполните поле фамилии");
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AutoPage());
        }

        private void LastNameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0)) 
            {
                e.Handled = true;
            }
        }

        private void NameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void SurNameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
