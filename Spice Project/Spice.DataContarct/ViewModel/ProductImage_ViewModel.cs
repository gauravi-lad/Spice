using Spice.DataContarct.DataModel;
using System.Collections.Generic;

namespace Spice.DataContarct.ViewModel
{
    public class ProductImage_ViewModel
    {
        public ProductImage_ViewModel()
        {
            ProductImage = new ProductImage_DataModel();
            lst_ProductImage = new List<ProductImage_DataModel>();
        }

        public ProductImage_DataModel ProductImage { get; set; }
        public List<ProductImage_DataModel> lst_ProductImage { get; set; }

    }
}
