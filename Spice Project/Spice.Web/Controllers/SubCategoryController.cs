using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Spice.BAL;
using Spice.CommanUtilities;
using Spice.DataContarct.DataModel;
using Spice.DataContarct.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Mvc;

namespace Spice.Web.Controllers
{
    public class SubCategoryController : Controller
    {
        public SubCategoryController()
        {
            obj_SubCategory_BAL = new SubCategory_BAL();
        }

        readonly SubCategory_BAL obj_SubCategory_BAL;

        public ActionResult SubCategoryMaster()
        {
            if (TempData["Result"] != null)
                ViewBag.Result = TempData["Result"].ToString();
            SubCategory_ViewModel SubCategory_VM = new SubCategory_ViewModel();
            return View(SubCategory_VM);
        }

        #region SubCategory CRUD OPERATIONS

        [HttpPost]
        public ActionResult Insert_Update(SubCategory_ViewModel SubCategory_VM)
        {
            try
            {
                string filePath = Server.MapPath(ConfigurationManager.AppSettings["SubCategoryImage"].ToString());
                HttpPostedFileBase file = Request.Files["ImageData1"];
                if (SubCategory_VM.subCategory.Id != null)
                {
                    if (file.FileName != "")
                    {
                        if (file.FileName != SubCategory_VM.subCategory.SubCategoryImage)
                        {
                            if (System.IO.File.Exists(filePath + "\\" + SubCategory_VM.subCategory.SubCategoryImage))
                            {
                                System.IO.File.Delete(filePath + "\\" + SubCategory_VM.subCategory.SubCategoryImage);
                            }

                        }
                    }

                }

                var result = obj_SubCategory_BAL.Insert_Update(SubCategory_VM.subCategory,file);
                if (result != "")
                {
                    //var statusObj = JObject.Parse(result);
                    //TempData["Result"] = (string)statusObj["Status"];
                    TempData["Result"] = result;
                }
                else
                {
                    TempData["Result"] = "0";
                }
            }
            catch (Exception ex)
            {
                TempData["Result"] = "0";

                Logger.log(ex.Message, Convert.ToString(LogDirectory.Spice_Exception_Log));
            }
            return RedirectToAction("SubCategoryMaster");
        }

        public ActionResult Get_Listing(string SubCategoryName, string CategoryId)
        {
            SubCategory_ViewModel SubCategory_VM = new SubCategory_ViewModel();
            try
            {
                SubCategory_VM.lst_subCategory = JsonConvert.DeserializeObject<List<SubCategory_DataModel>>(obj_SubCategory_BAL.Get_Listing(SubCategoryName, CategoryId));
            }
            catch (Exception ex)
            {
                Logger.log(ex.Message, Convert.ToString(LogDirectory.Spice_Exception_Log));
            }
            return Json(SubCategory_VM.lst_subCategory, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetByID(string Id)
        {
            SubCategory_ViewModel SubCategory_VM = new SubCategory_ViewModel();
            try
            {
                SubCategory_VM.subCategory = JsonConvert.DeserializeObject<SubCategory_DataModel>(obj_SubCategory_BAL.GetByID(Id));
            }
            catch (Exception ex)
            {
                Logger.log(ex.Message, Convert.ToString(LogDirectory.Spice_Exception_Log));
            }
            return View(SubCategory_VM);
        }

        public JsonResult Delete_SubCategory(string Id)
        {

            var result = obj_SubCategory_BAL.Delete_SubCategory(Id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckExisting_SubCategoryCode(string SubCategoryCode)
        {
            bool check = false;
            try
            {
                check = obj_SubCategory_BAL.CheckExisting_SubCategoryCode(SubCategoryCode);
            }
            catch (Exception ex)
            {
                Logger.log(ex.Message, Convert.ToString(LogDirectory.Spice_Exception_Log));
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}