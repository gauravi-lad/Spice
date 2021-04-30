using Newtonsoft.Json.Linq;
using Spice.BAL;
using Spice.DataContarct.DataModel;
using Spice.DataContarct.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spice.Web.Controllers
{
    public class ReceipeController : Controller
    {
        public ReceipeController()
        {
            obj_Receipe = new Receipe_BAL();
            obj_Product = new Product_BAL();
        }

        Receipe_BAL obj_Receipe;
        Product_BAL obj_Product;
        #region Receipe Crud
        public ActionResult ReceipeMaster()
        {
            Receipe_ViewModel obj_ReceipeVM = new Receipe_ViewModel();
            if (TempData["Result"] != null)
                ViewBag.Result = TempData["Result"].ToString();
            obj_ReceipeVM.lst_Product = obj_Product.GetAllProducts();
            return View(obj_ReceipeVM);
        }
        [HttpPost]
        public ActionResult InsertReceipe(Receipe_DataModel Receipe)
        {
            var result = obj_Receipe.InsertReceipe(Receipe);
            if (result != "")
            {
                var statusObj = JObject.Parse(result);
                TempData["Result"] = (string)statusObj["Status"];
            }
            else
            {
                TempData["Result"] = "0";
            }
            return RedirectToAction("ReceipeMaster");

        }
        public ActionResult GetReceipeListing()
        {
            Receipe_ViewModel obj_ReceipeVM = new Receipe_ViewModel();
            obj_ReceipeVM.lst_Receipe = obj_Receipe.GetReceipeListing();
            return Json(obj_ReceipeVM.lst_Receipe, JsonRequestBehavior.AllowGet);

        }


        public ActionResult Search()
        {
            Receipe_ViewModel obj_ReceipeVM = new Receipe_ViewModel();
            obj_ReceipeVM.lst_Receipe = obj_Receipe.GetReceipeListing();
            obj_ReceipeVM.lst_Product = obj_Product.GetAllProducts();
            return View(obj_ReceipeVM);
        }
        
        public ActionResult GetReceipeById(int ReceipeId)
        {
            Receipe_ViewModel obj_ReceipeVM = new Receipe_ViewModel();
            obj_ReceipeVM.Receipe = obj_Receipe.GetReceipeById(ReceipeId);
            obj_ReceipeVM.lst_Product = obj_Product.GetAllProducts();
            return View("Index", obj_ReceipeVM);
            
        }
        public ActionResult GetReceipeByProductId(int ProductId)
        {
            Receipe_ViewModel obj_ReceipeVM = new Receipe_ViewModel();
            obj_ReceipeVM.lst_Receipe = obj_Receipe.GetReceipeByProductId(ProductId);
            obj_ReceipeVM.lst_Product = obj_Product.GetAllProducts();
            return View("Search", obj_ReceipeVM);

        }
        public ActionResult DeleteReceipe(int ReceipeId)
        {
            obj_Receipe.DeleteReceipe(ReceipeId);
            return RedirectToAction("Search");

        }
        #endregion



    }
}