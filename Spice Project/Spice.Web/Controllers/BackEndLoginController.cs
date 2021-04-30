using Spice.BAL;
using Spice.CommanUtilities.Authentication;
using Spice.DataContarct.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spice.Web.Controllers
{
    public class BackEndLoginController : Controller
    {
        public BackEndLoginController() 
        {
            login_BAL = new Login_BAL();
        }
        Login_BAL login_BAL;
        // GET: BackEndLogin
        public ActionResult Index()
        {
            if (TempData["Result"] != null)
                ViewBag.Result = TempData["Result"].ToString();
            return View("Login");
        }

        public ActionResult BackEndLogin(BackEndLogin_DataModel backEndLogin_DataModel)
        {
            BackEnd_JWTInfo backEnd_JWTInfo = new BackEnd_JWTInfo();          
            backEnd_JWTInfo = login_BAL.GetAccessTokenForBackEndUser(backEndLogin_DataModel.Username, backEndLogin_DataModel.Password);
            
            if (!string.IsNullOrEmpty(backEnd_JWTInfo.Token)) 
            {
                var cookie = new HttpCookie("BackEndToken", backEnd_JWTInfo.Token);
                DateTime now = DateTime.Now;
                cookie.Expires = now.AddHours(24);
                Response.SetCookie(cookie);
                BackEndSetSession(backEnd_JWTInfo);
                return RedirectToAction("CategoryMaster", "Category");
            }
            else 
            {
                TempData["Result"] = "0";
                var cookie = new HttpCookie("BackEndToken", backEnd_JWTInfo.Token);
                DateTime now = DateTime.Now;
                cookie.Expires = now.AddHours(-24);
                Response.SetCookie(cookie);
                return RedirectToAction("Index");
            }
        }

        public ActionResult BackEndLogout()
        {
            
            var cookie = new HttpCookie("BackEndToken", null);
                DateTime now = DateTime.Now;
                cookie.Expires = now.AddHours(-24);
                Response.SetCookie(cookie);
                BackEndClearSession();
                return RedirectToAction("Index");
        }

        public void BackEndSetSession(BackEnd_JWTInfo backEnd_JWTInfo)
        {

            if (HttpContext.Session["BackEnd_UserId"] == null)
            {
                Session.Add("BackEnd_UserId", backEnd_JWTInfo.Id);  
                Session.Add("BackEnd_UserName", backEnd_JWTInfo.Username);
            }

        }
        public void BackEndClearSession()
        {
            Session["BackEnd_UserId"] = null;
            Session.Abandon();
            

        }
    }
}