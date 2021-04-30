using Spice.CommanUtilities;
using System.Collections.Generic;

namespace Spice.DAL
{
    public class ProductImage_DAL
    {
        public string Insert(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("sp_ins_productImage", parameters);
        }

        public string Update(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("sp_upt_productImage", parameters);
        }

        public string GetProductImageListById(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_get_ProductId_ProductImage", parameters);
        }


    }
}
