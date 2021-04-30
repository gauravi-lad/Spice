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
            insert_Parameters.Add(new KeyValuePair<string, string>("@Customer_Name", Convert.ToString(Payment_Model.Customer_Name)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Mobile_No", Convert.ToString(Payment_Model.Mobile_No)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Email_ID", Convert.ToString(Payment_Model.Email_ID)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Cuurency", Convert.ToString(Payment_Model.Cuurency)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Order_Amount", Convert.ToString(Payment_Model.Order_Amount)));
            result = obj_Payment_DAL.Insert_Payment(insert_Parameters);
            return result;
        }
    }
}
