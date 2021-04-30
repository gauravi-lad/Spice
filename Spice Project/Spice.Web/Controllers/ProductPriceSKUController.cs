using Newtonsoft.Json.Linq;
using Spice.BAL;
using Spice.DataContarct.ViewModel;
using System.Web.Mvc;

namespace Spice.Web.Controllers
{
    public class ProductPriceSKUController : Controller
    {

        public ProductPriceSKUController()
        {
            obj_ProductPriceSKU = new ProductPriceSKU_BAL();
            obj_Product = new Product_BAL();
        }

        readonly ProductPriceSKU_BAL obj_ProductPriceSKU;
        Product_BAL obj_Product;


        public ActionResult ProductSku()
        {
            ProductPriceSKU_ViewModel obj_Sku = new ProductPriceSKU_ViewModel();
            if (TempData["Result"] != null)
                ViewBag.Result = TempData["Result"].ToString();
            obj_Sku.lst_Product = obj_Product.GetAllProductsWithCategory();
            return View(obj_Sku);
        }

        [HttpPost]
        public ActionResult InsertUpdateProductDetails(ProductPriceSKU_ViewModel obj_ProductPriceSKUVM)
        {
            var result = "";
            if (obj_ProductPriceSKUVM.lst_ProductPriceSKU.Count > 0)
            {
                foreach (var item in obj_ProductPriceSKUVM.lst_ProductPriceSKU)
                {
                    result = obj_ProductPriceSKU.Add(item);
                }
            }
            //update from here
            if (obj_ProductPriceSKUVM.ProductPriceSKU.ProductPriceSKUId != 0)
            {
                result = obj_ProductPriceSKU.Add(obj_ProductPriceSKUVM.ProductPriceSKU);

            }
            if (result != "")
            {
                var statusObj = JObject.Parse(result);
                TempData["Result"] = (string)statusObj["Status"];
            }
            else
            {
                TempData["Result"] = "0";
            }

            return RedirectToAction("ProductSku");
        }

        public ActionResult GetAllProductPriceSKU()
        {
            ProductPriceSKU_ViewModel obj_ProductPriceSKUVM = new ProductPriceSKU_ViewModel();
            obj_ProductPriceSKUVM.lst_ProductPriceSKU=obj_ProductPriceSKU.GetAllProductPriceSKU();
            return Json(obj_ProductPriceSKUVM.lst_ProductPriceSKU, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProductPriceSKUById(int ProductIdPriceSKUId)
        {
            ProductPriceSKU_ViewModel obj_ProductPriceSKUVM = new ProductPriceSKU_ViewModel();

            obj_ProductPriceSKUVM.ProductPriceSKU = obj_ProductPriceSKU.GetProductById(ProductIdPriceSKUId);

            return View("", obj_ProductPriceSKUVM);
        }
    }
}