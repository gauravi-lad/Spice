using Spice.BAL;
using Spice.DataContarct.ViewModel;
using System.Web.Mvc;

namespace Spice.Web.Controllers
{
    public class CustomerAddressMasterController : Controller
    {
        public CustomerAddressMasterController()
        {
            CustomerAddressMaster = new CustomerAddressMaster_BAL();
        }

        readonly CustomerAddressMaster_BAL CustomerAddressMaster;

        public JsonResult GetDataById(int Id)
        {
            var data = CustomerAddressMaster.GetDataById(Id);
            return Json(data.customerAddresMaster, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDataList()
        {
            var data = CustomerAddressMaster.GetDataListing();
            return Json(data.lst_customerAddresMaster, JsonRequestBehavior.AllowGet);
        }

        public JsonResult InsertData(CustomerAddressMaster_ViewModel customerAddressMaster_VM)
        {
            CustomerAddressMaster.Insert_Data(customerAddressMaster_VM.customerAddresMaster);
            return Json("Data inserted successfully", JsonRequestBehavior.AllowGet);
        }
    }
}