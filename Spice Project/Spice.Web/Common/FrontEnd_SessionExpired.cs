using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Spice.Web.Common
{
    public class FrontEnd_SessionExpired : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            if (HttpContext.Current.Session["FrontEnd_UserId"] == null)
            {
                FormsAuthentication.SignOut();
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "action", "FrontEndLogout" }, { "controller", "Login" }, { "returnUrl", filterContext.HttpContext.Request.RawUrl } });
                filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
                return;
            }

        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            filterContext.Controller.ViewBag.CustomActionMessage1 = "Custom Action Filter: Message from OnActionExecuting method.";
            if (HttpContext.Current.Session["FrontEnd_UserId"] == null)
            {
                filterContext.Controller.TempData.Remove("RedirectReason");
                filterContext.Controller.TempData.Add("RedirectReason", "Session time out");
                FormsAuthentication.SignOut();
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "action", "FrontEndLogout" }, { "controller", "Login" }, { "returnUrl", filterContext.HttpContext.Request.RawUrl } });
                filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
                return;
            }
        }
    }
}