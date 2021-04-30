using Spice.BAL;
using Spice.DataContarct.ViewModel;
using Spice.Web.Filters;
using System.Web.Mvc;
using Spice.CommanUtilities;

namespace Spice.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            Home = new Home_BAL();
        }

        readonly Home_BAL Home;

        public ActionResult Index()
        {
            Home_ViewModel home_VM = new Home_ViewModel();

            Home.ProcessData();

            return View();
        }

        [FrontEnd_Authenticate_Token]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}