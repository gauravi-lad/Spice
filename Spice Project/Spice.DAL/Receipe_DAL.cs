using Spice.CommanUtilities;
using System.Collections.Generic;

namespace Spice.DAL
{
    public class Receipe_DAL
    {

        public string Insert(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("Sp_ins_up_Receipe", parameters);
        }
        public string Get_Listing(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("Sp_lst_Receipe", parameters);
        }
        public string GetByID(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("Sp_get_id_Receipe", parameters);
        }
        public string DeleteByID(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("sp_delete_id_Receipe", parameters);
        }
        public string GetReceipeByProductId(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("Sp_get_productid_Receipe", parameters);
        }


    }
}
