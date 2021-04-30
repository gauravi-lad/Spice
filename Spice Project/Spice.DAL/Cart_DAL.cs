using Spice.CommanUtilities;
using System.Collections.Generic;

namespace Spice.DAL
{
    public class Cart_DAL
    {
        public string Get_Listing(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("Sp_lst_Cart", parameters);
        }


        public string GetByID(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("Sp_get_id_Cart", parameters);
        }


        public string Insert(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("Sp_ins_upd_Cart", parameters);
        }

        public string DeleteCart(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("Sp_delete_cart", parameters);
        }
    }
}
