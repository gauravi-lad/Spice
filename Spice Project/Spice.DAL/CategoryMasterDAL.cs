using Spice.CommanUtilities;
using System.Collections.Generic;

namespace Spice.DAL
{
    public class CategoryMasterDAL
    {
        public string GetCategoryList(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_get_allCategory", parameters);
        }


        public string GetByCategoryId(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("sp_get_categoryId", parameters);
        }


        public string InsertCategory(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("sp_insert_update_Category", parameters);
        }

        public string UpdateCategoryImage(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("sp_Update_Category_Image", parameters);
        }

        public string CheckCategoryExist(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("sp_CheckExisting_CategoryCode", parameters);
        }
    }
}
