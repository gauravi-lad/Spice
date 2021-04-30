using Spice.DataContarct.DataModel;
using System.Collections.Generic;

namespace Spice.DataContarct.ViewModel
{
    public class CustomerFavourites_ViewModel
    {
        public CustomerFavourites_ViewModel()
        {
            CustomerFavourites = new CustomerFavourites_DataModel();
            lst_CustomerFavourites = new List<CustomerFavourites_DataModel>();
            lst_Product = new List<Product_DataModel>();
        }

        public CustomerFavourites_DataModel CustomerFavourites { get; set; }
        public List<CustomerFavourites_DataModel> lst_CustomerFavourites { get; set; }

        public List<Product_DataModel> lst_Product { get; set; }
    }
}
