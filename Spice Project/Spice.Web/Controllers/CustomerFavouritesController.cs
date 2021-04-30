using Newtonsoft.Json.Linq;
using Spice.BAL;
using Spice.DataContarct.ViewModel;
using System.Web.Mvc;

namespace Spice.Web.Controllers
{
    public class CustomerFavouritesController : Controller
    {
        public CustomerFavouritesController()
        {
            obj_customerfavourites = new CustomerFavourites_BAL();
            obj_Product = new Product_BAL();
        }

        readonly CustomerFavourites_BAL obj_customerfavourites;
        Product_BAL obj_Product;

        public ActionResult Index()
        {
            CustomerFavourites_ViewModel obj_CR = new CustomerFavourites_ViewModel();
            if (TempData["Result"] != null)
                ViewBag.Result = TempData["Result"].ToString();
            obj_CR.lst_Product = obj_Product.GetAllProducts();
            return View("CustomerFavouritesMaster", obj_CR);
        }

        public ActionResult InsertCustomerFavourites(CustomerFavourites_ViewModel obj_CR)
        {
            var result=obj_customerfavourites.InsertCustomerFavourites(obj_CR.CustomerFavourites);

            if (result != "")
            {
                var statusObj = JObject.Parse(result);
                TempData["Result"] = (string)statusObj["Status"];
            }
            else
            {
                TempData["Result"] = "0";
            }
            return RedirectToAction("Index");
        }
        public ActionResult GetCustomerFavouritesListing()
        {
            CustomerFavourites_ViewModel obj_CR = new CustomerFavourites_ViewModel();
            obj_CR.lst_CustomerFavourites = obj_customerfavourites.GetCustomerFavouritesListing();
            return View("Search", obj_CR);
        }
        public ActionResult GetCustomerFavouritesById(int Id)
        {
            CustomerFavourites_ViewModel obj_CR = new CustomerFavourites_ViewModel();
            obj_CR.CustomerFavourites = obj_customerfavourites.GetCustomerFavouritesById(Id);
            obj_CR.lst_Product = obj_Product.GetAllProducts();
            return View("CustomerFavouritesMaster", obj_CR);
        }
    }
}