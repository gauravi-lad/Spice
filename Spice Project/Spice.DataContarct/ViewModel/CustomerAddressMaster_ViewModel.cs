using Spice.DataContarct.DataModel;
using System.Collections.Generic;

namespace Spice.DataContarct.ViewModel
{
    public class CustomerAddressMaster_ViewModel
    {
        public CustomerAddressMaster_ViewModel()
        {
            customerAddresMaster = new CustomerAddressMaster_DataModel();
            lst_customerAddresMaster = new List<CustomerAddressMaster_DataModel>();
        }

        public CustomerAddressMaster_DataModel customerAddresMaster { get; set; }
        public List<CustomerAddressMaster_DataModel> lst_customerAddresMaster { get; set; }
 
    }
}
