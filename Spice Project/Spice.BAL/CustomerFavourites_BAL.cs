using Newtonsoft.Json;
using Spice.DAL;
using Spice.DataContarct.DataModel;
using System;
using System.Collections.Generic;

namespace Spice.BAL
{
    public class CustomerFavourites_BAL
    {
        public CustomerFavourites_BAL()
        {
            obj_CustomerFavourites_DAL = new CustomerFavourites_DAL();
        }

        readonly CustomerFavourites_DAL obj_CustomerFavourites_DAL;

        public string InsertCustomerFavourites(CustomerFavourites_DataModel CF_Model)
        {
            string result = "";
            List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();
            insert_Parameters.Add(new KeyValuePair<string, string>("@ID", Convert.ToString(CF_Model.ID)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Customer_Id", Convert.ToString(CF_Model.Customer_Id)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Product_Id", Convert.ToString(CF_Model.Product_Id)));

            result = obj_CustomerFavourites_DAL.Insert(insert_Parameters);
            return result;
        }
        public CustomerFavourites_DataModel GetCustomerFavouritesById(int Id)
        {
            CustomerFavourites_DataModel obj_CF = new CustomerFavourites_DataModel();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@Id", Convert.ToString(Id)));
            obj_CF = JsonConvert.DeserializeObject<CustomerFavourites_DataModel>(obj_CustomerFavourites_DAL.GetByID(getByID_Parameters));
            return obj_CF;
        }
        public List<CustomerFavourites_DataModel> GetCustomerFavouritesListing()
        {
            List<CustomerFavourites_DataModel> obj_lst_CF = new List<CustomerFavourites_DataModel>();
            List<KeyValuePair<string, string>> Parameters = new List<KeyValuePair<string, string>>();
            obj_lst_CF = JsonConvert.DeserializeObject<List<CustomerFavourites_DataModel>>(obj_CustomerFavourites_DAL.Get_Listing(Parameters));
            return obj_lst_CF;
        }
    }
}
