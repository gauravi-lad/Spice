using Newtonsoft.Json;
using Spice.DAL;
using Spice.DataContarct.DataModel;
using Spice.DataContarct.ViewModel;
using System;
using System.Collections.Generic;

namespace Spice.BAL
{
    public class ProductPriceSKU_BAL
    {
        public ProductPriceSKU_BAL()
        {
            ProductPriceSKU = new ProductPriceSKU_DAL();
        }

        readonly ProductPriceSKU_DAL ProductPriceSKU;

        public string Add(ProductPriceSKU_DataModel obj_ProductPriceSKU)
          {
            List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();
            insert_Parameters.Add(new KeyValuePair<string, string>("@ID", Convert.ToString(obj_ProductPriceSKU.ProductPriceSKUId)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@ProductId", Convert.ToString(obj_ProductPriceSKU.ProductId)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Unit", Convert.ToString(obj_ProductPriceSKU.Unit)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@SKU", obj_ProductPriceSKU.SKU));
            insert_Parameters.Add(new KeyValuePair<string, string>("@RatePerPc", Convert.ToString(obj_ProductPriceSKU.RatePerPc)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@MinOrderQuantity", Convert.ToString(obj_ProductPriceSKU.MinOrderQuantity)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@MaxOrderQuantity", Convert.ToString(obj_ProductPriceSKU.MaxOrderQuantity)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@CreatedBy", Convert.ToString(1)));     
            return ProductPriceSKU.Insert(insert_Parameters);

        }

        public List<ProductPriceSKU_DataModel> GetAllProductPriceSKU()
        {
            List<ProductPriceSKU_DataModel> lst_ProductPriceSKU = new List<ProductPriceSKU_DataModel>();
            List<KeyValuePair<string, string>> listing_Parameters = new List<KeyValuePair<string, string>>();
            lst_ProductPriceSKU = JsonConvert.DeserializeObject<List<ProductPriceSKU_DataModel>>(ProductPriceSKU.Get_Listing(listing_Parameters));
            return lst_ProductPriceSKU;
        }

        public ProductPriceSKU_DataModel GetProductById(int ProductPriceSKUId)
        {
            ProductPriceSKU_ViewModel obj_ProductPriceSKUVM = new ProductPriceSKU_ViewModel();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@ID", Convert.ToString(ProductPriceSKUId)));
            return obj_ProductPriceSKUVM.ProductPriceSKU = JsonConvert.DeserializeObject<ProductPriceSKU_DataModel>(ProductPriceSKU.GetByID(getByID_Parameters));
        }

        public List<ProductPriceSKU_DataModel> GetProductListById(int ProductId)
        {
            List<ProductPriceSKU_DataModel> lst_ProductPriceSKU = new List<ProductPriceSKU_DataModel>();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@ProductId", Convert.ToString(ProductId)));
            return lst_ProductPriceSKU = JsonConvert.DeserializeObject<List<ProductPriceSKU_DataModel>>(ProductPriceSKU.GetByProductID(getByID_Parameters));
        }


    }
}
