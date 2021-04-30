using Spice.BAL;
using Spice.DataContarct.ViewModel;
using System.Web.Mvc;

namespace Spice.Web.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public CartController()
        {
            Cart = new Cart_BAL();
        }

        readonly Cart_BAL Cart;
        public ActionResult CartF()
        {
            string UserId = "";
            Cart_ViewModel obj_Cart = new Cart_ViewModel();

            if (TempData["Result"] != null)
                ViewBag.Result = TempData["Result"].ToString();

            if (Session["FrontEnd_UserId"] != null)
            {
                UserId = Session["FrontEnd_UserId"].ToString();
                string UserName = Session["FrontEnd_UserName"].ToString();
                obj_Cart.lst_CartDataModel = Cart.GetCartListing(UserId);
                return View(obj_Cart);
            }
            else
            {
                TempData["Flag"] = "Cart";
                return RedirectToAction("Redirect_page", "Login");
            }

        }

        public ActionResult GetCartById(int Id)
        {
            Cart_ViewModel obj_Cart = new Cart_ViewModel();
            obj_Cart.cart_DataModel = Cart.GetCartById(Id);
            return View();
        }

        public JsonResult Delete_Cart(Cart_ViewModel obj_Cart)
        {
            string UserId = Session["FrontEnd_UserId"].ToString();
            var result = Cart.Delete_Cart(UserId, obj_Cart.cart_DataModel.Product_ID, obj_Cart.cart_DataModel.ProductSku_ID);
            obj_Cart.lst_CartDataModel = Cart.GetCartListing(UserId);
            return Json(obj_Cart);
        }


    }
}