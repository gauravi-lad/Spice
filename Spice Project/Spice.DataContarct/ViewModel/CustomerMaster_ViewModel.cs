using Spice.DataContarct.CommanUtils;
using Spice.DataContarct.DataModel;
using System.Collections.Generic;

namespace Spice.DataContarct.ViewModel
{
    public class CustomerMaster_ViewModel
    {
        public CustomerMaster_ViewModel()
        {
            customerMaster = new CustomerMaster_DataModel();
            customerAddressMaster = new CustomerAddressMaster_DataModel();
            lst_customerMaster = new List<CustomerMaster_DataModel>();
            lst_customerAddressMaster = new List<CustomerAddressMaster_DataModel>();
            lst_country = new List<Country_DataModel>();
            lst_order = new List<OrderMaster>();

        }

        public CustomerMaster_DataModel customerMaster { get; set; }
        public List<CustomerMaster_DataModel> lst_customerMaster { get; set; }
        public CustomerAddressMaster_DataModel customerAddressMaster { get; set; }
        public List<CustomerAddressMaster_DataModel> lst_customerAddressMaster { get; set; }
        public List<Country_DataModel> lst_country { get; set; }
        public List<OrderMaster> lst_order { get; set; }

        public List<KeyValuePair<string, string>> gender
        {
            get
            {
                return SiteUtils.Gender();

            }
        }

    }
    public class Country_DataModel
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string Iso { get; set; }
        public string Iso3 { get; set; }


    }
}
