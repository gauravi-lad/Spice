using Spice.CommanUtilities;
using System.Collections.Generic;

namespace Spice.DAL
{
    public class CustomerAddressMaster_DAL
    {
        public string Get_Listing(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_lst_customer_address", parameters);
        }


        public string GetByID(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("sp_get_id_customer_address", parameters);
        }


        public string Insert(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("sp_ins_upt_customer_address", parameters);
        }

        public string DeleteByID(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("sp_delete_id_customer_address", parameters);
        }

        public string Get_Listing_By_Id(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_get_id_customer_address_by_id", parameters);
        }
        public string Get_OrderListing_By_Id(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_get_id_customer_order_by_id", parameters);
        }
    }
}
