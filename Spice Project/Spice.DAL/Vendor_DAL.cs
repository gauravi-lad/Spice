using Spice.CommanUtilities;
using System.Collections.Generic;

namespace Spice.DAL
{
    public class Vendor_DAL
    {
        public string Insert(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("Sp_ins_up_Vendor", parameters);
        }
        public string Get_Listing(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("Sp_lst_Vendor", parameters);
        }
        public string GetByID(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("Sp_get_id_Vendor", parameters);
        }
        public string DeleteByID(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("sp_delete_id_Vendor", parameters);
        }
        public string InsertVendorProduct(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("sp_ins_up_VendorProduct", parameters);
        }
        public string Get_VendorProductListing(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_lst_VendorProduct", parameters);
        }
        public string GetVendorProductById(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("sp_get_id_VendorProduct", parameters);
        }
        public string DeleteVendorProduct(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("sp_delete_id_VendorProduct", parameters);
        }
        public string GetGST(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_lst_gst", parameters);
        }
        public string GetStates(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_lst_state", parameters);
        }
        public string GetCountries(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_lst_country", parameters);
        }
        
    }
}
