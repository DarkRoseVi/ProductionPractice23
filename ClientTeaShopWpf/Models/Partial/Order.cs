using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientTeaShopWpf.Models
{
   partial class Order
    {
        public Visibility Visbadress
        {
            get
            {
                if (Adress == null || Adress.Length == 0)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
        }

        public Visibility VisbTable
        {
            get
            {
                if (Tabel == null || Tabel.Id == 0)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
        }
        public Visibility VisType
        {
            get
            {
                if (TypePaymentId == 1)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }

        }
      
    }
}
