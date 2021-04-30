using Spice.CommanUtilities;
using System.Collections.Generic;

namespace Spice.DAL
{
    public class SubCategory_DAL
    {

        public string Insert_Update(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("sp_ins_upt_sub_category", parameters);
        }

        public string Get_Listing(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_lst_sub_category", parameters);
        }

        public string GetByID(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("sp_get_id_sub_category", parameters);
        }

        public string Delete_SubCategory(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("sp_delete_sub_category", parameters);
        }

        public string GetSubCategoryListByCategoryId(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_get_allSubCategoryByCategoryId", parameters);
        }

        public string UpdateSubCategoryImage(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("sp_Update_SubCategory_Image", parameters);
        }

        public string CheckSubCategoryExist(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("sp_CheckExisting_SubCategoryCode", parameters);
        }
    }
}
