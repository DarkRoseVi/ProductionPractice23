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
using WaiterWPF.Pages;
using WaiterWPF.Models;

namespace WaiterWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
            var user = HelpClass.AutoUset.Id;
            var contextorders = App.db.Order.Where(x => x.EmployeeId == user);
            OrderLw.ItemsSource = contextorders.ToList();
        }
    }
}
