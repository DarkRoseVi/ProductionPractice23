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
using System.Windows.Shapes;
using AdminTeaShopWpf.Models;
using AdminTeaShopWpf.Pages;

namespace AdminTeaShopWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProviderWindow.xaml
    /// </summary>
    public partial class AddProviderWindow : Window
    {
        public Manufacturer contextProvider;
        public AddProviderWindow(Manufacturer manufacturers)
        {
            InitializeComponent();
            contextProvider = manufacturers;
            DataContext = manufacturers;

        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SavrBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(contextProvider.Title))
            {
                MessageBox.Show("Заполните поле названия ");
                return;
            }
           else if (string.IsNullOrEmpty(contextProvider.Adress))
            {
                MessageBox.Show("Заполните поле адрес ");
                return;
            }
         else   if (string.IsNullOrEmpty(contextProvider.Number))
            {
                MessageBox.Show("Заполните поле телефон ");
                return;
            }
            else if (string.IsNullOrEmpty(contextProvider.Password))
            {
                MessageBox.Show("Заполните поле телефон ");
                return;
            }
            else if (string.IsNullOrEmpty(contextProvider.Login))
            {
                MessageBox.Show("Заполните поле телефон ");
                return;
            }
            else
            {
                if (contextProvider.Id == 0)
                {
                    App.db.Manufacturer.Add(contextProvider);
                }
                App.db.SaveChanges();
                MessageBox.Show("Сохранено");
                DialogResult = true;
            }
        }

        private void TitleTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0)) 
            {
                e.Handled = true;
            }
        }

        private void NumberTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
