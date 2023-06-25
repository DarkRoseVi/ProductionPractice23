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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClientTeaShopWpf.Models;
using ClientTeaShopWpf.Pages;

namespace ClientTeaShopWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для BasketPage.xaml
    /// </summary>
    public partial class BasketPage : Page
    {
        public BasketPage()
        {
            InitializeComponent();
            TypeOrderCb.ItemsSource = App.db.TypeOrder.ToList();
            TypePaumentCb.ItemsSource = App.db.TypePaument.ToList();
            ChekCb.ItemsSource = App.db.Chek.Where(x => x.UserId == HelpClass.AutoUset.Id).ToList();
            TeableCb.ItemsSource = App.db.Tabel.ToList();
            UserTb.Text = HelpClass.AutoUset.FullName;
            ProductLw.ItemsSource = HelpClass.prod;
            SumTb.Text = HelpClass.prod.Sum(x => x.Counts * x.Cost).ToString();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (HelpClass.prod != null && HelpClass.prod.Count > 0)
            {
                decimal summa;
                var typeorder = TypeOrderCb.SelectedItem as TypeOrder;
                if (typeorder != null) 
                {
                    if (typeorder.Id == 1) // доставка
                    {
                        var typapayment = TypePaumentCb.SelectedItem as TypePaument;
                        if (typapayment.Id == 1)//картой
                        {
                            var cheks = ChekCb.SelectedItem as Chek;
                            var cvv = cheks.CVC;
                            if (cvv == CVVTb.Text.Trim())
                            {
                                decimal sum = (decimal)HelpClass.prod.Sum(x => x.Counts * x.Cost);
                                if (cheks.Balance >= sum)
                                {
                                    cheks.Balance -= sum;
                                    Order neworder = new Order
                                    {
                                        Date = DatePc.SelectedDate,
                                        Adress = AdressTb.Text.Trim(),
                                        Chek = cheks.Number,
                                        ClientId = HelpClass.AutoUset.Id,
                                        EmployeeId = 3,
                                        TypePaymentId = 1,
                                        TypeOrderId = 1,
                                    };

                                    var random = new Random();
                                    App.db.Order.Add(neworder);
                                    neworder.Sum = HelpClass.prod.Sum(x => x.Counts * x.Cost);
                                    foreach(Product producrs in HelpClass.prod) 
                                    {
                                        string randinstring = new string(Enumerable.Repeat("1234567890", 13).Select(s => s[random.Next(s.Length)]).ToArray());
                                        App.db.ProductOrder.Add(
                                            new ProductOrder
                                            {
                                                Order = neworder,
                                                BarCode = randinstring,
                                                Product = producrs,
                                                StatusId = 1, 
                                                Count = producrs.Counts,
                                            });

                                    }
                                    MessageBox.Show("Заказ создан");
                                    App.db.SaveChanges();
                                }
                                else MessageBox.Show("На балансе недостаточно средтв");
                            }
                            else MessageBox.Show("CVV код не совпадает");
                        }
                        else // наличными
                        {
                            Order neworder = new Order
                            {
                                Date = DatePc.SelectedDate,
                                Adress = AdressTb.Text.Trim(),
                                ClientId = HelpClass.AutoUset.Id,
                                EmployeeId = 3,
                                TypePaymentId = 2,
                                TypeOrderId = 1,
                            };

                            var random = new Random();
                            App.db.Order.Add(neworder);
                            neworder.Sum = HelpClass.prod.Sum(x => x.Counts * x.Cost);
                            foreach (Product producrs in HelpClass.prod)
                            {
                                string randinstring = new string(Enumerable.Repeat("1234567890", 13).Select(s => s[random.Next(s.Length)]).ToArray());
                                App.db.ProductOrder.Add(
                                    new ProductOrder
                                    {
                                        Order = neworder,
                                        BarCode = randinstring,
                                        Product = producrs,
                                        StatusId = 1,
                                        Count = producrs.Counts,
                                    });

                            }
                            MessageBox.Show("Заказ создан");
                            App.db.SaveChanges();
                        }
                    }
                    else // в зале
                    {
                        var typapayment = TypePaumentCb.SelectedItem as TypePaument;
                        if (typapayment.Id == 1)//картой
                        {
                            var cheks = ChekCb.SelectedItem as Chek;
                            var cvv = cheks.CVC;
                            if (cvv == CVVTb.Text.Trim())
                            {
                                decimal sum = (decimal)HelpClass.prod.Sum(x => x.Counts * x.Cost);
                                if (cheks.Balance >= sum)
                                {
                                    cheks.Balance -= sum;
                                    Order neworder = new Order
                                    {
                                        Date = DatePc.SelectedDate,
                                        TableId =(TeableCb.SelectedItem as Tabel).Id,
                                        Chek = cheks.Number,
                                        ClientId = HelpClass.AutoUset.Id,
                                        EmployeeId = (TeableCb.SelectedItem as Tabel).EmployeeId,
                                        TypePaymentId = 1,
                                        TypeOrderId = 2,
                                    };

                                    var random = new Random();
                                    App.db.Order.Add(neworder);
                                    neworder.Sum = HelpClass.prod.Sum(x => x.Counts * x.Cost);
                                    foreach (Product producrs in HelpClass.prod)
                                    {
                                        string randinstring = new string(Enumerable.Repeat("1234567890", 13).Select(s => s[random.Next(s.Length)]).ToArray());
                                        App.db.ProductOrder.Add(
                                            new ProductOrder
                                            {
                                                Order = neworder,
                                                BarCode = randinstring,
                                                Product = producrs,
                                                StatusId = 1,
                                                Count = producrs.Counts,
                                            });

                                    }
                                    MessageBox.Show("Заказ создан");
                                    App.db.SaveChanges();
                                }
                                else MessageBox.Show("На балансе недостаточно средтв");
                            }
                            else MessageBox.Show("CVV код не совпадает");
                        }
                        else // наличными
                        {
                            Order neworder = new Order
                            {
                                Date = DatePc.SelectedDate,
                                TableId = (TeableCb.SelectedItem as Tabel).Id,
                                ClientId = HelpClass.AutoUset.Id,
                                EmployeeId = (TeableCb.SelectedItem as Tabel).EmployeeId,
                                TypePaymentId = 1,
                                TypeOrderId = 2,
                            };

                            var random = new Random();
                            App.db.Order.Add(neworder);
                            neworder.Sum = HelpClass.prod.Sum(x => x.Counts * x.Cost);
                            foreach (Product producrs in HelpClass.prod)
                            {
                                string randinstring = new string(Enumerable.Repeat("1234567890", 13).Select(s => s[random.Next(s.Length)]).ToArray());
                                App.db.ProductOrder.Add(
                                    new ProductOrder
                                    {
                                        Order = neworder,
                                        BarCode = randinstring,
                                        Product = producrs,
                                        StatusId = 1,
                                        Count = producrs.Counts,
                                    });

                            }
                            MessageBox.Show("Заказ создан");
                            App.db.SaveChanges();
                        }
                    }
                }
            }
            else MessageBox.Show("Корзина пуста");
        }

        private void TypeOrderCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selecttype = TypeOrderCb.SelectedItem as TypeOrder;
            if (selecttype.Id == 2)
            {
                AdrresSt.Visibility = Visibility.Collapsed;
                NumberSt.Visibility = Visibility.Visible;
            }
            else 
            {
                NumberSt.Visibility = Visibility.Collapsed;
                AdrresSt.Visibility = Visibility.Visible;
            }
        }

        private void TypePaumentCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selecttype = TypePaumentCb.SelectedItem as TypePaument;
            if (selecttype.Id == 1)
            {
                ChetSt.Visibility = Visibility.Visible;
              
            }
            else
            {
                ChetSt.Visibility = Visibility.Collapsed;
            }
        }

        private void CountTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void DeleBtn_Click(object sender, RoutedEventArgs e)
        {
            var prod = (sender as Button).DataContext as Product;
            HelpClass.prod.Remove(prod);
            ProductLw.Items.Refresh();
        }

        private void CVVTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) 
            {
                e.Handled = true;
            }
        }

    
      
    }
}
