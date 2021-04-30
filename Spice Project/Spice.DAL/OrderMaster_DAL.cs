using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Spice.CommanUtilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice.DAL
{
   public class OrderMaster_DAL
    {
        public string Insert(string json_parameter)
        {
            return GeneralFunctionalities.Process_Insert_Json_Data("sp_ins_OrderMaster", json_parameter);
        }

        public string GetByID(List<KeyValuePair<string, string>> parameter)
        {
            return GeneralFunctionalities.Process_GetById_GetListing_Json_Data("sp_get_id_OrderMaster", parameter);
        }

        public string Get_Listing(List<KeyValuePair<string, string>> parameter)
        {
            return GeneralFunctionalities.Process_GetById_GetListing_Json_Data("sp_lst_OrderMaster", parameter);
        }

        public string Assign_Vendors(string json_parameter)
        {
            return GeneralFunctionalities.Process_Insert_Json_Data("sp_ins_Assign_Order_Vendors", json_parameter);
        }

        public string Update_Vendor_Delivery_Dates(string json_parameter)
        {
            return GeneralFunctionalities.Process_Insert_Json_Data("sp_ins_Update_Order_Delivery_Dates", json_parameter);
        }

        public string Update_Order_status(string json_parameter)
        {
            return GeneralFunctionalities.Process_Insert_Json_Data("sp_ins_Update_Order_status", json_parameter);
        }

        public string Update_Invoice_status(string json_parameter)
        {
            return GeneralFunctionalities.Process_Insert_Json_Data("sp_ins_Update_Invoice_status", json_parameter);
        }

        public string Get_Latest_Id_Order(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_get_Latest_Id_Order", parameters);
        }
    }
}
