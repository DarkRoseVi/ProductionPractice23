using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaiterWPF.Models
{
   partial class User
    {
        public string FullName
        {

            get
            {
                return LastName + " " + Name + " " + SurName;
            }
        }
    }
}
