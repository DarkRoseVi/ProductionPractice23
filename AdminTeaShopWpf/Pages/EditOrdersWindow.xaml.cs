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

namespace AdminTeaShopWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditOrdersWindow.xaml
    /// </summary>
    public partial class EditOrdersWindow : Window
    {
        public Order contextorder;
        public EditOrdersWindow(Order orders)
        {
            InitializeComponent();
           // ClientCb.ItemsSource = App.db.User.Where(x => x.RoleId == 4).ToList();
            EmployeeCb.ItemsSource = App.db.User.Where(x => x.RoleId == 2 || x.RoleId == 3).ToList();
            TypePaumentCb.ItemsSource = App.db.TypePaument.ToList();
            TypeOrderCb.ItemsSource = App.db.TypeOrder.ToList();
            TableCb.ItemsSource = App.db.Tabel.ToList();
            contextorder = orders;
            DataContext = contextorder;
     
        }

        private void TypePaumentCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var type = (TypePaumentCb.SelectedItem as TypePaument).Id;
            if (type == 1) 
            {
                ChecSt.Visibility = Visibility.Visible;
            }
            else ChecSt.Visibility = Visibility.Collapsed;
        }

        private void TypeOrderCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var type = (TypeOrderCb.SelectedItem as TypeOrder).Id;
            if(type != null) 
            {
            
            if (type ==1)
            {
                AdressSt.Visibility = Visibility.Visible;
                NubertableSt.Visibility = Visibility.Collapsed;
            }
            else if (type == 2)
            {
                AdressSt.Visibility = Visibility.Collapsed;
                NubertableSt.Visibility = Visibility.Visible;
            }
            }
        }

        private void EditProdBtn_Click(object sender, RoutedEventArgs e)
        {
            var pro = (sender as Button).DataContext as ProductOrder;
           var dialog= new EditStatusWindow(pro).ShowDialog();
            

        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var prod = (sender as Button).DataContext as ProductOrder;
            App.db.ProductOrder.Remove(prod);
            App.db.SaveChanges();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            App.db.SaveChanges();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if(ChekCb.IsChecked == true)
            {
                EmployeeCb.Visibility = Visibility.Visible;
            }
            else EmployeeCb.Visibility = Visibility.Collapsed;
        }
    }
}
