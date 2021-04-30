using Newtonsoft.Json;
using Spice.DAL;
using Spice.DataContarct.DataModel;
using Spice.DataContarct.ViewModel;
using System;
using System.Collections.Generic;

namespace Spice.BAL
{
    public class CustomerAddressMaster_BAL
    {

        public CustomerAddressMaster_BAL()
        {
            CustomerAddressMaster = new CustomerAddressMaster_DAL();
        }

        readonly CustomerAddressMaster_DAL CustomerAddressMaster;

        public string Insert_Data(CustomerAddressMaster_DataModel customerAddressMaster_DataModel)
        {
            string result = null;
            List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();
            insert_Parameters.Add(new KeyValuePair<string, string>("@Id", Convert.ToString(customerAddressMaster_DataModel.Id)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Customer_Id", Convert.ToString(customerAddressMaster_DataModel.Customer_Id)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Street_1", Convert.ToString(customerAddressMaster_DataModel.Street_1)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Street_2", Convert.ToString(customerAddressMaster_DataModel.Street_2)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@City", Convert.ToString(customerAddressMaster_DataModel.City)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@State", Convert.ToString(customerAddressMaster_DataModel.State)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Pincode", Convert.ToString(customerAddressMaster_DataModel.Pincode)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@IsShipping", Convert.ToString(customerAddressMaster_DataModel.IsShipping)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@IsDelivery", Convert.ToString(customerAddressMaster_DataModel.IsDelivery)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Country", Convert.ToString(customerAddressMaster_DataModel.Country)));
            result = CustomerAddressMaster.Insert(insert_Parameters);

            return result;
        }

        public CustomerAddressMaster_ViewModel GetDataById(int Id)
        {
            CustomerAddressMaster_ViewModel customerAddressMasterVM = new CustomerAddressMaster_ViewModel();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@Id", Convert.ToString(Id)));
            customerAddressMasterVM.customerAddresMaster = JsonConvert.DeserializeObject<CustomerAddressMaster_DataModel>(CustomerAddressMaster.GetByID(getByID_Parameters));
            return customerAddressMasterVM;
        }

        public CustomerAddressMaster_ViewModel GetDataListing()
        {
            CustomerAddressMaster_ViewModel customerAddressMasterVM = new CustomerAddressMaster_ViewModel();
            List<KeyValuePair<string, string>> listing_Parameters = new List<KeyValuePair<string, string>>();
            customerAddressMasterVM.lst_customerAddresMaster = JsonConvert.DeserializeObject<List<CustomerAddressMaster_DataModel>>(CustomerAddressMaster.Get_Listing(listing_Parameters));
            return customerAddressMasterVM;
        }

        public List<CustomerAddressMaster_DataModel> GetAddressMasterDataListing()
        {
            List<CustomerAddressMaster_DataModel> customerAddressMasterDataList = new List<CustomerAddressMaster_DataModel>();
            List<KeyValuePair<string, string>> listing_Parameters = new List<KeyValuePair<string, string>>();
            customerAddressMasterDataList = JsonConvert.DeserializeObject<List<CustomerAddressMaster_DataModel>>(CustomerAddressMaster.Get_Listing(listing_Parameters));
            return customerAddressMasterDataList;
        }
        public int DeleteCustomerAddress(int Id)
        {
            Vendor_DataModel obj_vendor = new Vendor_DataModel();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@Id", Convert.ToString(Id)));
            obj_vendor = JsonConvert.DeserializeObject<Vendor_DataModel>(CustomerAddressMaster.DeleteByID(getByID_Parameters));
            return 2;
        }

        public List<CustomerAddressMaster_DataModel> GetAddressMasterDataListingById(int customerId)
        {
            List<CustomerAddressMaster_DataModel> customerAddressMasterDataList = new List<CustomerAddressMaster_DataModel>();
            List<KeyValuePair<string, string>> listing_Parameters = new List<KeyValuePair<string, string>>();
            listing_Parameters.Add(new KeyValuePair<string, string>("@Customer_Id", Convert.ToString(customerId)));
            customerAddressMasterDataList = JsonConvert.DeserializeObject<List<CustomerAddressMaster_DataModel>>(CustomerAddressMaster.Get_Listing_By_Id(listing_Parameters));
            return customerAddressMasterDataList;
        }
        public List<OrderMaster> GetOrderDataListingById(int customerId)
        {
            List<OrderMaster> orderData = new List<OrderMaster>();
            List<KeyValuePair<string, string>> listing_Parameters = new List<KeyValuePair<string, string>>();
            listing_Parameters.Add(new KeyValuePair<string, string>("@Customer_Id", Convert.ToString(customerId)));
            orderData = JsonConvert.DeserializeObject<List<OrderMaster>>(CustomerAddressMaster.Get_OrderListing_By_Id(listing_Parameters));
            return orderData;
        }

    }
}
