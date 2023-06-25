using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTeaShopWpf.Models
{
   partial class Product
    {
        public string FullInfo 
        {

            get 
            {
                return Title ;
            }
        }
        public string CostInfo 
        {
            get
            {
                return "Стоимость за 100 г.     "  + Cost + "руб.";
            }
        
        }
    }
}
