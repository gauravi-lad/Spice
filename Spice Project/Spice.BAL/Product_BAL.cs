using Newtonsoft.Json;
using Spice.DAL;
using Spice.DataContarct.DataModel;
using Spice.DataContarct.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq.Expressions;
using System.Web;

namespace Spice.BAL
{
    public class Product_BAL
    {
        public Product_BAL()
        {
            Product = new Product_DAL();

            product_Image_Bal = new ProductImage_BAL();

            ProductImage = new ProductImage_DAL();
        }

        readonly Product_DAL Product;

        readonly ProductImage_DAL ProductImage;

        ProductImage_BAL product_Image_Bal;

        bool Result = false;

        public bool Add(Product_ViewModel obj_ProductVM, List<HttpPostedFileBase> files, Dictionary<string, int> imageNumber)
        {
            try
            {
                string[] SubCategoryIdList = { };
                int ProductId = 0;
                bool IsDefault = true;

                List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();
                insert_Parameters.Add(new KeyValuePair<string, string>("@ID", Convert.ToString(obj_ProductVM.Product.ProductId)));
                insert_Parameters.Add(new KeyValuePair<string, string>("@ProductCode", obj_ProductVM.Product.ProductCode));
                insert_Parameters.Add(new KeyValuePair<string, string>("@ProductName", obj_ProductVM.Product.ProductName));
                insert_Parameters.Add(new KeyValuePair<string, string>("@Product_Short_Desc", obj_ProductVM.Product.Product_Short_Desc));
                insert_Parameters.Add(new KeyValuePair<string, string>("@Product_Long_Desc", obj_ProductVM.Product.Product_Long_Desc));
                insert_Parameters.Add(new KeyValuePair<string, string>("@Product_Features", obj_ProductVM.Product.Product_Features));
                insert_Parameters.Add(new KeyValuePair<string, string>("@IsActive", Convert.ToString(obj_ProductVM.Product.IsActive)));
                insert_Parameters.Add(new KeyValuePair<string, string>("@IsRefundable", Convert.ToString(obj_ProductVM.Product.IsRefundable)));
                insert_Parameters.Add(new KeyValuePair<string, string>("@IsFeatured", Convert.ToString(obj_ProductVM.Product.IsFeatured)));
                insert_Parameters.Add(new KeyValuePair<string, string>("@IsRecommended", Convert.ToString(obj_ProductVM.Product.IsRecommended)));
                insert_Parameters.Add(new KeyValuePair<string, string>("@CreatedBy", Convert.ToString(1)));
                insert_Parameters.Add(new KeyValuePair<string, string>("@CreatedDate", Convert.ToString(DateTime.Now)));
                insert_Parameters.Add(new KeyValuePair<string, string>("@UpdatedBy", Convert.ToString(1)));
                insert_Parameters.Add(new KeyValuePair<string, string>("@UpdatedDate", Convert.ToString(DateTime.Now)));
                insert_Parameters.Add(new KeyValuePair<string, string>("@OriginationAndHistory", obj_ProductVM.Product.OriginationAndHistory));
                insert_Parameters.Add(new KeyValuePair<string, string>("@Types", obj_ProductVM.Product.Types));
                insert_Parameters.Add(new KeyValuePair<string, string>("@Appearance", obj_ProductVM.Product.Appearance));
                insert_Parameters.Add(new KeyValuePair<string, string>("@Constituents", obj_ProductVM.Product.Constituents));
                insert_Parameters.Add(new KeyValuePair<string, string>("@KnownInLanguage", obj_ProductVM.Product.KnownInLanguage));
                insert_Parameters.Add(new KeyValuePair<string, string>("@HealthBenefit", obj_ProductVM.Product.HealthBenefit));
                string i = Product.Insert(insert_Parameters);

                ProductPKId pkobj = JsonConvert.DeserializeObject<ProductPKId>(i);
                ProductId = Convert.ToInt32(Convert.ToDecimal(pkobj.ProductId));

                if (obj_ProductVM.Product.ProductId != 0)
                {
                    ProductId = obj_ProductVM.Product.ProductId;
                }

                if (!string.IsNullOrEmpty(obj_ProductVM.Product.SubCategoryId))
                {
                    SubCategoryIdList = obj_ProductVM.Product.SubCategoryId.Split(',');
                    if (obj_ProductVM.Product.ProductId != 0)
                    {
                        List<KeyValuePair<string, string>> delete_By_Parameters = new List<KeyValuePair<string, string>>();

                        delete_By_Parameters.Add(new KeyValuePair<string, string>("@Product_ID", Convert.ToString(obj_ProductVM.Product.ProductId)));
                        Product.DeleteExistingCategoryByProductId(delete_By_Parameters);
                    }
                    foreach (var item in SubCategoryIdList)
                    {
                        List<KeyValuePair<string, string>> insert_Parameters_For_Product_Category = new List<KeyValuePair<string, string>>();
                        insert_Parameters_For_Product_Category.Add(new KeyValuePair<string, string>("@ProductId", Convert.ToString(ProductId)));
                        insert_Parameters_For_Product_Category.Add(new KeyValuePair<string, string>("@CategoryId", Convert.ToString(item)));

                        Product.Insert_Product_Sub_Category_Mapping(insert_Parameters_For_Product_Category);
                    }

                }

                if (files.Count > 0)
                {
                    foreach (var item in files)
                    {
                        UploadImage("ProductImage", item, ProductId, imageNumber);
                    }
                }
                Result = true;
            }
            catch(Exception ex)
            {
                Result = false;
            }
            return Result;
        }

