using System;

namespace Spice.DataContarct.DataModel
{
    public class Product_DataModel
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Product_Short_Desc { get; set; }
        public string Product_Long_Desc { get; set; }
        public string Product_Features { get; set; }
        public bool IsActive { get; set; }
        //public int ManufacturedBy { get; set; }
        public bool IsRefundable { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsRecommended { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? Createddate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? Updateddate { get; set; }

        public string ProductImage1 { get; set; }
        public string ProductImage2 { get; set; }
        public string ProductImage3 { get; set; }
        public string ProductImage4 { get; set; }
        public string ProductImage5 { get; set; }

        public int Rating { get; set; }
        public string ProductImage { get; set; }
        public string UniqueFileName { get; set; }
  
        public string SubCategoryName { get; set; }
        public string MinPrice { get; set; }
        public string ProductSKUCode { get; set; }

        // Added By Trupti 23/01/2021
        public string OriginationAndHistory { get; set; }

        public string Types { get; set; }

        public string Appearance { get; set; }

        public string Constituents { get; set; }

        public string KnownInLanguage { get; set; }

        public string HealthBenefit { get; set; }

        public int CartFlag { get; set; }

        public string SkuId { get; set; }

    }


}

