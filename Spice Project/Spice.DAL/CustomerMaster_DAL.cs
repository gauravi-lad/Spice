using Spice.CommanUtilities;
using System.Collections.Generic;

namespace Spice.DAL
{
    public class CustomerMaster_DAL
    {
        public string Get_Listing(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_lst_customer_master", parameters);
        }


        public string GetByID(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("sp_get_id_customer_master", parameters);
        }


        public string Insert(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("sp_ins_upt_customer_master", parameters);
        }

        public string Change_Password(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("Sp_UPD_Change_Password", parameters);
        }

        public string GetCountries(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_lst_country", parameters);
        }
    }
}
