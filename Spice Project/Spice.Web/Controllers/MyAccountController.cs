using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Spice.BAL;
using Spice.DataContarct.CommanUtils;
using Spice.DataContarct.DataModel;
using Spice.DataContarct.ViewModel;
using Spice.Web.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spice.Web.Controllers
{
    public class MyAccountController : BaseController
    {
        // GET: MyAccount
        public MyAccountController()
        {
            CustomerMaster = new CustomerMaster_BAL();
            CustomerAddressMaster = new CustomerAddressMaster_BAL();
            obj_OrderMaster_BAL = new OrderMaster_BAL();

        }

        readonly CustomerMaster_BAL CustomerMaster;
        readonly CustomerAddressMaster_BAL CustomerAddressMaster;
        readonly OrderMaster_BAL obj_OrderMaster_BAL;

        [FrontEnd_Authenticate_Token]
        public ActionResult Index()
        {
            int id = 0;

            FrontEnd_Parse_Claim();

            CustomerMaster_ViewModel customermaster_VM = new CustomerMaster_ViewModel();

            if (TempData["Result"] != null)
            {
                ViewBag.Result = TempData["Result"].ToString();

                id = Convert.ToInt32(TempData["ID"]);
            }
            else
            {
                id = _claimFrontEnd.Id;

            }
            customermaster_VM.customerMaster = CustomerMaster.GetCustomerMasterDataById(id);

            Session.Add("FrontEnd_UserName", customermaster_VM.customerMaster.First_Name + " " + customermaster_VM.customerMaster.Second_Name);

            //if (customermaster_VM.customerMaster != null)
            //{
            //if (!string.IsNullOrEmpty(customermaster_VM.customerMaster.ProfilePicture))
            //{
            //    //var path = Path.Combine("~/Img/", customermaster_VM.customerMaster.ProfilePicture);
            //    customermaster_VM.customerMaster.ProfilePicture = path;
            //}
            //}

            if (customermaster_VM.customerMaster == null)
            {
                customermaster_VM.customerMaster = new CustomerMaster_DataModel();
            }
            else
            {
                customermaster_VM.customerMaster.DOB_string = (customermaster_VM.customerMaster.DOB)?.ToString("yyyy-MM-dd");
            }
            customermaster_VM.lst_customerAddressMaster = CustomerAddressMaster.GetAddressMasterDataListingById(id);

            if (customermaster_VM.lst_customerAddressMaster == null)
            {
                customermaster_VM.lst_customerAddressMaster = new List<CustomerAddressMaster_DataModel>();
            }

            customermaster_VM.lst_country = CustomerMaster.GetCountryListing();
            customermaster_VM.lst_order = CustomerAddressMaster.GetOrderDataListingById(id);
            if (customermaster_VM.lst_order != null)
            {
                customermaster_VM.lst_order.Select(c => { c.EnumOrderStatus = Enum.GetName(typeof(CommanUtilities.OrderStatus), c.Orde_Status); return c; }).ToList();

            }

            return View("Index1", customermaster_VM);
          
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

        public ActionResult InsertData(CustomerMaster_ViewModel customermaster_VM)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];
            bool validate_img = true;
            if (file != null)
            {
                if (!string.IsNullOrEmpty(file.FileName))
                {
                    if (file.FileName != customermaster_VM.customerMaster.LastProfilePicture)
                    {
                        var allowedExtensions = new[] {
                                                    ".Jpg", ".png", ".jpg", "jpeg"
                                                  };

                        string profileFileName = Guid.NewGuid().ToString();


                        var fileName = Path.GetFileName(file.FileName);
                        var ext = Path.GetExtension(file.FileName);
                        var file_Size = 10 * 1024 * 1024;
                        if (file.ContentLength <= file_Size)
                        {
                            if (allowedExtensions.Contains(ext))
                            {
                                string name = Path.GetFileNameWithoutExtension(fileName);
                                string myfile = name + "_" + profileFileName + ext;

                                var path = Path.Combine(Server.MapPath("~/Img"), myfile);
                                customermaster_VM.customerMaster.ProfilePicture = myfile;

                                file.SaveAs(path);
                            }
                            else
                            {
                                validate_img = false;
                                TempData["Result"] = "4";
                            }
                        }
                        else
                        {
                            validate_img = false;
                            TempData["Result"] = "5";
                        }
                    }
                    else
                    {
                        customermaster_VM.customerMaster.ProfilePicture = customermaster_VM.customerMaster.LastProfilePicture;
                    }
                }
                else
                {
                    customermaster_VM.customerMaster.ProfilePicture = customermaster_VM.customerMaster.LastProfilePicture;
                }
            }
            else
            {
                customermaster_VM.customerMaster.ProfilePicture = customermaster_VM.customerMaster.LastProfilePicture;
            }



            var result = CustomerMaster.Insert_Data(customermaster_VM.customerMaster);

            if (!string.IsNullOrEmpty(result))
            {
                var statusObj = JObject.Parse(result);
                if (validate_img)
                {
                    TempData["Result"] = 1;
                }
                TempData["ID"] = (string)statusObj["Id"];
            }
            else
            {
                TempData["Result"] = "0";
            }
            return RedirectToAction("Index");
        }
        public ActionResult InsertCustomerAddressData(CustomerMaster_ViewModel customermaster_VM)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];
            var result = CustomerAddressMaster.Insert_Data(customermaster_VM.customerAddressMaster);
            //return Json("Data inserted successfully", JsonRequestBehavior.AllowGet);

            if (!string.IsNullOrEmpty(result))
            {
                var statusObj = JObject.Parse(result);
                TempData["Result"] = 1;
                TempData["ID"] = (string)statusObj["Customer_Id"];
            }
            else
            {
                TempData["Result"] = "0";
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCustomerAddress(int Id, int CId)
        {
            int i = CustomerAddressMaster.DeleteCustomerAddress(Id);
            TempData["Result"] = i;
            TempData["ID"] = CId;
            return RedirectToAction("Index");

        }
        public JsonResult GetCustomerAddressDataById(int Id)
        {
            var data = CustomerAddressMaster.GetDataById(Id);
            //data.lst_country = CustomerMaster.GetCountryListing();
            return Json(data.customerAddresMaster, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChangePassword(CustomerMaster_ViewModel customermaster_VM)
        {
            var result = CustomerMaster.Change_Password(customermaster_VM.customerMaster);

            var statusObj = JObject.Parse(result);
            TempData["Result"] = (string)statusObj["Status"];
            TempData["ID"] = customermaster_VM.customerMaster.Id;
            return RedirectToAction("Index");
        }

        public ActionResult GetOrderById(string OrderId)
        {
            OrderMaster_ViewModel orderMasterVM = new OrderMaster_ViewModel();

            string result = string.Empty;

            result = obj_OrderMaster_BAL.GetByID(OrderId);

            orderMasterVM = JsonConvert.DeserializeObject<OrderMaster_ViewModel>(result);
           

            if (TempData["result"] != null)
            {
                ViewBag.Result = Convert.ToString(TempData["result"]);
            }
            return PartialView("_ViewOrderDetails", orderMasterVM);
        }

    }
}