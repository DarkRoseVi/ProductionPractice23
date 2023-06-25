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
using ProviderWpf.Pages;
using ProviderWpf.Models;
using Microsoft.Win32;
using System.IO;

namespace ProviderWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditTeaWindow.xaml
    /// </summary>
    public partial class EditTeaWindow : Window
    {
        public Tea contextTea;
        public EditTeaWindow(Tea newtea)
        {
            InitializeComponent();
            contextTea = newtea;
            DataContext = contextTea;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SavrBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(contextTea.Title))
            {
                MessageBox.Show("Заполните поле названия ");
                return;
            }
            else if (contextTea.Cost == null)
            {
                MessageBox.Show("Заполните поле стоимости");
                return;
            }
            else
            {
                if (contextTea.Id == 0)
                {
                    contextTea.ManufacturerId = HelpClass.AutoUset.Id;
                    App.db.Tea.Add(contextTea);
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

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                contextTea.Photo = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextTea;
            }
        }

        private void CostTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
