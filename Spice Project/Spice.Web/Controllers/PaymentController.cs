using Spice.BAL;
using Spice.DataContarct.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spice.Web.Controllers
{
    public class PaymentController : Controller
    {
        public PaymentController()
        {
            obj_Payment = new Payment_BAL();
        }

        Payment_BAL obj_Payment;

        [HttpPost]
        public JsonResult InsertUpdateProductDetails(Payment_ViewModel obj_PaymentVM)
        {

            obj_Payment.Insert_Payment(obj_PaymentVM.Payment);

            return Json(obj_PaymentVM);
        }
    }
}