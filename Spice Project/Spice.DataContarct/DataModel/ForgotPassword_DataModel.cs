using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice.DataContarct.DataModel
{
    public class ForgotPassword_DataModel
    {
        public string MobileNo { get; set; }

        public string OTP { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }

        public bool IsVerify { get; set; }
    }
}
