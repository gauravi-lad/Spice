using Newtonsoft.Json;
using Spice.DAL;
using Spice.DataContarct.DataModel;
using System;
using System.Collections.Generic;

namespace Spice.BAL
{
    public class Vendor_BAL
    {
        public Vendor_BAL()
        {
            obj_VendorDAL = new Vendor_DAL();
        }

        readonly Vendor_DAL obj_VendorDAL;
        #region Vendor Crud
        public string InsertVendor(Vendor_DataModel vendor)
        {
            string result = "";
            List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();
            insert_Parameters.Add(new KeyValuePair<string, string>("@ID", Convert.ToString(vendor.Id)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@FirstName", vendor.FirstName));
            insert_Parameters.Add(new KeyValuePair<string, string>("@MiddleName", vendor.MiddleName));
            insert_Parameters.Add(new KeyValuePair<string, string>("@LastName", vendor.LastName));
            insert_Parameters.Add(new KeyValuePair<string, string>("@MobileNo", Convert.ToString(vendor.MobileNo)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Email", vendor.Email));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Address", vendor.Address));
            insert_Parameters.Add(new KeyValuePair<string, string>("@GST", Convert.ToString(vendor.GST)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@IsActive", Convert.ToString(vendor.IsActive)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@CountryId", Convert.ToString(vendor.CountryId)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@CityName", Convert.ToString(vendor.CityName)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Address2", Convert.ToString(vendor.Address2)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@StateName", Convert.ToString(vendor.StateName)));

            result = obj_VendorDAL.Insert(insert_Parameters);
            return result;
        }
        public Vendor_DataModel GetVendorById(int Id)
        {
            Vendor_DataModel obj_vendor = new Vendor_DataModel();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@Id", Convert.ToString(Id)));
            obj_vendor = JsonConvert.DeserializeObject<Vendor_DataModel>(obj_VendorDAL.GetByID(getByID_Parameters));
            return obj_vendor;
        }
        public List<Vendor_DataModel> GetVendorListing()
        {
            List<Vendor_DataModel> obj_lst_vendor = new List<Vendor_DataModel>();
            List<KeyValuePair<string, string>> Parameters = new List<KeyValuePair<string, string>>();
            obj_lst_vendor = JsonConvert.DeserializeObject<List<Vendor_DataModel>>(obj_VendorDAL.Get_Listing(Parameters));
            return obj_lst_vendor;
        }
        public int DeleteVendor(int VendorId)
        {
            Vendor_DataModel obj_vendor = new Vendor_DataModel();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@VendorId", Convert.ToString(VendorId)));
            obj_vendor = JsonConvert.DeserializeObject<Vendor_DataModel>(obj_VendorDAL.DeleteByID(getByID_Parameters));
            return 1;
        }
        #endregion

        #region Vendor Product Crud
        public string InsertVendorProduct(VendorProduct_DataModel vendorProduct)
        {
            string result = "";
            List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();
            insert_Parameters.Add(new KeyValuePair<string, string>("@VendorProductId", Convert.ToString(vendorProduct.VendorProductId)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@VendorId", Convert.ToString(vendorProduct.VendorId)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@ProductId", Convert.ToString(vendorProduct.ProductId)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@VendorPriority", Convert.ToString(vendorProduct.VendorPriority)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@VendorPrice", Convert.ToString(vendorProduct.VendorPrice)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@IsActive", Convert.ToString(vendorProduct.IsActive)));
            result = obj_VendorDAL.InsertVendorProduct(insert_Parameters);
            return result;
        }
        public VendorProduct_DataModel GetVendorProductById(int VendorProductId)
        {
            VendorProduct_DataModel obj_vendorProduct = new VendorProduct_DataModel();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@VendorProductId", Convert.ToString(VendorProductId)));
            obj_vendorProduct = JsonConvert.DeserializeObject<VendorProduct_DataModel>(obj_VendorDAL.GetVendorProductById(getByID_Parameters));
            return obj_vendorProduct;
        }
        public List<VendorProduct_DataModel> GetVendorProductListing()
        {
            List<VendorProduct_DataModel> obj_lst_vendorProduct = new List<VendorProduct_DataModel>();
            List<KeyValuePair<string, string>> Parameters = new List<KeyValuePair<string, string>>();
            obj_lst_vendorProduct = JsonConvert.DeserializeObject<List<VendorProduct_DataModel>>(obj_VendorDAL.Get_VendorProductListing(Parameters));
            return obj_lst_vendorProduct;
        }
        public int DeleteVendorProduct(int VendorProductId)
        {
            Vendor_DataModel obj_vendor = new Vendor_DataModel();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@VendorProductId", Convert.ToString(VendorProductId)));           
            obj_vendor = JsonConvert.DeserializeObject<Vendor_DataModel>(obj_VendorDAL.DeleteVendorProduct(getByID_Parameters));
            return 1;
        }
        #endregion

        #region Common Dropdown
        public List<GST_DataModel> GetGSTListing()
        {
            List<GST_DataModel> obj_lst_gst = new List<GST_DataModel>();
            List<KeyValuePair<string, string>> Parameters = new List<KeyValuePair<string, string>>();
            obj_lst_gst = JsonConvert.DeserializeObject<List<GST_DataModel>>(obj_VendorDAL.GetGST(Parameters));
            return obj_lst_gst;
        }
        public List<State_DataModel> GetStateListing()
        {
            List<State_DataModel> obj_lst_state = new List<State_DataModel>();
            List<KeyValuePair<string, string>> Parameters = new List<KeyValuePair<string, string>>();
            obj_lst_state = JsonConvert.DeserializeObject<List<State_DataModel>>(obj_VendorDAL.GetStates(Parameters));
            return obj_lst_state;
        }
        public List<Country_DataModel> GetCountryListing()
        {
            List<Country_DataModel> obj_lst_country = new List<Country_DataModel>();
            List<KeyValuePair<string, string>> Parameters = new List<KeyValuePair<string, string>>();
            obj_lst_country = JsonConvert.DeserializeObject<List<Country_DataModel>>(obj_VendorDAL.GetCountries(Parameters));
            return obj_lst_country;
        }
        
        #endregion

    }

}