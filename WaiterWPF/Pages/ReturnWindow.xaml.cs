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
using WaiterWPF.Pages;
using WaiterWPF.Models;

namespace WaiterWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReturnWindow.xaml
    /// </summary>
    public partial class ReturnWindow : Window
    {
        public ReturnWindow()
        {
            InitializeComponent();
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            var barcode = BarcodeTb.Text.Trim();
            if (barcode.Length > 0)
            {
                var barcodebd = App.db.ProductOrder.Where(z => z.BarCode == barcode && z.StatusId == 4).FirstOrDefault();
                barcodebd.StatusId = 5;
                MessageBox.Show("Товар возвращен в связи с отказом клиента");
                App.db.SaveChanges();
            }
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void BarcodeTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            var barcode = BarcodeTb.Text.Trim();
            var barcodebd = App.db.ProductOrder.Where(z => z.BarCode == barcode && z.StatusId == 4).FirstOrDefault();
            if (barcode.Length == 13)
            {


                if (barcodebd != null)
                {
                    NumberBtn.Text = barcodebd.OrderId.ToString();
                    UserBtn.Text = barcodebd.Order.User1.Name.ToString() + " " + barcodebd.Order.User1.LastName.ToString();
                    NameTb.Text = barcodebd.Product.Title.ToString();
                    if (barcodebd.Order.Chek != null)
                    {
                        var us = App.db.Chek.FirstOrDefault(x => x.UserId == barcodebd.Order.User1.Id);
                        us.Balance += barcodebd.Product.Cost;
                    }


                }
                else
                {

                    var productOrder = App.db.ProductOrder.FirstOrDefault(x => x.BarCode == barcode);
                    string status = "";
                    if (productOrder != null)
                    {
                        status = productOrder.Status.Title.ToString();
                        MessageBox.Show($"Продукт имеет статус{status}");
                    }
                    else MessageBox.Show("Такого заказа нет");
                }
            }
        }

        private void BarcodeTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
