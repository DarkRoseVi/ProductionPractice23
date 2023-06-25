using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminTeaShopWpf.Models
{
    partial class Shipment
    {
        public Visibility VisiblIng
        {
            get
            {
                if (Ingredient == null || IngredientId == 0)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
        }

        public Visibility VisiblTea
        {
            get
            {
                if (Tea == null || TeaId == 0)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
        }
    }
}
