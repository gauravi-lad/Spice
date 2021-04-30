using Spice.CommanUtilities;
using System.Collections.Generic;

namespace Spice.DAL
{
    public class ProductPriceSKU_DAL
    {
        public string Insert(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("sp_ins_upt_productPriceSKU", parameters);
        }


        public string Get_Listing(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_lst_productPriceSKU", parameters);
        }


        public string GetByID(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("sp_get_id_productPriceSKU", parameters);
        }

        public string GetByProductID(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_get_ProductId_productPriceSKU", parameters);
        }
        
    }
}
