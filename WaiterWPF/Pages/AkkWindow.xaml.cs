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
using WaiterWPF.Models;
using WaiterWPF.Pages;

namespace WaiterWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для AkkWindow.xaml
    /// </summary>
    public partial class AkkWindow : Window
    {
        public User cintextuser;
        public AkkWindow()
        {
            InitializeComponent();
            cintextuser = HelpClass.AutoUset;
            DataContext = cintextuser;
        }

        private void SavrBtn_Click(object sender, RoutedEventArgs e)
        {
            App.db.SaveChanges();
            MessageBox.Show("Сохранено");
            DialogResult = true;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                cintextuser.Photo = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = cintextuser;
            }
        }
    }
}
