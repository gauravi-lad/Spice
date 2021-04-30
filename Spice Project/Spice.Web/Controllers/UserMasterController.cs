using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spice.BAL;
using Spice.DataContarct.ViewModel;

namespace Spice.Web.Controllers
{
    public class UserMasterController : Controller
    {
        public UserMasterController()
        {
            UserMaster = new UserMaster_BAL(); 
        }

        UserMaster_BAL UserMaster;

        // GET: UserMaster
        public ActionResult Index(UserMaster_ViewModel UserMaster_VM)
        {
            UserMaster.GetDataListing();
            return View();
        }

        public JsonResult GetDataList()
        {
            var data = UserMaster.GetDataListing();
            return Json(data.lst_userMaster, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDataById(int Id)
        {
            var data = UserMaster.GetDataById(Id);
            return Json(data.userMaster, JsonRequestBehavior.AllowGet);
        }

        public JsonResult InsertData(UserMaster_ViewModel UserMaster_VM)
        {
            UserMaster.Insert_Data(UserMaster_VM.userMaster);
            return Json("Data inserted successfully", JsonRequestBehavior.AllowGet);
        }
    }
}