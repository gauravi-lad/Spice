using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Spice.BAL;
using Spice.DataContarct.DataModel;
using Spice.DataContarct.ViewModel;
using Spice.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spice.Web.Controllers
{
    [BackEnd_SessionExpired]
    [BackEnd_CustomException]

    public class VendorController : Controller
    {
        public VendorController()
        {
            obj_Vendor = new Vendor_BAL();
            obj_Product = new Product_BAL();
        }
 
        Vendor_BAL obj_Vendor;
        Product_BAL obj_Product;

        #region Vendor Crud
        public ActionResult VendorMaster()
        {
            Vendor_ViewModel obj_VendorVM = new Vendor_ViewModel();
            if (TempData["Result"] != null)
                ViewBag.Result = TempData["Result"].ToString();
            obj_VendorVM.lst_gst = obj_Vendor.GetGSTListing();
            obj_VendorVM.lst_country = obj_Vendor.GetCountryListing();
            return View(obj_VendorVM);
        }
        public ActionResult InsertVendor(Vendor_ViewModel obj_VendorVM)
        {
            var result = obj_Vendor.InsertVendor(obj_VendorVM.vendor);
            if (result != "")
            {
                var statusObj = JObject.Parse(result);
                TempData["Result"] = (string)statusObj["Status"];               
            }
            else
            {
                TempData["Result"] = "0";
            }
            
            return RedirectToAction("VendorMaster");
        }
        public ActionResult GetVendorListing()
        {
            Vendor_ViewModel obj_VendorVM = new Vendor_ViewModel();
            obj_VendorVM.lst_vendor = obj_Vendor.GetVendorListing();
            return Json(obj_VendorVM.lst_vendor, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region Vendor Crud Unwanted
        public ActionResult Index()
        {
            Vendor_ViewModel obj_VendorVM = new Vendor_ViewModel();
            if (TempData["Result"] != null)
                ViewBag.Result = TempData["Result"].ToString();
            obj_VendorVM.lst_gst = obj_Vendor.GetGSTListing();
            obj_VendorVM.lst_state = obj_Vendor.GetStateListing();
            return View(obj_VendorVM);
        }
        public ActionResult Search()
        {
            Vendor_ViewModel obj_VendorVM = new Vendor_ViewModel();
            obj_VendorVM.lst_vendor = obj_Vendor.GetVendorListing();
            return View(obj_VendorVM);
        }   
        public ActionResult GetVendorById(int Id)
        {
            Vendor_ViewModel obj_VendorVM = new Vendor_ViewModel();
            obj_VendorVM.vendor = obj_Vendor.GetVendorById(Id);
            obj_VendorVM.lst_gst = obj_Vendor.GetGSTListing();
            obj_VendorVM.lst_state = obj_Vendor.GetStateListing();
            return View("Index", obj_VendorVM);

        }
        public ActionResult DeleteVendor(int VendorId)
        {
            obj_Vendor.DeleteVendor(VendorId);
            return RedirectToAction("Search");
          
        }
        #endregion

        #region Vendor Product Mapping
        public ActionResult VendorProduct()
        {
            Vendor_ViewModel obj_VendorVM = new Vendor_ViewModel();
            if (TempData["Result"] != null)
                ViewBag.Result = TempData["Result"].ToString();
            obj_VendorVM.lst_product = obj_Product.GetAllProducts();
            obj_VendorVM.lst_vendor = obj_Vendor.GetVendorListing();
            return View(obj_VendorVM);
        }
        [HttpPost]
        public ActionResult InsertVendorProduct(Vendor_ViewModel obj_VendorVM)
        {
            if (obj_VendorVM.vendorProduct.ProductId > 0 && obj_VendorVM.vendorProduct.VendorId > 0)
            {
                var result = obj_Vendor.InsertVendorProduct(obj_VendorVM.vendorProduct);
                if (result != "")
                {
                    var statusObj = JObject.Parse(result);
                    TempData["Result"] = (string)statusObj["Status"];
                }
                else
                {
                    TempData["Result"] = "0";
                }
            }
            return RedirectToAction("VendorProduct");


        }
        public ActionResult GetVendorProductListing()
        {
            Vendor_ViewModel obj_VendorVM = new Vendor_ViewModel();
            obj_VendorVM.lst_vendorProduct = obj_Vendor.GetVendorProductListing();
            return Json(obj_VendorVM.lst_vendorProduct, JsonRequestBehavior.AllowGet);

        }
        #endregion
        #region Not Used Methods-VendorProduct
        public ActionResult VendorProductSearch()
        {
            Vendor_ViewModel obj_VendorVM = new Vendor_ViewModel();
            obj_VendorVM.lst_vendor = obj_Vendor.GetVendorListing();
            obj_VendorVM.lst_product = obj_Product.GetAllProducts();
            obj_VendorVM.lst_vendorProduct = obj_Vendor.GetVendorProductListing();
            return View(obj_VendorVM);
        }       
        public ActionResult GetVendorProductById(int VendorProductId)
        {
            Vendor_ViewModel obj_VendorVM = new Vendor_ViewModel();
            obj_VendorVM.vendorProduct = obj_Vendor.GetVendorProductById(VendorProductId);
            obj_VendorVM.lst_product = obj_Product.GetAllProducts();
            obj_VendorVM.lst_vendor = obj_Vendor.GetVendorListing();
            return View("VendorProduct", obj_VendorVM);


        }       
        public ActionResult DeleteVendorProduct(int VendorProductId)
        {
            obj_Vendor.DeleteVendorProduct(VendorProductId);
            return RedirectToAction("VendorProductSearch");
           // return Json("Data deleted successfully", JsonRequestBehavior.AllowGet);

        }
        #endregion


    }
}