using Newtonsoft.Json.Linq;
using Spice.BAL;
using Spice.CommanUtilities.Authentication;
using Spice.DataContarct.DataModel;
using Spice.DataContarct.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spice.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (TempData["Result"] != null)
                ViewBag.Result = TempData["Result"].ToString();
            return View("FrontEnd");
        }

        public ActionResult Redirect_page(string ReturnUrl)
        {
            string Flag = "";

            if (TempData["Flag"] != null)
            {
                Flag = TempData["Flag"].ToString();
            }
            else
            {
                TempData["Flag"] = ReturnUrl;
            }
            return RedirectToAction("Index");
        }

        public LoginController()
        {
            login_BAL = new Login_BAL();
            CustomerMaster = new CustomerMaster_BAL();
            Cart = new Cart_BAL();
        }
        Login_BAL login_BAL;
        readonly CustomerMaster_BAL CustomerMaster;
        Cart_BAL Cart;
        public ActionResult FrontEndLogin(FronEndLogin_DataModel fronEndLogin_DataModel)
        {
            string Flag = "";
            var CustomerId = "";

            if (TempData["Flag"] != null)
                Flag = TempData["Flag"].ToString();

            FrontEnd_JWTInfo fronEndJWT = new FrontEnd_JWTInfo();
            Cart_ViewModel obj_Cart = new Cart_ViewModel();
            fronEndJWT = login_BAL.GetAccessTokenForFrontEndUser(fronEndLogin_DataModel.Email, fronEndLogin_DataModel.Password);
            if (fronEndJWT != null)
            {
                CustomerId = fronEndJWT.Id.ToString();
            }
            else
            {
                CustomerId = "0";
            }

            obj_Cart.lst_CartDataModel = Cart.GetCartListing(fronEndJWT.Id.ToString());
            if (obj_Cart.lst_CartDataModel.Count > 0)
            {
                fronEndJWT.CartCount = obj_Cart.lst_CartDataModel.Count;
            }
            else
            {
                fronEndJWT.CartCount = 0;
            }

            if (!string.IsNullOrEmpty(Flag) && !string.IsNullOrEmpty(fronEndJWT.UserToken))
            {
                var cookie = new HttpCookie("FrontEndToken", fronEndJWT.UserToken);
                DateTime now = DateTime.Now;
                cookie.Expires = now.AddHours(24);
                Response.SetCookie(cookie);
                FrontEndSetSession(fronEndJWT);

                if (Flag == "Cart")
                {
                    //obj_Cart.lst_CartDataModel = Cart.GetCartListing(fronEndJWT.Id.ToString());
                    //ViewBag.Count = obj_Cart.lst_CartDataModel.Count();
                    return RedirectToAction("CartF", "Cart");
                }
                else
                {
                    return RedirectToAction("Index", "FrontEnd");
                }
            }
            else if (!string.IsNullOrEmpty(fronEndJWT.UserToken))
            {
                var cookie = new HttpCookie("FrontEndToken", fronEndJWT.UserToken);
                DateTime now = DateTime.Now;
                cookie.Expires = now.AddHours(24);
                Response.SetCookie(cookie);
                FrontEndSetSession(fronEndJWT);
                return RedirectToAction("Index", "MyAccount");
            }
            else
            {
                TempData["Result"] = "0";
                var cookie = new HttpCookie("FrontEndToken", fronEndJWT.UserToken);
                DateTime now = DateTime.Now;
                cookie.Expires = now.AddHours(-24);
                Response.SetCookie(cookie);
                return RedirectToAction("Index");
            }
        }

        public ActionResult InsertData(CustomerMaster_ViewModel customermaster_VM)
        {
            var result = CustomerMaster.Insert_Data(customermaster_VM.customerMaster);

            if (!string.IsNullOrEmpty(result))
            {
                var statusObj = JObject.Parse(result);
                TempData["Result"] = "11";
            }
            else
            {
                TempData["Result"] = "10";
            }
            return RedirectToAction("Index");
        }

        public ActionResult FrontEndLogout()
        {

            var cookie = new HttpCookie("FrontEndToken", null);
            DateTime now = DateTime.Now;
            cookie.Expires = now.AddHours(-24);
            Response.SetCookie(cookie);
            FrontEndClearSession();
            return RedirectToAction("Index");
        }

        public void FrontEndSetSession(FrontEnd_JWTInfo frontEnd_JWT)
        {

            if (HttpContext.Session["BackEnd_UserId"] == null)
            {
                Session.Add("FrontEnd_UserId", frontEnd_JWT.Id);
                Session.Add("FrontEnd_UserName", frontEnd_JWT.First_Name + " " + frontEnd_JWT.Second_Name);
                Session.Add("CartCount", frontEnd_JWT.CartCount);
            }

        }
        public void FrontEndClearSession()
        {
            Session["FrontEnd_UserId"] = null;
            Session.Abandon();
        }

    }
}