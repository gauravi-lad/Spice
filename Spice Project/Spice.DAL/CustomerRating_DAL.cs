using Spice.CommanUtilities;
using System.Collections.Generic;

namespace Spice.DAL
{
    public class CustomerRating_DAL
    {
        public string Insert(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("Sp_ins_CustomerRating", parameters);
        }
        public string Get_Listing(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("Sp_lst_CustomerRating", parameters);
        }
        public string GetByID(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("Sp_get_id_CustomerRating", parameters);
        }

        public string Get_ListingByProductId(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("Sp_get_ProductId_CustomerRating", parameters);
        }

    }
}
