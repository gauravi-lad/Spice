using Spice.DataContarct.DataModel;
using System.Collections.Generic;
using System.Configuration;
using System.Web;

namespace Spice.DataContarct.ViewModel
{
    public class FrontEndViewModel
    {
        public FrontEndViewModel()
        {
            BestSellerProductList = new List<Product_DataModel>();
            FeaturedProductList = new List<Product_DataModel>();
            RecentProductList = new List<Product_DataModel>();
            ProductDetails = new Product_DataModel();
            ProductPriceSKUList = new List<ProductPriceSKU_DataModel>();
            ProductImageList = new List<ProductImage_DataModel>();
            lst_CustomerRating = new List<CustomerRating_DataModel>();
            CustomerRating = new CustomerRating_DataModel();
            CustomerAddressList = new List<CustomerAddressMaster_DataModel>();
            ProductPriceSKU = new ProductPriceSKU_DataModel();
            customerAddresMaster = new CustomerAddressMaster_DataModel();
            MenuList = new List<Menu_DataModel>();
            ProductList = new List<Product_DataModel>();
            CategoryList = new List<CategoryMasterDataModel>();
        }

        public List<Product_DataModel> BestSellerProductList { get; set; }
        public List<Product_DataModel> FeaturedProductList { get; set; }
        public List<Product_DataModel> RecentProductList { get; set; }

        public Product_DataModel ProductDetails { get; set; }

        public List<ProductPriceSKU_DataModel> ProductPriceSKUList { get; set; }

        public List<ProductImage_DataModel> ProductImageList { get; set; }

        public List<CustomerRating_DataModel> lst_CustomerRating { get; set; }

        public CustomerRating_DataModel CustomerRating { get; set; }

        public string ProductImageDefaultPath = ConfigurationManager.AppSettings["ProductImage"].ToString();

        public List<CustomerAddressMaster_DataModel> CustomerAddressList { get; set; }

        public ProductPriceSKU_DataModel ProductPriceSKU { get; set; }

        public CustomerAddressMaster_DataModel customerAddresMaster { get; set; }

        public List<Menu_DataModel> MenuList { get; set; }

        public List<Product_DataModel> ProductList { get; set; }

        public List<CategoryMasterDataModel> CategoryList { get; set; }
    }
}
