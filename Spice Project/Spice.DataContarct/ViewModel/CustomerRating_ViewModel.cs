using Spice.DataContarct.DataModel;
using System.Collections.Generic;

namespace Spice.DataContarct.ViewModel
{
    public class CustomerRating_ViewModel
    {
        public CustomerRating_ViewModel()
        {
            CustomerRating = new CustomerRating_DataModel();
            lst_CustomerRating = new List<CustomerRating_DataModel>();
            lst_Product = new List<Product_DataModel>();
            lst_customerMaster = new List<CustomerMaster_DataModel>();


        }

        public CustomerRating_DataModel CustomerRating { get; set; }
        public List<CustomerRating_DataModel> lst_CustomerRating { get; set; }

        public List<Product_DataModel> lst_Product { get; set; }

        public List<CustomerMaster_DataModel> lst_customerMaster { get; set; }


    }
}
