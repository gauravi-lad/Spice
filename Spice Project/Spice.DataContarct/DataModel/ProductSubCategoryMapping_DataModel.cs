using System;

namespace Spice.DataContarct.DataModel
{
    public class ProductSubCategoryMapping_DataModel
    {
        public int ProductSubCategorymappingId { get; set; }
        public int ProductId { get; set; }
        public string CategoryId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
