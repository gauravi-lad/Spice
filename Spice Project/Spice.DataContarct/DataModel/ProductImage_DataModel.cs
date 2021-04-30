using System;
using System.Web;

namespace Spice.DataContarct.DataModel
{
    public class ProductImage_DataModel
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public int ProductPriceSKU { get; set; }
        //public HttpPostedFileBase Image { get; set; }
        public string Image { get; set; }
        public string UniqueFileName { get; set; }
        public bool IsDefaultImage { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Createddate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime Updateddate { get; set; }

        public int ImageNo { get; set; }
    }
}
