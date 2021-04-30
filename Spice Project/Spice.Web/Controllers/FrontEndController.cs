using Spice.BAL;
using Spice.CommanUtilities;
using Spice.CommanUtilities.Authentication;
using Spice.DataContarct.DataModel;
using Spice.DataContarct.ViewModel;
using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using PayPal.Api;
using Newtonsoft.Json;

namespace Spice.Web.Controllers
{
    public class FrontEndController : Controller
    {
        private int InvoiceNumber = 0;

        readonly FrontEndBAL FrontEndBAL;
        readonly Cart_BAL Cart;
        readonly CustomerFavourites_BAL obj_customerfavourites;
        readonly CustomerRating_BAL obj_CustomerRating;
        readonly CustomerAddressMaster_BAL CustomerAddressMaster_BAL;
        readonly CategoryMasterBAL categoryMasterBAL;
        readonly SubCategory_BAL subCategory_BAL;
        OrderMaster_BAL obj_OrderMaster_BAL;

        public FrontEndController()
        {
            FrontEndBAL = new FrontEndBAL();
            Cart = new Cart_BAL();
            obj_customerfavourites = new CustomerFavourites_BAL();
            obj_CustomerRating = new CustomerRating_BAL();
            CustomerAddressMaster_BAL = new CustomerAddressMaster_BAL();
            categoryMasterBAL = new CategoryMasterBAL();
            subCategory_BAL = new SubCategory_BAL();
            obj_OrderMaster_BAL = new OrderMaster_BAL();
        }
        public ActionResult Index(FrontEndViewModel frontEndViewModel)
        {
            try
            {
                //Get Best seller product list
                frontEndViewModel.BestSellerProductList = FrontEndBAL.GetBestSellerProductList();

                //Get featured product list
                frontEndViewModel.FeaturedProductList = FrontEndBAL.GetFeaturedProductList();

                //Get recent product list
                frontEndViewModel.RecentProductList = FrontEndBAL.GetRecentProductList();

                //Get Menu List
                frontEndViewModel.MenuList = FrontEndBAL.GetMenuList();

                if (TempData["Result"] != null)
                {
                    if (TempData["Result"] == "1")
                    {
                        ViewBag.Result = 1;
                        ViewBag.orderId = TempData["OrderID"];
                    }
                    else
                    {

                        ViewBag.Result = 0;
                    }
                }

                if (TempData["PaymentFailed"] != null)
                {
                    ViewBag.PaymentFailed = 1;
                }
                if (TempData["PaymentSucessfull"] != null)
                {
                    ViewBag.PaymentSucessfull = 1;
                }
            }
            catch (Exception ex)
            {
                Logger.log(ex.Message, Convert.ToString(LogDirectory.Spice_Exception_Log));
            }

            return View("FrontEndIndex", frontEndViewModel);
        }

        public ActionResult ProductDetails(FrontEndViewModel frontEndViewModel)
        {
            //FrontEndViewModel frontEndViewModel = new FrontEndViewModel();
            Product_BAL product_BAL = new Product_BAL();
            ProductPriceSKU_BAL productPriceSKU_BAL = new ProductPriceSKU_BAL();
            ProductImage_BAL productImage_BAL = new ProductImage_BAL();
            CustomerRating_BAL obj_CustomerRating = new CustomerRating_BAL();
            int ProductId = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
            {
                ProductId = Convert.ToInt32(Request.QueryString["pid"]);
            }
            else if (TempData["ProductId"] != null)
            {
                ProductId = Convert.ToInt32(TempData["ProductId"]);
            }

            //Get product details
            frontEndViewModel.ProductDetails = product_BAL.GetProductById(ProductId);

            //Get Product Price SKU List
            frontEndViewModel.ProductPriceSKUList = productPriceSKU_BAL.GetProductListById(ProductId);

            //Get Product Images
            frontEndViewModel.ProductImageList = productImage_BAL.GetProductImageListById(ProductId);

            //Get Customer Product Ratings
            frontEndViewModel.lst_CustomerRating = obj_CustomerRating.GetCustomerRatingListingByProductId(ProductId);

            return View("ProductDetails", frontEndViewModel);
            //return RedirectToAction("ProductDetails", new { pid = "2" });
        }

