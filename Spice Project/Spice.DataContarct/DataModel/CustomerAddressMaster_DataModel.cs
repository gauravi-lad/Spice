

using System.Web.Mvc;

namespace Spice.DataContarct.DataModel
{
    public class CustomerAddressMaster_DataModel
    {
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        public string Customer_Name { get; set; }
        public string Street_1 { get; set; }
        public string Street_2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        
         public string Country { get; set; }


        public bool? IsShipping { get; set; }
        public bool? IsDelivery { get; set; }
        public string CountryName { get; set; }

        [AllowHtml]
        public string ShippingAddress { get; set; }
        [AllowHtml]
        public string BillingAddress { get; set; }
    }
}
