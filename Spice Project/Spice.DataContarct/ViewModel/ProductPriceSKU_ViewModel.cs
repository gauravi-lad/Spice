using Spice.DataContarct.DataModel;
using System.Collections.Generic;

namespace Spice.DataContarct.ViewModel
{
    public class ProductPriceSKU_ViewModel
    {
        public ProductPriceSKU_ViewModel()
        {
            ProductPriceSKU = new ProductPriceSKU_DataModel();
            lst_ProductPriceSKU = new List<ProductPriceSKU_DataModel>();
            lst_Product = new List<Product_DataModel>();
            
        }
        public ProductPriceSKU_DataModel ProductPriceSKU { get; set; }
        public List<ProductPriceSKU_DataModel> lst_ProductPriceSKU { get; set; }
        public List<Product_DataModel> lst_Product { get; set; }
        

    }
}
