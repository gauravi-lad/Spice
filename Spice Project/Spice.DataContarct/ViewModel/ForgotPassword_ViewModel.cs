using Spice.DataContarct.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice.DataContarct.ViewModel
{
    public class ForgotPassword_ViewModel
    {
        public ForgotPassword_ViewModel()
        {
            forgotPassword = new ForgotPassword_DataModel();

            customer = new CustomerMaster_DataModel();
        }

        public ForgotPassword_DataModel forgotPassword { get; set; }

        public CustomerMaster_DataModel customer { get; set; }

    }
}
