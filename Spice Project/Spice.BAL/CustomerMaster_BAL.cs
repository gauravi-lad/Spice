using Newtonsoft.Json;
using Spice.DAL;
using Spice.DataContarct.DataModel;
using Spice.DataContarct.ViewModel;
using System;
using System.Collections.Generic;
using Country_DataModel = Spice.DataContarct.ViewModel.Country_DataModel;

namespace Spice.BAL
{
    public class CustomerMaster_BAL
    {
        public CustomerMaster_BAL()
        {
            CustomerMaster = new CustomerMaster_DAL();
        }

        readonly CustomerMaster_DAL CustomerMaster;

        public string Insert_Data(CustomerMaster_DataModel customermaster_DataModel)
        {
            string result = "";
            List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();
            insert_Parameters.Add(new KeyValuePair<string, string>("@Id", Convert.ToString(customermaster_DataModel.Id)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@First_Name", Convert.ToString(customermaster_DataModel.First_Name)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Second_Name", Convert.ToString(customermaster_DataModel.Second_Name)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Middle_Name", Convert.ToString(customermaster_DataModel.Middle_Name)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Mobile_Number", Convert.ToString(customermaster_DataModel.Mobile_Number)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Email", Convert.ToString(customermaster_DataModel.Email)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Password", Convert.ToString(customermaster_DataModel.Password)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@IsActive", Convert.ToString(customermaster_DataModel.IsActive)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@ProfilePicture", Convert.ToString(customermaster_DataModel.ProfilePicture)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Gender", Convert.ToString(customermaster_DataModel.Gender)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@DOB", Convert.ToString(customermaster_DataModel.DOB)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Mobile_Verified", Convert.ToString(customermaster_DataModel.Mobile_Verified)));
            result= CustomerMaster.Insert(insert_Parameters);
            return result;
        }

        public CustomerMaster_ViewModel GetDataById(int Id)
        {
            CustomerMaster_ViewModel customermasterVM = new CustomerMaster_ViewModel();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@Id", Convert.ToString(Id)));
            customermasterVM.customerMaster = JsonConvert.DeserializeObject<CustomerMaster_DataModel>(CustomerMaster.GetByID(getByID_Parameters));
            return customermasterVM;
        }

        public CustomerMaster_DataModel GetCustomerMasterDataById(int Id)
        {
            CustomerMaster_DataModel customermaster = new CustomerMaster_DataModel();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@Id", Convert.ToString(Id)));
            customermaster = JsonConvert.DeserializeObject<CustomerMaster_DataModel>(CustomerMaster.GetByID(getByID_Parameters));
            return customermaster;
        }

        public CustomerMaster_ViewModel GetDataListing()
        {
            CustomerMaster_ViewModel customermasterVM = new CustomerMaster_ViewModel();
            List<KeyValuePair<string, string>> listing_Parameters = new List<KeyValuePair<string, string>>();
            customermasterVM.lst_customerMaster = JsonConvert.DeserializeObject<List<CustomerMaster_DataModel>>(CustomerMaster.Get_Listing(listing_Parameters));
            return customermasterVM;
        }

        public string Change_Password(CustomerMaster_DataModel customermaster_DataModel)
        {
            string result;
            List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();
            insert_Parameters.Add(new KeyValuePair<string, string>("@Id", Convert.ToString(customermaster_DataModel.Id)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Password", Convert.ToString(customermaster_DataModel.Password)));
            result=CustomerMaster.Change_Password(insert_Parameters);
            return result;
        }

        public List<Country_DataModel> GetCountryListing()
        {
            List<Country_DataModel> obj_lst_country = new List<Country_DataModel>();
            List<KeyValuePair<string, string>> Parameters = new List<KeyValuePair<string, string>>();
            obj_lst_country = JsonConvert.DeserializeObject<List<Country_DataModel>>(CustomerMaster.GetCountries(Parameters));
            return obj_lst_country;
        }
    }
}
