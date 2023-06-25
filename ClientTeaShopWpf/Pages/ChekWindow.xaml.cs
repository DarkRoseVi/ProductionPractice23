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
using ClientTeaShopWpf.Models;
using ClientTeaShopWpf.Pages;

namespace ClientTeaShopWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChekWindow.xaml
    /// </summary>
    public partial class ChekWindow : Window
    {
        public Chek contextchek;
        public ChekWindow(Chek chek)
        {
            InitializeComponent();
            BankCb.ItemsSource = App.db.Bank.ToList();
            contextchek = chek;
            DataContext = contextchek;
            contextchek.UserId = HelpClass.AutoUset.Id;
        }

        private void NumberTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void CSVTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(contextchek.Number) && contextchek.Number.Length == 16)
            {
                MessageBox.Show("Заполните поле номера");
                return;
            }

            else if (string.IsNullOrEmpty(contextchek.CVC))
            {
                MessageBox.Show("Заполните поле CVV");
                return;
            }

            else if (contextchek.Age == null)
            {
                MessageBox.Show("Заполните поле года");
                return;
            }
            else if (contextchek.Bank == null)
            {
                MessageBox.Show("Выберете банк");
                return;
            }
            else
            {
                if (contextchek.Id == 0)
                {
                    App.db.Chek.Add(contextchek);
                }
                MessageBox.Show("Счет сохранен ");
                App.db.SaveChanges();
                DialogResult = true;

            }

        }

        private void BalanseTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) 
            {
                e.Handled = true;
            }
        }
    }
}
