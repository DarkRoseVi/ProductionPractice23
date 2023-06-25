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
using Microsoft.Win32;
using ProviderWpf.Models;
using ProviderWpf.Pages;

namespace ProviderWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddIngredientWindow.xaml
    /// </summary>
    public partial class AddIngredientWindow : Window
    {
        public Ingredient contextingredient;
        public AddIngredientWindow(Ingredient ingredients)
        {
            InitializeComponent();
            contextingredient = ingredients;
            DataContext = contextingredient;
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                contextingredient.Photo = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextingredient;
            }
        }

        private void SavrBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(contextingredient.Title))
            {
                MessageBox.Show("Заполните поле названия ");
                return;
            }
           
            else if(contextingredient.Cost == null)
            {
                MessageBox.Show("Заполните поле стоимости");
                return;
            }
            else
            {
                if (contextingredient.Id == 0)
                {
                    contextingredient.ManufacturerId = HelpClass.AutoUset.Id;
                    App.db.Ingredient.Add(contextingredient);
                }
                App.db.SaveChanges();
                MessageBox.Show("Сохранено");
                DialogResult = true;
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;

        }

        private void TitleTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0)) 
            {
                e.Handled = true;
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
