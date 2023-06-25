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
using ProviderWpf.Models;

namespace ProviderWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для StaticPage.xaml
    /// </summary>
    public partial class StaticPage : Page
    {
        public StaticPage()
        {
            InitializeComponent();
            var area = MainChart.ChartAreas.Add("MainArea");
        }

        private void Generetbtn_Click(object sender, RoutedEventArgs e)
        {
            var starts = StartDp.SelectedDate;
            var end = EndDp.SelectedDate;
            var chartDate = App.db.Shipment.Where(x => x.ManufacturerId == HelpClass.AutoUset.Id).ToList().Where(z => z.Date >= starts.Value && z.Date <= end)
                    .GroupBy(x => x.Date).ToDictionary(x => x.Key, vaule => vaule.Count()); ;

            var seria = MainChart.Series.Add("orders  sum");
            seria.Points.DataBindXY(chartDate.Keys, chartDate.Values);
        }
    }
}
