using Spice.CommanUtilities;
using System.Collections.Generic;

namespace Spice.DAL
{
    public class CustomerFavourites_DAL
    {

        public string Insert(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("Sp_ins_CustomerFavourites", parameters);
        }
        public string Get_Listing(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("Sp_lst_CustomerFavourites", parameters);
        }
        public string GetByID(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("Sp_get_id_CustomerFavourites", parameters);
        }
    }
}
