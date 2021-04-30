using Newtonsoft.Json;
using Spice.BAL;
using Spice.DataContarct.DataModel;
using Spice.DataContarct.ViewModel;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Spice.Web.Controllers
{
    public class OrderMasterController : Controller
    {

        public OrderMasterController()
        {
            obj_OrderMaster_BAL = new OrderMaster_BAL();
            obj_Payment = new Payment_BAL();
        }

        OrderMaster_BAL obj_OrderMaster_BAL;
        Payment_BAL obj_Payment;

        public ActionResult checkout()
        {
            OrderMaster_ViewModel orderMasterVM = new OrderMaster_ViewModel();
            return View(orderMasterVM);
        }

        public ActionResult Insert(OrderMaster_ViewModel orderMasterVM)
        {
            try
            {
                Payment_DataModel paymentMasterVM = new Payment_DataModel();
                if (orderMasterVM.order_Item_Details.Count == 0 && TempData["orderMasterVM"] != null)
                {
                    orderMasterVM = (OrderMaster_ViewModel)TempData["orderMasterVM"];
                    paymentMasterVM = orderMasterVM.paymentMaster;
                }

                string result = string.Empty;
                Cart_ViewModel obj_Cart = new Cart_ViewModel();
                orderMasterVM.orderMaster.Customer_Id = Convert.ToInt32(Session["FrontEnd_UserId"]);
                Cart_BAL Cart = new Cart_BAL();
                result = obj_OrderMaster_BAL.Insert(orderMasterVM);

                obj_Cart.lst_CartDataModel = Cart.GetCartListing(orderMasterVM.orderMaster.Customer_Id.ToString());
                if (obj_Cart.lst_CartDataModel.Count > 0)
                {
                    Session.Add("CartCount", obj_Cart.lst_CartDataModel.Count);
                }
                else
                {
                    Session.Add("CartCount", 0);
                }

                orderMasterVM = JsonConvert.DeserializeObject<OrderMaster_ViewModel>(result);

                if (orderMasterVM.orderMaster.Id != 0 || orderMasterVM.orderMaster.Id != null)
                {
                    TempData["Result"] = "1";
                    TempData["OrderID"] = orderMasterVM.orderMaster.Order_Invoice_Number;
                    if (paymentMasterVM.Payment_Method == 2)
                    {
                        paymentMasterVM.Order_ID = orderMasterVM.orderMaster.Id;
                        obj_Payment.Insert_Payment(paymentMasterVM);
                    }
                }
                else
                {
                    TempData["Result"] = "0";
                }

            }
            catch (Exception)
            {

            }
            //return View("checkout", orderMasterVM);
            return RedirectToAction("Index", "FrontEnd");
        }

        public ActionResult GetById(string OrderId)
        {
            OrderMaster_ViewModel orderMasterVM = new OrderMaster_ViewModel();

            string result = string.Empty;

            result = obj_OrderMaster_BAL.GetByID(OrderId);

            orderMasterVM = JsonConvert.DeserializeObject<OrderMaster_ViewModel>(result);

            if (TempData["result"] != null)
            {
                ViewBag.Result = Convert.ToString(TempData["result"]);
            }
            return View("OrderDetails", orderMasterVM);
        }

        public ActionResult Get_Listing()
        {
            OrderMaster_ViewModel orderMasterVM = new OrderMaster_ViewModel();
            return View(orderMasterVM);
        }

        public PartialViewResult Get_Listing_PartialView(string Order_Invoice_Number, string from_Date, string to_Date, string order_Status)
        {
            OrderMaster_ViewModel orderMasterVM = new OrderMaster_ViewModel();

            string result = string.Empty;

            result = obj_OrderMaster_BAL.Get_Listing(Order_Invoice_Number, from_Date, to_Date, order_Status);

            orderMasterVM = JsonConvert.DeserializeObject<OrderMaster_ViewModel>(result);

            return PartialView("_partialOrderListingTable", orderMasterVM);
        }

        public ActionResult Assign_Vendors(OrderMaster_ViewModel orderMasterVM)
        {
            try
            {
                string result = string.Empty;

                result = obj_OrderMaster_BAL.Assign_Vendors(orderMasterVM);

                orderMasterVM = JsonConvert.DeserializeObject<OrderMaster_ViewModel>(result);

                TempData["Result"] = 2;
            }
            catch (Exception)
            {
                TempData["Result"] = 0;
                return RedirectToAction("GetById", new { OrderId = orderMasterVM.orderMaster.Id });
            }
            return RedirectToAction("GetById", new { OrderId = orderMasterVM.orderMaster.Id });
        }

        public ActionResult Update_Vendors_Delivery_Dates(OrderMaster_ViewModel orderMasterVM)
        {
            try
            {
                string result = string.Empty;

                result = obj_OrderMaster_BAL.Update_Vendors_Delivery_Dates(orderMasterVM);

                orderMasterVM = JsonConvert.DeserializeObject<OrderMaster_ViewModel>(result);

                TempData["Result"] = 3;
            }
            catch (Exception)
            {
                TempData["Result"] = 0;

                return RedirectToAction("GetById", new { OrderId = orderMasterVM.orderMaster.Id });
            }
            return RedirectToAction("GetById", new { OrderId = orderMasterVM.orderMaster.Id });
        }

        public ActionResult Update_Order_status(OrderMaster_ViewModel orderMasterVM)
        {
            try
            {
                string result = string.Empty;

                result = obj_OrderMaster_BAL.Update_Order_status(orderMasterVM);

                orderMasterVM = JsonConvert.DeserializeObject<OrderMaster_ViewModel>(result);

                TempData["Result"] = 1;
            }
            catch (Exception)
            {
                TempData["Result"] = 0;
                return RedirectToAction("GetById", new { OrderId = orderMasterVM.orderMaster.Id });
            }

            return RedirectToAction("GetById", new { OrderId = orderMasterVM.orderMaster.Id });
        }

        public ActionResult Update_Invoice_status(OrderMaster_ViewModel orderMasterVM)
        {
            string result = string.Empty;

            result = obj_OrderMaster_BAL.Update_Invoice_status(orderMasterVM);

            orderMasterVM = JsonConvert.DeserializeObject<OrderMaster_ViewModel>(result);

            return RedirectToAction("GetById", new { OrderId = orderMasterVM.orderMaster.Id });
        }

        public ActionResult GetHistoryById(string OrderId)
        {
            OrderMaster_ViewModel orderMasterVM = new OrderMaster_ViewModel();

            string result = string.Empty;

            result = obj_OrderMaster_BAL.GetByID(OrderId);

            orderMasterVM = JsonConvert.DeserializeObject<OrderMaster_ViewModel>(result);

            return View("OrderHistory", orderMasterVM);
        }

        public ActionResult PrintOrderInvoice(string OrderId)
        {
            OrderMaster_ViewModel orderMasterVM = new OrderMaster_ViewModel();

            string result = string.Empty;

            result = obj_OrderMaster_BAL.GetByID(OrderId);

            orderMasterVM = JsonConvert.DeserializeObject<OrderMaster_ViewModel>(result);

            orderMasterVM.orderMaster.Total_Without_Tax = orderMasterVM.order_Item_Details.Sum(x => x.FinalAmmount);

            orderMasterVM.orderMaster.Total_Taxation_Amount = orderMasterVM.order_Item_Details.Sum(x => x.TaxAmmount);

            return View("InvoicePrinting", orderMasterVM);
        }
    }
}