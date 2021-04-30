using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice.DataContarct.DataModel
{
    public class Payment_DataModel
    {
        public string Customer_Name { get; set; }
        public string Mobile_No { get; set; }
        public string Email_ID { get; set; }
        public string Order_Amount { get; set; }
        public int Cuurency { get; set; }

        public int Id { get; set; }
        public int Order_ID { get; set; }
        public int Customer_ID { get; set; }
        public string PayPal_Payment_ID { get; set; }
        public int Payment_Method { get; set; } = 1;
        

    }
}
