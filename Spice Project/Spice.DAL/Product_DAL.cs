using Spice.CommanUtilities;
using System.Collections.Generic;

namespace Spice.DAL
{
    public class Product_DAL
    {
        public string Get_Listing(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_lst_product", parameters);
        }

        public string Get_All_Categories(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_lst_category", parameters);
        }

        public string GetSubCategoryByCategoryID(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_get_Categoryid_lstSubCategory", parameters);
        }


        public string GetByID(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("sp_get_id_product", parameters);
        }

        //public string GetSubCategoryByCategoryID(List<KeyValuePair<string, string>> parameters)
        //{
        //    return GeneralFunctionalities.Process_GetById_Data_Single_Table("sp_get_Categoryid_lstSubCategory", parameters);
        //}


        public string Insert(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("sp_ins_upt_product", parameters);
        }

        public string DeleteExistingCategoryByProductId(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("sp_delete_product_subcategory_mapping", parameters);
        }

        public string Insert_Product_Sub_Category_Mapping(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("sp_insert_product_category_mapping", parameters);
        }

        public string Get_Listing_Of_Product_Category(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_lst_product_Category", parameters);
        }

        public string Get_Listing_Of_Product_Image(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_get_id_productImage", parameters);
        }



        public string GetBestSellerProductList()
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table(StoredProcedureEnum.sp_get_GetBestSellerProductList.ToString(), null);
        }

        public string GetFeaturedProductList()
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table(StoredProcedureEnum.sp_get_GetFeaturedProductList.ToString(), null);
        }

        public string GetRecentProductList()
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table(StoredProcedureEnum.sp_get_GetRecentProductList.ToString(), null);
        }

        public string GetProductListByCategoryId(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_get_GetProductListByCategoryId", parameters);
        }

        public string GetProductWithCategory(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_lst_productwithcategory", parameters);
        }
    }
}
