using Spice.BAL;
using Spice.DataContarct.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spice.Web.Controllers
{
    public class ForgotPasswordController : Controller
    {
        public ForgotPasswordController()
        {
            obj_ForgotPassword = new ForgotPassword_BAL();
        }

        ForgotPassword_BAL obj_ForgotPassword;

        // GET: ForgotPassword
        public ActionResult Index()
        {
            return View("../Login/ForgotPassword");
            //return View("Forgot");
        }
       
        public ActionResult VerifyUser(ForgotPassword_ViewModel _Fviewmodel)
        {
            //ViewBag.EmailId = _Fviewmodel.forgotPassword.Email;
            var cookie = new HttpCookie("MobileNo", (_Fviewmodel.forgotPassword.MobileNo).Trim());
            DateTime now = DateTime.Now;
            cookie.Expires = now.AddHours(24);
            Response.SetCookie(cookie);
            bool IsUserExistflag=obj_ForgotPassword.VerifyUser(_Fviewmodel.forgotPassword.MobileNo);
           
            if (IsUserExistflag==true)
            {              
                return View("../Login/ChangePassword");
            }
            else
            {
                ViewBag.Result = "1";
                return View("../Login/ForgotPassword");
            }

        }

      
        public ActionResult Reset_password(ForgotPassword_ViewModel obj_ForgotPasswordVM)
        {

            if (Request.Cookies["MobileNo"] != null)
            {
                obj_ForgotPasswordVM.forgotPassword.MobileNo = Request.Cookies["MobileNo"].Value;
                
            }
            bool isPasswordUpdate= obj_ForgotPassword.ResetPassword(obj_ForgotPasswordVM);

            if (isPasswordUpdate == true)
            {
                 //return View("../Login/FrontEnd");
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.Result = "1";
                return View("../Login/ChangePassword");
            }
        }
      
    }
}