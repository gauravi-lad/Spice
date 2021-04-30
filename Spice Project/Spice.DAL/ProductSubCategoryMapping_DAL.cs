using Spice.CommanUtilities;
using System.Collections.Generic;

namespace Spice.DAL
{
    public class ProductSubCategoryMapping_DAL
    {

        public string Insert(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("sp_insert_product_category_mapping", parameters);
        }

        public string Delete(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("sp_delete_product_subcategory_mapping", parameters);
        }



    }
}
