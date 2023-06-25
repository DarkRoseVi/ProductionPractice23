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
using ProviderWpf.Models;
using ProviderWpf.Pages;

namespace ProviderWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для AkkWindow.xaml
    /// </summary>
    public partial class AkkWindow : Window
    {
        public Manufacturer contextProvider;
        public AkkWindow()
        {
            InitializeComponent();
            contextProvider = HelpClass.AutoUset ;
            DataContext = contextProvider;
        }

        private void SavrBtn_Click(object sender, RoutedEventArgs e)
        {
            App.db.SaveChanges();
            MessageBox.Show("Сохранено");
            DialogResult = true;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
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
