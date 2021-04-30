using Newtonsoft.Json;
using Spice.CommanUtilities.Authentication;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
namespace Spice.Web.Filters
{
    public class FrontEnd_Authenticate_Token : ActionFilterAttribute, System.Web.Mvc.Filters.IAuthenticationFilter
    {
        bool isActive = false;
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var access_token = "";

            //if (filterContext.RequestContext.HttpContext.Request.Headers["Token"] != null)
            //{
            //    access_token = filterContext.RequestContext.HttpContext.Request.Headers["Token"].ToString();
            //}
            if (filterContext.RequestContext.HttpContext.Request.Cookies["FrontEndToken"] != null)
            {
                access_token = filterContext.RequestContext.HttpContext.Request.Cookies["FrontEndToken"].Value;
            }
            else
            {
                isActive = false;
            }
            using (JWT_Provider jwt_provider = new JWT_Provider())
            {
                if (access_token != "")
                {
                    isActive = jwt_provider.Verify_Token(access_token);
                }
                else
                {
                    isActive = false;
                }
            }

            if (isActive == false)
            {
                filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(
                  new RouteValueDictionary
                  {
                     { "controller", "Login" },
                     { "action", "Index" }
                  });
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (isActive == false)
            {
                filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(null,
                new RouteValueDictionary
                {
                     { "controller", "Login" },
                     { "action", "Index" }
                });
            }
        }
    }
}
