using Newtonsoft.Json;
using Spice.DAL;
using Spice.DataContarct.DataModel;
using System;
using System.Collections.Generic;

namespace Spice.BAL
{
    public class CustomerRating_BAL
    {
        public CustomerRating_BAL()
        {
            obj_CustomerRating_DAL = new CustomerRating_DAL();
        }

        readonly CustomerRating_DAL obj_CustomerRating_DAL;

        public string InsertCustomerRating(CustomerRating_DataModel CR_Model)
        {
            string result = "";
            List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();
            insert_Parameters.Add(new KeyValuePair<string, string>("@Customer_Id", Convert.ToString(CR_Model.Customer_Id)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Product_Id", Convert.ToString(CR_Model.Product_Id)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Rating", Convert.ToString(CR_Model.Rating)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Reviews", Convert.ToString(CR_Model.Reviews)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Date", Convert.ToString(CR_Model.Date)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@IsActive", Convert.ToString(CR_Model.IsActive)));


            result = obj_CustomerRating_DAL.Insert(insert_Parameters);
            return result;
        }
        public CustomerRating_DataModel GetCustomerRatingById(int Id)
        {
            CustomerRating_DataModel obj_cr = new CustomerRating_DataModel();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@Id", Convert.ToString(Id)));
            obj_cr = JsonConvert.DeserializeObject<CustomerRating_DataModel>(obj_CustomerRating_DAL.GetByID(getByID_Parameters));
            return obj_cr;
        }
        public List<CustomerRating_DataModel> GetCustomerRatingListing()
        {
            List<CustomerRating_DataModel> obj_lst_CR = new List<CustomerRating_DataModel>();
            List<KeyValuePair<string, string>> Parameters = new List<KeyValuePair<string, string>>();
            obj_lst_CR = JsonConvert.DeserializeObject<List<CustomerRating_DataModel>>(obj_CustomerRating_DAL.Get_Listing(Parameters));
            return obj_lst_CR;
        }

        public List<CustomerRating_DataModel> GetCustomerRatingListingByProductId(int ProductId)
        {
            List<CustomerRating_DataModel> obj_lst_CR = new List<CustomerRating_DataModel>();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@ProductId", Convert.ToString(ProductId)));
            obj_lst_CR = JsonConvert.DeserializeObject<List<CustomerRating_DataModel>>(obj_CustomerRating_DAL.Get_ListingByProductId(getByID_Parameters));
            return obj_lst_CR;
        }
    }
}
