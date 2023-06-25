using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminTeaShopWpf.Models
{
   partial class ProductOrder
    {
      
        public string Color
        {
            get
            {
                if (StatusId == 3)
                {
                    return "#90EE90";
                }
                else if (StatusId == 5)
                {
                    return "#FA8072";
                }
                else if (StatusId == 2)
                {
                    return "#7FFFD4";
                }
                else if (StatusId == 4)
                {
                    return "#ADFF2F";
                }
                else return "#FFFFFF";
            }
        }
    }
}
