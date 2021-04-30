using Spice.DAL;
using Spice.DataContarct.ViewModel;
using System;
using System.Collections.Generic;

namespace Spice.BAL
{
    public class ProductSubCategoryMapping_BAL
    {
        public ProductSubCategoryMapping_BAL()
        {
            Product_sub_category_mapping = new ProductSubCategoryMapping_DAL();
        }

        readonly ProductSubCategoryMapping_DAL Product_sub_category_mapping;

        public void Add(ProductSubCategoryMapping_ViewModel obj_ProductSubCategoryMappingVM)
        {
            //obj_ProductSubCategoryMappingVM.Product_sub_category_mapping.CategoryId.Split(',').Count();
            if (!string.IsNullOrEmpty(obj_ProductSubCategoryMappingVM.Product_sub_category_mapping.CategoryId))
            {
                string[] CategoryIdList = obj_ProductSubCategoryMappingVM.Product_sub_category_mapping.CategoryId.Split(',');

                List<KeyValuePair<string, string>> delete_By_Parameters = new List<KeyValuePair<string, string>>();

                delete_By_Parameters.Add(new KeyValuePair<string, string>("@Product_ID", Convert.ToString(obj_ProductSubCategoryMappingVM.Product_sub_category_mapping.ProductId)));
                Product_sub_category_mapping.Delete(delete_By_Parameters);

                foreach (var item in CategoryIdList)
                {
                    List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();

                    insert_Parameters.Add(new KeyValuePair<string, string>("@ID", Convert.ToString(obj_ProductSubCategoryMappingVM.Product_sub_category_mapping.ProductSubCategorymappingId)));
                    insert_Parameters.Add(new KeyValuePair<string, string>("@ProductId", Convert.ToString(obj_ProductSubCategoryMappingVM.Product_sub_category_mapping.ProductId)));
                    insert_Parameters.Add(new KeyValuePair<string, string>("@CategoryId", Convert.ToString(item)));
                    insert_Parameters.Add(new KeyValuePair<string, string>("@CreatedBy", Convert.ToString(obj_ProductSubCategoryMappingVM.Product_sub_category_mapping.CreatedBy)));
                    insert_Parameters.Add(new KeyValuePair<string, string>("@CreatedDate", Convert.ToString(obj_ProductSubCategoryMappingVM.Product_sub_category_mapping.CreatedDate)));
                    insert_Parameters.Add(new KeyValuePair<string, string>("@UpdatedBy", Convert.ToString(obj_ProductSubCategoryMappingVM.Product_sub_category_mapping.UpdatedBy)));
                    insert_Parameters.Add(new KeyValuePair<string, string>("@UpdatedDate", Convert.ToString(obj_ProductSubCategoryMappingVM.Product_sub_category_mapping.UpdatedDate)));

                    Product_sub_category_mapping.Insert(insert_Parameters);
                }
            }
        }




    }
}
