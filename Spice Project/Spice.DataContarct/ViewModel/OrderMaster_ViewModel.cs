using Newtonsoft.Json;
using Spice.CommanUtilities;
using Spice.DataContarct.CommanUtils;
using Spice.DataContarct.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Spice.DataContarct.ViewModel
{
    public class OrderMaster_ViewModel
    {
        public OrderMaster_ViewModel()
        {
            orderMaster = new OrderMaster();
            lst_orderMaster = new List<OrderMaster>();
            order_Item_Details = new List<Order_Item_Details>();
            order_Status_History = new Order_Status_History();
            invoice_Status_History = new Invoice_Status_History();
            lst_Order_Status_History = new List<Order_Status_History>();
            lst_Invoice_Status_History = new List<Invoice_Status_History>();
            order_Invoice_Details = new List<Order_Invoice_Details>();
            customer_Address = new CustomerAddressMaster_DataModel();
            CustomerAddressList = new List<CustomerAddressMaster_DataModel>();
            paymentMaster = new Payment_DataModel();
        }

        public OrderMaster orderMaster { get; set; }

        public Payment_DataModel paymentMaster { get; set; }

        public List<OrderMaster> lst_orderMaster { get; set; }

        public List<Order_Item_Details> order_Item_Details { get; set; }

        public Order_Status_History order_Status_History { get; set; }

        public Invoice_Status_History invoice_Status_History { get; set; }

        public List<Order_Status_History> lst_Order_Status_History { get; set; }

        public List<Invoice_Status_History> lst_Invoice_Status_History { get; set; }

        public List<Order_Invoice_Details> order_Invoice_Details { get; set; }

        public List<KeyValuePair<int, string>> drp_OrderStatus
        {
            get
            {
                string[] Status = Enum.GetNames(typeof(OrderStatus));
                return Status.Select((value, key) => new { value, key }).ToDictionary(x => x.key + 1, x => x.value).ToList();
            }
        }

        public List<KeyValuePair<int, string>> drp_InvoiceStatus
        {
            get
            {
                string[] Status = Enum.GetNames(typeof(InvoiceStatus));
                return Status.Select((value, key) => new { value, key }).ToDictionary(x => x.key + 1, x => x.value).ToList();
            }
        }

        public List<KeyValuePair<int, string>> drp_RefundReturnStatus
        {
            get
            {
                string[] Status = Enum.GetNames(typeof(RefundReturnStatus));
                return Status.Select((value, key) => new { value, key }).ToDictionary(x => x.key + 1, x => x.value).ToList();
            }
        }

        public List<KeyValuePair<int, string>> drp_PaymentStatus
        {
            get
            {
                string[] Status = Enum.GetNames(typeof(PaymentStatus));
                return Status.Select((value, key) => new { value, key }).ToDictionary(x => x.key, x => x.value).ToList();
            }
        }
       

        public CustomerAddressMaster_DataModel customer_Address { get; set; }

        public List<CustomerAddressMaster_DataModel> CustomerAddressList { get; set; }

        public List<VendorProduct_DataModel> Product_Vendor_Mapping
        {
            get
            {
                List<VendorProduct_DataModel> result = new List<VendorProduct_DataModel>();
                result = JsonConvert.DeserializeObject<List<VendorProduct_DataModel>>(SiteUtils.Get_Product_Vendor_Mapping());
                return result;

            }
        }         
    }
}