        public void UploadImage(string FormName, HttpPostedFileBase file, int ProductId, Dictionary<string, int> imageNumber)
        {

            string message = string.Empty;

            var ResumefileName = "";

            var Resumepath = "";

            string ResumeDirectory = "";

            string UniqueFilename = "";

            bool IsDefaultImage = false;

            try
            {
                if (file != null)
                {
                    if (FormName != string.Empty)
                    {
                        if (FormName == "ProductImage")
                        {
                            ResumeDirectory = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ProductImage"].ToString());
                        }
                        int imageNo = imageNumber[file.FileName];

                        if (imageNo == 1)
                        {
                            IsDefaultImage = true;
                        }

                        ResumefileName = Path.GetFileName(file.FileName);
                        string[] ext = ResumefileName.Split('.');
                        string extension = Path.GetExtension(file.FileName);
                        bool directoryExists = System.IO.Directory.Exists(ResumeDirectory);

                        if (!directoryExists)
                        {
                            System.IO.Directory.CreateDirectory(ResumeDirectory);
                        }

                        List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();

                        insert_Parameters.Add(new KeyValuePair<string, string>("@ProductId", Convert.ToString(ProductId)));

                        insert_Parameters.Add(new KeyValuePair<string, string>("@Image", Convert.ToString(file.FileName)));
                        insert_Parameters.Add(new KeyValuePair<string, string>("@ext", Convert.ToString(extension)));
                        insert_Parameters.Add(new KeyValuePair<string, string>("@ImageNo", Convert.ToString(imageNo)));

                        insert_Parameters.Add(new KeyValuePair<string, string>("@IsDefaultImage", Convert.ToString(IsDefaultImage)));
                        insert_Parameters.Add(new KeyValuePair<string, string>("@CreatedBy", Convert.ToString(1)));
                        insert_Parameters.Add(new KeyValuePair<string, string>("@CreatedDate", Convert.ToString(DateTime.Now)));
                        insert_Parameters.Add(new KeyValuePair<string, string>("@UpdatedBy", Convert.ToString(1)));
                        insert_Parameters.Add(new KeyValuePair<string, string>("@UpdatedDate", Convert.ToString(DateTime.Now)));
                        UniqueFilename = ProductImage.Insert(insert_Parameters);

                        ProductImage_DataModel datalist = JsonConvert.DeserializeObject<ProductImage_DataModel>(UniqueFilename);
                        ResumefileName = datalist.UniqueFileName;

                        Resumepath = Path.Combine(ResumeDirectory, ResumefileName);
                        file.SaveAs(Resumepath);
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }

        }



        public void UpdateUploadImage(string FormName, HttpPostedFileBase file, int ProductId, bool IsDefaultImage, Dictionary<string, int> imageNumber)
        {

            string message = string.Empty;

            var ResumefileName = "";

            var Resumepath = "";

            string ResumeDirectory = "";

            string UniqueFilename = "";

            try
            {
                if (file != null)
                {
                    if (FormName != string.Empty)
                    {
                        if (FormName == "ProductImage")
                        {
                            ResumeDirectory = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ProductImage"].ToString());
                        }
                        int imageNo = imageNumber[file.FileName];
                        ResumefileName = Path.GetFileName(file.FileName);
                        string[] ext = ResumefileName.Split('.');

                        bool directoryExists = System.IO.Directory.Exists(ResumeDirectory);

                        if (!directoryExists)
                        {
                            System.IO.Directory.CreateDirectory(ResumeDirectory);
                        }

                        List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();

                        insert_Parameters.Add(new KeyValuePair<string, string>("@ProductId", Convert.ToString(ProductId)));

                        insert_Parameters.Add(new KeyValuePair<string, string>("@Image", Convert.ToString(file.FileName)));
                        insert_Parameters.Add(new KeyValuePair<string, string>("@ImageNo", Convert.ToString(imageNo)));

                        insert_Parameters.Add(new KeyValuePair<string, string>("@IsDefaultImage", Convert.ToString(IsDefaultImage)));
                        insert_Parameters.Add(new KeyValuePair<string, string>("@CreatedBy", Convert.ToString(1)));
                        insert_Parameters.Add(new KeyValuePair<string, string>("@CreatedDate", Convert.ToString(DateTime.Now)));
                        insert_Parameters.Add(new KeyValuePair<string, string>("@UpdatedBy", Convert.ToString(1)));
                        insert_Parameters.Add(new KeyValuePair<string, string>("@UpdatedDate", Convert.ToString(DateTime.Now)));
                        UniqueFilename = ProductImage.Insert(insert_Parameters);

                        ProductImage_DataModel datalist = JsonConvert.DeserializeObject<ProductImage_DataModel>(UniqueFilename);
                        ResumefileName = datalist.UniqueFileName;

                        Resumepath = Path.Combine(ResumeDirectory, ResumefileName);
                        file.SaveAs(Resumepath);
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }

        }

        public List<Product_DataModel> GetAllProducts()
        {
            Product_ViewModel obj_ProductVM = new Product_ViewModel();

            List<KeyValuePair<string, string>> listing_Parameters = new List<KeyValuePair<string, string>>();

            return obj_ProductVM.lst_Product = JsonConvert.DeserializeObject<List<Product_DataModel>>(Product.Get_Listing(listing_Parameters));
        }

        public Product_DataModel GetProductById(int ProductId)
        {
            Product_ViewModel obj_ProductVM = new Product_ViewModel();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@ID", Convert.ToString(ProductId)));
            return obj_ProductVM.Product = JsonConvert.DeserializeObject<Product_DataModel>(Product.GetByID(getByID_Parameters));

        }

        public List<CategoryMasterDataModel> GetCategoriesByProductId(int ProductId)
        {
            Product_ViewModel obj_ProductVM = new Product_ViewModel();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@ID", Convert.ToString(ProductId)));
            return obj_ProductVM.lst_ProductCategory = JsonConvert.DeserializeObject<List<CategoryMasterDataModel>>(Product.Get_Listing_Of_Product_Category(getByID_Parameters));
            // obj_ProductVM.Product = JsonConvert.DeserializeObject<CategoryMasterDataModel>(Product.GetByID(getByID_Parameters));

        }

        public List<ProductImage_DataModel> GetAllImageById(int ProductId)
        {
            Product_ViewModel obj_ProductVM = new Product_ViewModel();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@ID", Convert.ToString(ProductId)));
            return obj_ProductVM._DocumentInfoList = JsonConvert.DeserializeObject<List<ProductImage_DataModel>>(Product.Get_Listing_Of_Product_Image(getByID_Parameters));

        }

        public List<CategoryMasterDataModel> GetAllCategory()
        {
            Product_ViewModel obj_ProductVM = new Product_ViewModel();

            List<KeyValuePair<string, string>> listing_Parameters = new List<KeyValuePair<string, string>>();

            return obj_ProductVM.lst_ProductCategory = JsonConvert.DeserializeObject<List<CategoryMasterDataModel>>(Product.Get_All_Categories(listing_Parameters));
        }

        public List<SubCategory_DataModel> GetAllSubCategoryByCategoryId(int CategoryId)
        {
            Product_ViewModel obj_ProductVM = new Product_ViewModel();

            List<KeyValuePair<string, string>> listing_Parameters = new List<KeyValuePair<string, string>>();
            listing_Parameters.Add(new KeyValuePair<string, string>("@ID", Convert.ToString(CategoryId)));


            return obj_ProductVM.lst_ProductSubCategory = JsonConvert.DeserializeObject<List<SubCategory_DataModel>>(Product.GetSubCategoryByCategoryID(listing_Parameters));
        }
        public List<Product_DataModel> GetAllProductsWithCategory()
        {
            Product_ViewModel obj_ProductVM = new Product_ViewModel();

            List<KeyValuePair<string, string>> listing_Parameters = new List<KeyValuePair<string, string>>();

            return obj_ProductVM.lst_Product = JsonConvert.DeserializeObject<List<Product_DataModel>>(Product.GetProductWithCategory(listing_Parameters));
        }
        //public List<SubCategory_DataModel> GetAllSubCategoryByCategoryId(int CategoryId)
        //{
        //    Product_ViewModel obj_ProductVM = new Product_ViewModel();
        //    List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
        //    //getByID_Parameters.Add(new KeyValuePair<string, string>("@ID", Convert.ToString(CategoryId)));
        //    return obj_ProductVM.lst_ProductSubCategory = JsonConvert.DeserializeObject<List<SubCategory_DataModel>>(Product.GetSubCategoryByCategoryID(getByID_Parameters));

        //}

        class ProductPKId
        {
            public string ProductId { get; set; }

        }

    }
}
