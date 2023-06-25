﻿using System;
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
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
           Myframe.NavigationService.Navigate(new ProductPage());
           
        }

        private void ProductBtn_Click(object sender, RoutedEventArgs e)
        {
            Myframe.NavigationService.Navigate(new ProductPage());
        }

        private void AkkBtn_Click(object sender, RoutedEventArgs e)
        {
            Myframe.NavigationService.Navigate(new AkkPage());
        }

        private void BasketBtn_Click(object sender, RoutedEventArgs e)
        {
            Myframe.NavigationService.Navigate(new BasketPage());
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            Myframe.NavigationService.Navigate(new OrderPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AutoPage());
        }
    }
}
