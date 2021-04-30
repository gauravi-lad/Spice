using System;
using System.Collections.Generic;

namespace Spice.DataContarct.DataModel
{
    public class ProductPriceSKU_DataModel
    {
        public ProductPriceSKU_DataModel()
        {
        
        }

        public int ProductPriceSKUId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public string SKU { get; set; }
        public decimal RatePerPc { get; set; }
        public int MinOrderQuantity { get; set; }
        public int MaxOrderQuantity { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? Createddate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? Updateddate { get; set; }
        public int Quantity { get; set; }  
        public string TotalPrice { get; set; }

    }

    public class ProdSkuinfo
    {
        public int ID { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public string SKU { get; set; }
        public decimal RatePerPc { get; set; }
        public int MinOrderQuantity { get; set; }
        public int MaxOrderQuantity { get; set; }
    }
}
