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
using AdminTeaShopWpf.Models;
using System.Diagnostics;

namespace AdminTeaShopWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для StaticPage1.xaml
    /// </summary>
    public partial class StaticPage1 : Page
    {
        public StaticPage1()
        {
            InitializeComponent();
            //CourierCb.ItemsSource = App.db.Useer.Where(x => x.RoleId == 2).ToList();
            //CourierCb.DisplayMemberPath = "Fullname";
            var are = MainChart.ChartAreas.Add("MainArea");  
            //var are1 = MainChart.ChartAreas.Add("MainArea");
        }

        private void Generetbtn_Click(object sender, RoutedEventArgs e)
        {
          //  var courer = CourierCb.SelectedItem as Useer;
            var charDate = App.db.ProductOrder.Where(x => x.StatusId ==1).Select(x=>x.Order).GroupBy(x => x.Date).ToDictionary(key => key.Key, vaule => vaule.Count());
            var seria = MainChart.Series.Add("orders seria");
            seria.Points.DataBindXY(charDate.Keys, charDate.Values);
            var Date = App.db.ProductOrder.Where(x => x.StatusId == 3).Select(x => x.Order).GroupBy(x => x.Date).ToDictionary(key => key.Key, vaule => vaule.Count());
            var sears = MainChart.Series.Add(" seria");
           // sears.Color = Red;
            seria.Points.DataBindXY(Date.Keys, Date.Values);

        }
    }
}