        //Changes by Aditya [Commented for now] 
        public ActionResult Checkout(FrontEndViewModel frontEndViewModel)
        {
            CustomerAddressMaster_BAL CustomerAddressMaster = new CustomerAddressMaster_BAL();
            OrderMaster_ViewModel orderMasterVM = new OrderMaster_ViewModel();
            // orderMasterVM.orderMaster.Customer_Id;
            int CustomerID = 0;

            CustomerID = Convert.ToInt32(Session["FrontEnd_UserId"]);
            orderMasterVM.CustomerAddressList = CustomerAddressMaster.GetAddressMasterDataListingById(CustomerID);

            if (frontEndViewModel.ProductDetails.CartFlag == 0)
            {
                var CartModel = Cart.GetCartListing(CustomerID.ToString());
                orderMasterVM.order_Item_Details = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Order_Item_Details>>(Newtonsoft.Json.JsonConvert.SerializeObject(CartModel));
                for (int i = 0; i < orderMasterVM.order_Item_Details.Count; i++)
                {
                    orderMasterVM.order_Item_Details[i].UnitPrice = Convert.ToInt32(orderMasterVM.order_Item_Details[i].FinalAmmount) / Convert.ToInt32(orderMasterVM.order_Item_Details[i].Quantity);
                    orderMasterVM.order_Item_Details[i].TaxId = 0;
                    orderMasterVM.order_Item_Details[i].TaxAmmount = 0;
                    orderMasterVM.order_Item_Details[0].FinalAmmount = orderMasterVM.order_Item_Details[0].FinalAmmount + Convert.ToInt32(orderMasterVM.order_Item_Details[i].RatePerPc * orderMasterVM.order_Item_Details[i].Quantity);
                }

            }
            else
            {

                List<Order_Item_Details> Order_Item = new List<Order_Item_Details>
            {
                 new Order_Item_Details{
            ProductName= frontEndViewModel.ProductDetails.ProductName,
            ProductId = frontEndViewModel.ProductDetails.ProductId,
            Quantity = frontEndViewModel.ProductPriceSKU.Quantity,
            Unit = Convert.ToString(frontEndViewModel.ProductPriceSKU.Unit),
            UnitPrice = Convert.ToInt32(frontEndViewModel.ProductPriceSKU.TotalPrice) / Convert.ToInt32(frontEndViewModel.ProductPriceSKU.Quantity),
            FinalAmmount = Convert.ToInt32(frontEndViewModel.ProductPriceSKU.TotalPrice),
            SKU = frontEndViewModel.ProductPriceSKU.SKU,
            TaxId = 1,
            TaxAmmount = 0
            } };

                orderMasterVM.order_Item_Details = Order_Item;
            }

            orderMasterVM.orderMaster.Shipping_Charges = 0;
            orderMasterVM.orderMaster.Payment_Method = 1;
            orderMasterVM.orderMaster.Payment_Mode = 2;
            orderMasterVM.orderMaster.Payment_Status = 1;
            orderMasterVM.orderMaster.Customer_Id = CustomerID;

            TempData["orderMasterVM"] = orderMasterVM;


            return View("Checkout", orderMasterVM);
        }


        //public ActionResult Checkout(FrontEndViewModel frontEndViewModel)
        //{

        //    CustomerAddressMaster_BAL CustomerAddressMaster = new CustomerAddressMaster_BAL();
        //    frontEndViewModel.CustomerAddressList = CustomerAddressMaster.GetAddressMasterDataListingById(0);


        //    return View("Checkout", frontEndViewModel);
        //}


        [HttpPost]
        public ActionResult AddToCart(Cart_ViewModel obj_Cart)
        {
            string UserId = "";
            var data = "";
            if (TempData["Result"] != null)
            {
                ViewBag.Result = TempData["Result"].ToString();
            }

            if (Session["FrontEnd_UserId"] != null)
            {
                UserId = Session["FrontEnd_UserId"].ToString();
                string UserName = Session["FrontEnd_UserName"].ToString();
                data = Cart.InsertCart(UserId, obj_Cart.cart_DataModel);
                obj_Cart.lst_CartDataModel = Cart.GetCartListing(UserId);
                if (obj_Cart.lst_CartDataModel.Count > 0)
                {
                    if (HttpContext.Session["BackEnd_UserId"] == null)
                    {
                        Session.Add("CartCount", obj_Cart.lst_CartDataModel.Count);
                    }
                }
                else
                {
                    Session.Add("CartCount", 0);
                }
            }
            return Json(data);
        }

        [HttpPost]
        public JsonResult AddToWishList(CustomerFavourites_ViewModel obj_CR)
        {
            obj_customerfavourites.InsertCustomerFavourites(obj_CR.CustomerFavourites);
            return Json(obj_CR);
        }

        public ActionResult InsertCustomerRating(FrontEndViewModel frontEndViewModel)
        {
            frontEndViewModel.CustomerRating.Date = DateTime.Now;
            frontEndViewModel.CustomerRating.IsActive = true;
            TempData["ProductId"] = frontEndViewModel.CustomerRating.Product_Id;
            var result = obj_CustomerRating.InsertCustomerRating(frontEndViewModel.CustomerRating);
            return RedirectToAction("ProductDetails");
        }

        public ActionResult PlaceOrder(FrontEndViewModel frontEndViewModel)
        {

            return View("Checkout", frontEndViewModel);
        }

        [HttpPost]
        public JsonResult SaveAddress(CustomerAddressMaster_ViewModel customerAddressMaster_VM)
        {
            CustomerAddressMaster_BAL.Insert_Data(customerAddressMaster_VM.customerAddresMaster);
            return Json(customerAddressMaster_VM);
        }

        [HttpPost]
        public JsonResult Get_AllMenus()
        {
            FrontEndViewModel frontEndViewModel = new FrontEndViewModel();
            frontEndViewModel.MenuList = FrontEndBAL.GetMenuList();
            TempData["MenuList"] = frontEndViewModel.MenuList;
            return Json(frontEndViewModel);
        }

