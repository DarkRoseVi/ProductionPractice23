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
            string title = TitleTb.Text.Trim();
            string adres = AdressTb.Text.Trim();
            string number = NumberTb.Text.Trim();
            string login = LoginBtn.Text.Trim();
            string password = PasswordTb.Text.Trim();

            if (title.Length > 0)
            {
                if (adres.Length > 0)
                {
                    if (number.Length > 0)
                    {
                        if (login.Length > 0)
                        {
                            if (password.Length > 0)
                            {
                                var users = App.db.Manufacturer.Where(x => x.Adress == adres && x.Title == title ).FirstOrDefault();
                                if (users == null)
                                {
                                    App.db.Manufacturer.Add(new Manufacturer
                                    {
                                        Password = password,
                                        Title = title,
                                       Adress = adres,
                                       Number = number,
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
                    else MessageBox.Show("Заполните поле телефона");
                }
                else MessageBox.Show("Заполните поле адреса");
            }
            else MessageBox.Show("Заполните поле названия");
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AutoPage());
        }

        private void NumberTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) 
            {
                e.Handled = true;
            }
        }

       

      

        private void TitleTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
