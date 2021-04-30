using Spice.DAL;
using Spice.DataContarct.DataModel;
using Spice.DataContarct.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice.BAL
{
    public class Payment_BAL
    {
        public Payment_BAL()
        {
            obj_Payment_DAL = new Payment_DAL();
        }

        Payment_DAL obj_Payment_DAL;

        public string Insert_Payment(Payment_DataModel Payment_Model)
        {
            string result = "";
            List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();
            insert_Parameters.Add(new KeyValuePair<string, string>("@Id", Convert.ToString(Payment_Model.Id)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Order_ID", Convert.ToString(Payment_Model.Order_ID)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Customer_ID", Convert.ToString(Payment_Model.Customer_ID)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@PayPal_Payment_ID", Convert.ToString(Payment_Model.PayPal_Payment_ID)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Payment_Method", Convert.ToString(Payment_Model.Payment_Method)));
            result = obj_Payment_DAL.Insert_Payment(insert_Parameters);
            return result;
        }
    }
}
