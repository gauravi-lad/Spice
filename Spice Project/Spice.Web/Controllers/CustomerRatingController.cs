using Newtonsoft.Json.Linq;
using Spice.BAL;
using Spice.DataContarct.ViewModel;
using System.Web.Mvc;

namespace Spice.Web.Controllers
{
    public class CustomerRatingController : Controller
    {
        // GET: CustomerRating
        public CustomerRatingController()
        {
            obj_CustomerRating = new CustomerRating_BAL();
            obj_Product = new Product_BAL();
            obj_Cust = new CustomerMaster_BAL();
        }

        readonly CustomerRating_BAL obj_CustomerRating;
        Product_BAL obj_Product;
        CustomerMaster_BAL obj_Cust;


        public ActionResult Index()
        {
            CustomerRating_ViewModel obj_CR = new CustomerRating_ViewModel();
            if (TempData["Result"] != null)
                ViewBag.Result = TempData["Result"].ToString();
            obj_CR.lst_Product = obj_Product.GetAllProducts();
            obj_Cust.GetDataListing();
            return View("CustomerRating", obj_CR);
        }

        public ActionResult InsertCustomerRating(CustomerRating_ViewModel obj_CR)
        {
            var result = obj_CustomerRating.InsertCustomerRating(obj_CR.CustomerRating);
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
        public ActionResult GetCustomerRatingListing()
        {
            CustomerRating_ViewModel obj_CR = new CustomerRating_ViewModel();
            obj_CR.lst_CustomerRating = obj_CustomerRating.GetCustomerRatingListing();
            return View("Search", obj_CR);
        }
        public ActionResult GetCustomerRatingById(int Id)
        {
            CustomerRating_ViewModel obj_CR = new CustomerRating_ViewModel();
            obj_CR.CustomerRating = obj_CustomerRating.GetCustomerRatingById(Id);
            obj_CR.lst_Product = obj_Product.GetAllProducts();
            return View("CustomerRating", obj_CR);
        }
    }
}