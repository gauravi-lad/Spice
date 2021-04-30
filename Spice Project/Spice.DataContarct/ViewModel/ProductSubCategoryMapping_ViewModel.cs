using Spice.DataContarct.DataModel;
using System.Collections.Generic;

namespace Spice.DataContarct.ViewModel
{
    public class ProductSubCategoryMapping_ViewModel
    {
        public ProductSubCategoryMapping_ViewModel()
        {
            Product_sub_category_mapping = new ProductSubCategoryMapping_DataModel();
            lst_Product_sub_category_mapping = new List<ProductSubCategoryMapping_DataModel>();
        }

        public ProductSubCategoryMapping_DataModel Product_sub_category_mapping { get; set; }
        public List<ProductSubCategoryMapping_DataModel> lst_Product_sub_category_mapping { get; set; }

    }
}
