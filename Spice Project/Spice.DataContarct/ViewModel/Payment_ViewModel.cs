using Spice.DataContarct.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice.DataContarct.ViewModel
{
    public class Payment_ViewModel
    {
        public Payment_ViewModel()
        {
            Payment = new Payment_DataModel();
        }

        public Payment_DataModel Payment { get; set; }
    }
}
