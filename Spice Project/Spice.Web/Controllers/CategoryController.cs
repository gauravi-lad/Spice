using Newtonsoft.Json.Linq;
using Spice.BAL;
using Spice.CommanUtilities;
using Spice.DataContarct.ViewModel;
using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;

namespace Spice.Web.Controllers
{
    public class CategoryController : Controller
    {
        readonly CategoryMasterBAL CategoryMasterBAL = null;
        public CategoryController()
        {
            CategoryMasterBAL = new CategoryMasterBAL();
        }
     
        public ActionResult CategoryMaster()
        {
            if (TempData["Result"] != null)
                ViewBag.Result = TempData["Result"].ToString();
            return View();
        }
        public ActionResult GetCategoryListing()
        {
            CategoryMasterViewModel categoryMasterViewModel = new CategoryMasterViewModel();
            categoryMasterViewModel.lst_category = CategoryMasterBAL.GetCategoryList();
            return Json(categoryMasterViewModel.lst_category, JsonRequestBehavior.AllowGet);
        }
        public ActionResult InsertCategory(CategoryMasterViewModel categoryMasterViewModel)
        {
            string filePath = Server.MapPath(ConfigurationManager.AppSettings["CategoryImage"].ToString());
            HttpPostedFileBase file = Request.Files["ImageData1"];
            if (categoryMasterViewModel.category.CategoryId != 0)
            {
                if (file.FileName != "")
                {
                    if (file.FileName != categoryMasterViewModel.category.CategoryImage)
                    {
                        if (System.IO.File.Exists(filePath + "\\" + categoryMasterViewModel.category.CategoryImage))
                        {
                            System.IO.File.Delete(filePath + "\\" + categoryMasterViewModel.category.CategoryImage);
                        }

                    }
                }

            }
           

           var result = CategoryMasterBAL.InsertCategory(categoryMasterViewModel.category,file);
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
            
            return RedirectToAction("CategoryMaster");
        }

        public JsonResult CheckExisting_CategoryCode(string CategoryCode)
        {
            bool check = false;
            try
            {
                check = CategoryMasterBAL.CheckExisting_CategoryCode(CategoryCode);
            }
            catch (Exception ex)
            {
                Logger.log(ex.Message, Convert.ToString(LogDirectory.Spice_Exception_Log));
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }
    }
}
