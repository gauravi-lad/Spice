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



namespace Spice.Web.Controllers
{
    public class FrontEndController : Controller
    {
        readonly FrontEndBAL FrontEndBAL;
        readonly Cart_BAL Cart;
        readonly CustomerFavourites_BAL obj_customerfavourites;
        readonly CustomerRating_BAL obj_CustomerRating;
        readonly CustomerAddressMaster_BAL CustomerAddressMaster_BAL;
        readonly CategoryMasterBAL categoryMasterBAL;
        readonly SubCategory_BAL subCategory_BAL;
        public FrontEndController()
        {
            FrontEndBAL = new FrontEndBAL();
            Cart = new Cart_BAL();
            obj_customerfavourites = new CustomerFavourites_BAL();
            obj_CustomerRating = new CustomerRating_BAL();
            CustomerAddressMaster_BAL = new CustomerAddressMaster_BAL();
            categoryMasterBAL = new CategoryMasterBAL();
            subCategory_BAL = new SubCategory_BAL();
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
            TaxId = 0,
            TaxAmmount = 0
            } };

                orderMasterVM.order_Item_Details = Order_Item;
            }

            orderMasterVM.orderMaster.Shipping_Charges = 0;
            orderMasterVM.orderMaster.Payment_Method = 1;
            orderMasterVM.orderMaster.Payment_Mode = 2;
            orderMasterVM.orderMaster.Payment_Status = 1;
            orderMasterVM.orderMaster.Customer_Id = CustomerID;

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
    }
}