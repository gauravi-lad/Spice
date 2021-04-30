using Spice.BAL;
using Spice.DataContarct.DataModel;
using Spice.DataContarct.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Spice.Web.Controllers
{
    public class ProductController : Controller
    {

        public ProductController()
        {
            obj_Product = new Product_BAL();
        }

        readonly Product_BAL obj_Product;

        public ActionResult Index()
        {
            Product_ViewModel obj_ProductVM = new Product_ViewModel();
            if (TempData["Result"] != null)
                ViewBag.Result = TempData["Result"].ToString();

            obj_ProductVM.lst_ProductCategory = obj_Product.GetAllCategory();

            return View("ProductMaster", obj_ProductVM);
        }

        public ActionResult Search()
        {

            Product_ViewModel obj_ProductVM = new Product_ViewModel();
            obj_ProductVM.lst_Product = obj_Product.GetAllProducts();
            return View("Search", obj_ProductVM);
        }

        [HttpPost]
        public ActionResult InsertUpdateProductDetails(Product_ViewModel obj_ProductVM)
        {
            bool _result = false;
            List<HttpPostedFileBase> fileArray = new List<HttpPostedFileBase>();
            Dictionary<string, int> Image_Number = new Dictionary<string, int>();
            string filePath = Server.MapPath(ConfigurationManager.AppSettings["ProductImage"].ToString());
            HttpPostedFileBase file1 = Request.Files["ImageData1"];

            if (file1 != null)
            {
                if (file1.FileName != "")
                {
                    Image_Number.Add(file1.FileName, 1);
                }
            }
            HttpPostedFileBase file2 = Request.Files["ImageData2"];
            if (file2 != null)
            {
                if (file2.FileName != "")
                {
                    Image_Number.Add(file2.FileName, 2);
                }
            }
            HttpPostedFileBase file3 = Request.Files["ImageData3"];
            if (file3 != null)
            {
                if (file3.FileName != "")
                {
                    Image_Number.Add(file3.FileName, 3);
                }
            }
            HttpPostedFileBase file4 = Request.Files["ImageData4"];
            if (file4 != null)
            {
                if (file4.FileName != "")
                {
                    Image_Number.Add(file4.FileName, 4);
                }
            }
            HttpPostedFileBase file5 = Request.Files["ImageData5"];
            if (file5 != null)
            {
                if (file5.FileName != "")
                {
                    Image_Number.Add(file5.FileName, 5);
                }
            }

            if (obj_ProductVM.Product.ProductId != 0)
            {
                if (file1.FileName != "")
                {
                    if (file1.FileName != obj_ProductVM.Product.ProductImage1)
                    {
                        if (System.IO.File.Exists(filePath + "\\" + obj_ProductVM.Product.ProductImage1))
                        {
                            System.IO.File.Delete(filePath + "\\" + obj_ProductVM.Product.ProductImage1);
                        }
                        fileArray.Add(file1);
                    }
                }
                if (file2.FileName != "")
                {
                    if (file2.FileName != obj_ProductVM.Product.ProductImage2)
                    {
                        if (System.IO.File.Exists(filePath + "\\" + obj_ProductVM.Product.ProductImage2))
                        {
                            System.IO.File.Delete(filePath + "\\" + obj_ProductVM.Product.ProductImage2);
                        }
                        fileArray.Add(file2);
                    }
                }
                if (file3.FileName != "")
                {
                    if (file1.FileName != obj_ProductVM.Product.ProductImage3)
                    {
                        if (System.IO.File.Exists(filePath + "\\" + obj_ProductVM.Product.ProductImage3))
                        {
                            System.IO.File.Delete(filePath + "\\" + obj_ProductVM.Product.ProductImage3);
                        }
                        fileArray.Add(file3);
                    }
                }
                if (file4.FileName != "")
                {
                    if (file4.FileName != obj_ProductVM.Product.ProductImage4)
                    {
                        if (System.IO.File.Exists(filePath + "\\" + obj_ProductVM.Product.ProductImage4))
                        {
                            System.IO.File.Delete(filePath + "\\" + obj_ProductVM.Product.ProductImage4);
                        }
                        fileArray.Add(file4);
                    }
                }
                if (file5.FileName != "")
                {
                    if (file1.FileName != obj_ProductVM.Product.ProductImage5)
                    {
                        if (System.IO.File.Exists(filePath + "\\" + obj_ProductVM.Product.ProductImage5))
                        {
                            System.IO.File.Delete(filePath + "\\" + obj_ProductVM.Product.ProductImage5);
                        }
                        fileArray.Add(file5);
                    }
                }
            }
            else
            {

                if (file1.FileName != "")
                {
                    fileArray.Add(file1);
                }
                if (file2.FileName != "")
                {
                    fileArray.Add(file2);
                }
                if (file3.FileName != "")
                {
                    fileArray.Add(file3);
                }
                if (file4.FileName != "")
                {
                    fileArray.Add(file4);
                }
                if (file5.FileName != "")
                {
                    fileArray.Add(file5);
                }
            }

            _result=obj_Product.Add(obj_ProductVM, fileArray, Image_Number);
           
               if(_result==true)
               {
                if(obj_ProductVM.Product.ProductId == 0)
                {
                    TempData["Result"] = 1;
                }
                else
                {
                    TempData["Result"] = 2;
                }
                
               }
               else
               {
                TempData["Result"] = 3;
               }
                
           
            return RedirectToAction("Index");
        }

        public ActionResult GetAllProducts()
        {
            Product_ViewModel obj_ProductVM = new Product_ViewModel();
            obj_ProductVM.lst_Product = obj_Product.GetAllProducts();

            return Json(obj_ProductVM.lst_Product, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProductById(int ProductId)
        {
            Product_ViewModel obj_ProductVM = new Product_ViewModel();
            obj_ProductVM.lst_ProductCategory = obj_Product.GetAllCategory();
            obj_ProductVM.drp_lst_ProductCategor = obj_Product.GetCategoriesByProductId(ProductId);
            obj_ProductVM._DocumentInfoList = obj_Product.GetAllImageById(ProductId);
            obj_ProductVM.Product = obj_Product.GetProductById(ProductId);
            foreach (var item in obj_ProductVM._DocumentInfoList)
            {
                if (item.ImageNo == 1)
                { obj_ProductVM.Product.ProductImage1 = item.UniqueFileName; }
                if (item.ImageNo == 2)
                { obj_ProductVM.Product.ProductImage2 = item.UniqueFileName; }
                if (item.ImageNo == 3)
                { obj_ProductVM.Product.ProductImage3 = item.UniqueFileName; }
                if (item.ImageNo == 4)
                { obj_ProductVM.Product.ProductImage4 = item.UniqueFileName; }
                if (item.ImageNo == 5)
                { obj_ProductVM.Product.ProductImage5 = item.UniqueFileName; }
            }
            return View("ProductMaster", obj_ProductVM);
        }

        public JsonResult GetPSCategoryByCategoryId(int CategoryId)

        {
            //List<SubCategory_DataModel> _lstSubCategory = new List<SubCategory_DataModel>();
            Product_ViewModel obj_ProductVM = new Product_ViewModel();

            obj_ProductVM.lst_ProductSubCategory = obj_Product.GetAllSubCategoryByCategoryId(CategoryId);

            return Json(obj_ProductVM.lst_ProductSubCategory, JsonRequestBehavior.AllowGet);
        }

    }
}