        public ActionResult ProductShop(FrontEndViewModel frontEndViewModel)
        {
            int CategoryId = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["cid"]))
            {
                CategoryId = Convert.ToInt32(Request.QueryString["cid"]);
            }

            frontEndViewModel.ProductList = FrontEndBAL.GetProductListByCategoryId(CategoryId);

            return View("ProductShop", frontEndViewModel);
        }

        public ActionResult CategoryList(FrontEndViewModel frontEndViewModel)
        {
            int CategoryId = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["cid"]))
            {
                CategoryId = Convert.ToInt32(Request.QueryString["cid"]);
            }

            if (CategoryId == 0)
            {
                frontEndViewModel.CategoryList = categoryMasterBAL.GetCategoryList();
            }
            else
            {
                frontEndViewModel.CategoryList = subCategory_BAL.GetSubCategoryListByCategoryId(CategoryId);
            }
            return View("CategoryList", frontEndViewModel);
        }

        public ActionResult Blog()
        {
           
            return View("Blog");
        }

        public ActionResult PaymentWithPaypal(string Cancel = null)
        {
            OrderMaster_ViewModel orderMasterVM = new OrderMaster_ViewModel();
            if (TempData["orderMasterVM"] != null)
            {
                orderMasterVM = (OrderMaster_ViewModel)TempData["orderMasterVM"];
            }

            try
            {
                APIContext apiContext = PaypalConfiguration.GetAPIContext();

                string payerId = Request.Params["PayerID"];

                if (string.IsNullOrEmpty(payerId))
                {
                    var orderMaster = obj_OrderMaster_BAL.Get_Latest_Id_Order();
                    InvoiceNumber = orderMaster != null ? orderMaster[0].Id : 0;

                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/FrontEnd/PaymentWithPayPal?";
                    var guid = Convert.ToString((new Random()).Next(100000));
                    var createdPayment = CreatePayment(apiContext, baseURI + "guid=" + guid, orderMasterVM);

                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = null;
                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;

                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalRedirectUrl = lnk.href;
                        }
                    }

                    Session.Add(guid, createdPayment.id);

                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    var guid = Request.Params["guid"];
                    orderMasterVM.paymentMaster.Payment_Method = 2;
                    orderMasterVM.paymentMaster.PayPal_Payment_ID= Session[guid] as string;
                    orderMasterVM.paymentMaster.Customer_ID = Convert.ToInt32(Session["FrontEnd_UserId"]);
                    var executedPayment = this.ExecutePayment(apiContext, payerId, Session[guid] as string);

                    if (executedPayment.state.ToLower() != "approved")
                    {
                        TempData["PaymentFailed"] = "1";
                        return RedirectToAction("Index", "FrontEnd");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.log(ex.Message, Convert.ToString(LogDirectory.Spice_Exception_Log));
                TempData["PaymentFailed"] = "1";
                return RedirectToAction("Index", "FrontEnd");
            }

            TempData["PaymentSucessfull"] = "1";

            return RedirectToAction("Insert", "OrderMaster");
        }

        private PayPal.Api.Payment payment;
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution() { payer_id = payerId };
            this.payment = new Payment() { id = paymentId };
            return this.payment.Execute(apiContext, paymentExecution);
        }

        private Payment CreatePayment(APIContext apiContext, string redirectUrl, OrderMaster_ViewModel orderMasterVM)
        {
            var totalTaxAmount = 0;
            var totalFinalAmount = 0;

            var itemList = new ItemList() { items = new List<Item>() };
            foreach (var orderDetails in orderMasterVM.order_Item_Details)
            {
                itemList.items.Add(new Item()
                {
                    name = orderDetails.ProductName,
                    currency = "USD",
                    price = orderDetails.RatePerPc != 0 ? orderDetails.RatePerPc.ToString() : orderDetails.UnitPrice.ToString(),
                    quantity = orderDetails.Quantity.ToString(),
                    sku = "sku" //sku = orderDetails.SKU
                }) ;
                totalTaxAmount += orderDetails.TaxAmmount;
                totalFinalAmount += orderDetails.FinalAmmount;
            }            
            
            var payer = new Payer() { payment_method = "paypal" };
            
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };

            var details = new Details()
            {
                tax = totalTaxAmount.ToString(),
                shipping = orderMasterVM.orderMaster.Shipping_Charges.ToString(),
                subtotal = totalFinalAmount.ToString()
            };

            var amount = new Amount()
            {
                currency = "USD",
                total = (totalTaxAmount + orderMasterVM.orderMaster.Shipping_Charges + totalFinalAmount).ToString(), // Total must be equal to sum of tax, shipping and subtotal.
                details = details
            };

            var transactionList = new List<Transaction>();
            transactionList.Add(new Transaction()
            {
                description = "PayPal Transaction",
                invoice_number = InvoiceNumber.ToString(), //Generate an Invoice No
                amount = amount,
                item_list = itemList
            });


            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            return this.payment.Create(apiContext);
        }

    }
}