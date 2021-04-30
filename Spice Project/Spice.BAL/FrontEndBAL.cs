using Newtonsoft.Json;
using Spice.DAL;
using Spice.DataContarct.DataModel;
using System;
using System.Collections.Generic;

namespace Spice.BAL
{
    public class FrontEndBAL
    {
        readonly Product_DAL Product_DAL;
        readonly FrontEnd_DAL frontEnd_DAL;
        public FrontEndBAL()
        {
            Product_DAL = new Product_DAL();
            frontEnd_DAL = new FrontEnd_DAL();
        }

        public List<Product_DataModel> GetBestSellerProductList()
        {
            List<Product_DataModel> productList = JsonConvert.DeserializeObject<List<Product_DataModel>>(Product_DAL.GetBestSellerProductList());
            return productList;
        }

        public List<Product_DataModel> GetFeaturedProductList()
        {
            List<Product_DataModel> productList = JsonConvert.DeserializeObject<List<Product_DataModel>>(Product_DAL.GetFeaturedProductList());
            return productList;
        }

        public List<Product_DataModel> GetRecentProductList()
        {
            List<Product_DataModel> productList = JsonConvert.DeserializeObject<List<Product_DataModel>>(Product_DAL.GetRecentProductList());
            return productList;
        }

        public List<Menu_DataModel> GetMenuList()
        {
            List<Menu_DataModel> menuList = JsonConvert.DeserializeObject<List<Menu_DataModel>>(frontEnd_DAL.GetMenuList());
            return menuList;
        }

        public List<Product_DataModel> GetProductListByCategoryId(int CategoryId)
        {
            List<Product_DataModel> lst_ProductPriceSKU = new List<Product_DataModel>();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@CategoryId", Convert.ToString(CategoryId)));
            return lst_ProductPriceSKU = JsonConvert.DeserializeObject<List<Product_DataModel>>(Product_DAL.GetProductListByCategoryId(getByID_Parameters));
        }
    }
}
