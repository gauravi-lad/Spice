using Spice.BAL;
using Spice.DataContarct.ViewModel;
using System.Web.Mvc;

namespace Spice.Web.Controllers
{
    public class CustomerMasterController : Controller
    {
        public CustomerMasterController()
        {
            CustomerMaster = new CustomerMaster_BAL();
        }

        readonly CustomerMaster_BAL CustomerMaster;

        public ActionResult Index(CustomerMaster_ViewModel customermaster_VM)
        {
            CustomerMaster.GetDataListing();
            return View();
        }

        public JsonResult GetDataById(int Id)
        {
            var data = CustomerMaster.GetDataById(Id);
            return Json(data.customerMaster, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDataList()
        {
            var data = CustomerMaster.GetDataListing();
            return Json(data.lst_customerMaster, JsonRequestBehavior.AllowGet);
        }

        public JsonResult InsertData(CustomerMaster_ViewModel customermaster_VM)
        {
            CustomerMaster.Insert_Data(customermaster_VM.customerMaster);
            return Json("Data inserted successfully", JsonRequestBehavior.AllowGet);
        }

        public JsonResult Change_Password(CustomerMaster_ViewModel customermaster_VM)
        {
            CustomerMaster.Change_Password(customermaster_VM.customerMaster);
            return Json("Password Changed successfully", JsonRequestBehavior.AllowGet);
        }
    }
}