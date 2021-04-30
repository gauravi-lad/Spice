using Spice.DataContarct.DataModel;
using System.Collections.Generic;

namespace Spice.DataContarct.ViewModel
{
    public class Product_ViewModel
    {
        public Product_ViewModel()
        {
            Product = new Product_DataModel();
            lst_Product = new List<Product_DataModel>();
            lst_ProductCategory = new List<CategoryMasterDataModel>();
            drp_lst_ProductCategor = new List<CategoryMasterDataModel>();
            lst_ProductSubCategory = new List<SubCategory_DataModel>();
            _DocumentInfoList = new List<ProductImage_DataModel>();
        }

        public Product_DataModel Product { get; set; }
        public List<Product_DataModel> lst_Product { get; set; }
        public List<CategoryMasterDataModel> lst_ProductCategory { get; set; }
        public List<SubCategory_DataModel> lst_ProductSubCategory {get;set;}
        public List<ProductImage_DataModel> _DocumentInfoList { get; set; }
        public List<CategoryMasterDataModel> drp_lst_ProductCategor { get; set; }
    }
}
