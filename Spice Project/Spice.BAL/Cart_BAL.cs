using Newtonsoft.Json;
using Spice.DAL;
using Spice.DataContarct.DataModel;
using System;
using System.Collections.Generic;

namespace Spice.BAL
{
    public class Cart_BAL
    {
        public Cart_BAL()
        {
            obj_Cart_DAL = new Cart_DAL();
        }

        readonly Cart_DAL obj_Cart_DAL;

        public string InsertCart(string UserId,CartDataModel C_Model)
        {
            string result = "";
            List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();
            insert_Parameters.Add(new KeyValuePair<string, string>("@Customer_ID", Convert.ToString(UserId)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Product_ID", Convert.ToString(C_Model.Product_ID)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@ProductSku_ID", Convert.ToString(C_Model.ProductSku_ID)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Unit", Convert.ToString(C_Model.Unit)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Quantity", Convert.ToString(C_Model.Quantity)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Amount", Convert.ToString(C_Model.Amount)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Discount", Convert.ToString(C_Model.Discount)));

            result = obj_Cart_DAL.Insert(insert_Parameters);
            return result;
        }
        public CartDataModel GetCartById(int Id)
        {
            CartDataModel obj_CF = new CartDataModel();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@Id", Convert.ToString(Id)));
            obj_CF = JsonConvert.DeserializeObject<CartDataModel>(obj_Cart_DAL.GetByID(getByID_Parameters));
            return obj_CF;
        }
        public List<CartDataModel> GetCartListing(string User_Id)
        {
            List<CartDataModel> obj_lst_CF = new List<CartDataModel>();
            List<KeyValuePair<string, string>> Parameters = new List<KeyValuePair<string, string>>();
            Parameters.Add(new KeyValuePair<string, string>("@User_Id", Convert.ToString(User_Id)));
            obj_lst_CF = JsonConvert.DeserializeObject<List<CartDataModel>>(obj_Cart_DAL.Get_Listing(Parameters));
            return obj_lst_CF;
        }

        public string Delete_Cart(string Customer_ID, string Product_ID,string ProductSku_Id)
        {
            List<KeyValuePair<string, string>> details_Parameters = new List<KeyValuePair<string, string>>();
            details_Parameters.Add(new KeyValuePair<string, string>("@Customer_ID", Customer_ID));
            details_Parameters.Add(new KeyValuePair<string, string>("@Product_ID", Product_ID));
            details_Parameters.Add(new KeyValuePair<string, string>("@ProductSku_Id", ProductSku_Id));
            return obj_Cart_DAL.DeleteCart(details_Parameters);
        }
    }
}
