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
    /// Логика взаимодействия для InfoIngredientWindow.xaml
    /// </summary>
    public partial class InfoIngredientWindow : Window
    {
        Recipe contextRecipe;
        public InfoIngredientWindow(Recipe recipec)
        {
            InitializeComponent();
            contextRecipe = recipec;
            DataContext = contextRecipe;
        }

        private void ExutBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
