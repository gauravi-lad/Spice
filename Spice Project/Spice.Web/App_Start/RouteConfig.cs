using System.Web.Mvc;
using System.Web.Routing;

namespace Spice.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "FrontEnd", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
            name: "Menu-1",
            url: "FrontEnd/Get_AllMenus",
            defaults: new { controller = "FrontEnd", action = "Get_AllMenus", id = UrlParameter.Optional },
            namespaces: new string[] { "Spice.Web.Controllers" });
        }
    }
}
