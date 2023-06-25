using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTeaShopWpf.Models
{
    partial class Product
    {
        public string FullInfo
        {

            get
            {
                return Title;
            }
        }
        public string CostInfo
        {
            get
            {
                return "Стоимость за 100 г.     " + Cost + "руб.";
            }

        }
        private int _counts = 1;

        public int Counts
        {
            get { return _counts; }
            set { _counts = value; }
        }
    }
}
