using Spice.DataContarct.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice.DataContarct.ViewModel
{
    public class Vendor_ViewModel
    {
        public Vendor_ViewModel()
        {
            vendor = new Vendor_DataModel();
            lst_vendor = new List<Vendor_DataModel>();
            vendorProduct = new VendorProduct_DataModel();
            lst_product = new List<Product_DataModel>();
            lst_state = new List<State_DataModel>();
            lst_gst = new List<GST_DataModel>();
            lst_country = new List<Spice.DataContarct.DataModel.Country_DataModel>();
        }

        public Vendor_DataModel vendor { get; set; }
        public List<Vendor_DataModel> lst_vendor { get; set; }
        public VendorProduct_DataModel vendorProduct { get; set; }
        public List<VendorProduct_DataModel> lst_vendorProduct { get; set; }
        public List<Product_DataModel> lst_product { get; set; }
        public List<State_DataModel> lst_state { get; set; }
        public List<GST_DataModel> lst_gst { get; set; }
        public List<Spice.DataContarct.DataModel.Country_DataModel> lst_country { get; set; }
        
    }
}
