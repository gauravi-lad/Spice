using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Spice.Web.Common
{
        public class BackEnd_CustomException : FilterAttribute, IExceptionFilter
        {
            public virtual void OnException(ExceptionContext filterContext)
            {
                if (filterContext == null)
                {
                    throw new ArgumentNullException("filterContext");
                }

                if (filterContext.IsChildAction)
                {
                    return;
                }

                // If custom errors are disabled, we need to let the normal ASP.NET exception handler
                // execute so that the user can see useful debugging information.
                if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
                {
                    return;
                }

                Exception exception = filterContext.Exception;

                // If this is not an HTTP 500 (for example, if somebody throws an HTTP 404 from an action method),
                // ignore it.
                if (new HttpException(null, exception).GetHttpCode() != 500)
                {
                    return;
                }

                // check if antiforgery
                if (!(exception is HttpAntiForgeryException))
                {
                    return;
                }

                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                    { "action", "Index" },
                    { "controller", "BackEndLogin" }
                    });

                filterContext.ExceptionHandled = true;
            }

        }
    }