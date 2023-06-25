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
    /// Логика взаимодействия для AddIngredientWindow.xaml
    /// </summary>
    public partial class AddIngredientWindow : Window
    {
        public Ingredient contextingredient;
        public AddIngredientWindow(Ingredient ingredients)
        {
            InitializeComponent();
            ManufCb.ItemsSource = App.db.Manufacturer.ToList();
            contextingredient = ingredients;
            DataContext = contextingredient;

        }

        private void SavrBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(contextingredient.Title))
            {
                MessageBox.Show("Заполните поле названия ");
                return;
            }
            else if (contextingredient.Manufacturer == null)
            {
                MessageBox.Show("Выберите поставщика");
                return;
            }
            else
            {
                if (contextingredient.Id == 0)
                {
                    
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

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
