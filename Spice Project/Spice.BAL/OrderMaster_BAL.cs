using Newtonsoft.Json;
using Spice.DAL;
using Spice.DataContarct.DataModel;
using Spice.DataContarct.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;

namespace Spice.BAL
{
    public class OrderMaster_BAL
    {
        public OrderMaster_BAL()
        {
            obj_OrderMaster_DAL = new OrderMaster_DAL();
        }
        OrderMaster_DAL obj_OrderMaster_DAL;

        public string Insert(OrderMaster_ViewModel orderMasterVM)
        {
            string result = string.Empty;
            DateTime dateTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            System.Random random = new System.Random();

            string date_time = DateTime.Now.ToString("MsddmmHHyy");
            string order_invoice_number = "IN-" + "ORD-" + random.Next(100, 999) + "-" + date_time;

            orderMasterVM.orderMaster.Orde_Status = 1;
            orderMasterVM.orderMaster.Order_Invoice_Number = order_invoice_number;
            orderMasterVM.orderMaster.Return_Refund = 0;
            orderMasterVM.orderMaster.Order_Date = dateTime;
            
            orderMasterVM.order_Status_History.Update_Date = dateTime;
            orderMasterVM.order_Status_History.Status_Id = 1;
            result = obj_OrderMaster_DAL.Insert(JsonConvert.SerializeObject(orderMasterVM));

            return result;
        }

        public string GetByID(string OrderId)
        {
            string result = string.Empty;

            List<KeyValuePair<string, string>> Parameters = new List<KeyValuePair<string, string>>();
            Parameters.Add(new KeyValuePair<string, string>("@Id", OrderId));

            result = obj_OrderMaster_DAL.GetByID(Parameters);

            return result;
        }

        public string Get_Listing(string Order_Invoice_Number, string from_Date, string to_Date, string order_Status)
        {
            string result = string.Empty;

            List<KeyValuePair<string, string>> Parameters = new List<KeyValuePair<string, string>>();
            Parameters.Add(new KeyValuePair<string, string>("@order_Invoice_Number",string.IsNullOrEmpty(Order_Invoice_Number)?null: Order_Invoice_Number));
            Parameters.Add(new KeyValuePair<string, string>("@order_from_Date", string.IsNullOrEmpty(from_Date) ? null : Convert.ToDateTime(from_Date).ToLongDateString()));
            Parameters.Add(new KeyValuePair<string, string>("@order_to_Date", string.IsNullOrEmpty(to_Date) ? null : Convert.ToDateTime(to_Date).ToLongDateString()));
            Parameters.Add(new KeyValuePair<string, string>("@order_Status", string.IsNullOrEmpty(order_Status) ? null : order_Status));

            result = obj_OrderMaster_DAL.Get_Listing(Parameters);

            return result;
        }

        public string Assign_Vendors(OrderMaster_ViewModel orderMasterVM)
        {
            string result = string.Empty;

            List<Order_Invoice_Details> order_Invoice = new List<Order_Invoice_Details>();

            List<Invoice_Status_History> invoice_Status_History = new List<Invoice_Status_History>();

            System.Random random = new System.Random();

            var InvoiceList = orderMasterVM.order_Item_Details.GroupBy(u => u.VendorId).Select(grp => grp.First()).ToList();

            foreach (var item in InvoiceList)
            {
                string date_time = DateTime.Now.ToString("ddHHmmyyMs");
                string invoice_number = "IN-"+"VND-"+ random.Next(100, 999)+"-"+ date_time ;
                DateTime date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                order_Invoice.Add(new Order_Invoice_Details {OrderId=item.OrderId,Vendor_Id=item.VendorId,Invoice_Number =invoice_number,Invoice_Date= date, Invoice_Status=1});

                invoice_Status_History.Add(new Invoice_Status_History { OrderId = item.OrderId, Invoice_Number = invoice_number, Update_Date = date, Status_Id = 1 });

            }
            
            orderMasterVM.order_Invoice_Details = order_Invoice;

            orderMasterVM.lst_Invoice_Status_History = invoice_Status_History;

            result = obj_OrderMaster_DAL.Assign_Vendors(JsonConvert.SerializeObject(orderMasterVM));

            return result;
        }

        public string Update_Vendors_Delivery_Dates(OrderMaster_ViewModel orderMasterVM)
        {
            string result = string.Empty;

            result = obj_OrderMaster_DAL.Update_Vendor_Delivery_Dates(JsonConvert.SerializeObject(orderMasterVM));

            return result;
        }

        public string Update_Order_status(OrderMaster_ViewModel orderMasterVM)
        {
            string result = string.Empty;

            result = obj_OrderMaster_DAL.Update_Order_status(JsonConvert.SerializeObject(orderMasterVM));

            return result;
        }

        public string Update_Invoice_status(OrderMaster_ViewModel orderMasterVM)
        {
            string result = string.Empty;

            result = obj_OrderMaster_DAL.Update_Invoice_status(JsonConvert.SerializeObject(orderMasterVM));

            return result;
        }

        public List<OrderMaster> Get_Latest_Id_Order()
        {
            List<OrderMaster> obj_orderMasterVM = new List<OrderMaster>();

            List<KeyValuePair<string, string>> listing_Parameters = new List<KeyValuePair<string, string>>();

            return obj_orderMasterVM = JsonConvert.DeserializeObject<List<OrderMaster>>(obj_OrderMaster_DAL.Get_Latest_Id_Order(listing_Parameters));            
        }
    }
}
