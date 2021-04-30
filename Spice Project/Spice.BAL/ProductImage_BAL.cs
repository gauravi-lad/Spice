using Newtonsoft.Json;
using Spice.DAL;
using Spice.DataContarct.DataModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;

namespace Spice.BAL
{
    public class ProductImage_BAL
    {

        public ProductImage_BAL()
        {
            ProductImage = new ProductImage_DAL();
        }

        readonly ProductImage_DAL ProductImage;

        public void UploadDocument(string FormName, HttpPostedFileBase file, int ProductId, bool IsDefaultImage)
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

        public void UpdateUploadDocument(string FormName, HttpPostedFileBase file, int ProductId, string uniqeFileName, int DocumentId, bool IsDefaultImage)
        {

            string message = string.Empty;

            var ResumefileName = "";

            var Resumepath = "";

            string ResumeDirectory = "";

            try
            {
                if (FormName != string.Empty)
                {
                    if (FormName == "ProductSKUImage")
                    {
                        ResumeDirectory = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ProductSKUImageUpload"].ToString());
                    }

                    ResumefileName = Path.GetFileName(file.FileName);
                    string[] ext = ResumefileName.Split('.');
                    //ResumefileName = System.DateTime.Now.ToString("ddMMyyyyHHmmssfffff");

                    //Resumepath = Path.Combine(ResumeDirectory, ResumefileName);

                    bool directoryExists = System.IO.Directory.Exists(ResumeDirectory);

                    if (!directoryExists)
                    {
                        System.IO.Directory.CreateDirectory(ResumeDirectory);
                    }

                    if (System.IO.File.Exists(ResumeDirectory + "/" + uniqeFileName.ToString()))
                    {
                        System.IO.File.Delete(ResumeDirectory + "/" + uniqeFileName.ToString());
                    }
                    else
                    {
                        System.IO.File.Create(ResumeDirectory + "/" + uniqeFileName.ToString());
                    }

                    //file.SaveAs(Resumepath);

                    List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();
                    insert_Parameters.Add(new KeyValuePair<string, string>("@DocumentId", Convert.ToString(DocumentId)));
                    insert_Parameters.Add(new KeyValuePair<string, string>("@ProductId", Convert.ToString(ProductId)));
                    insert_Parameters.Add(new KeyValuePair<string, string>("@Image", Convert.ToString(file.FileName)));
                    insert_Parameters.Add(new KeyValuePair<string, string>("@UniqueFileName", Convert.ToString(uniqeFileName)));
                    insert_Parameters.Add(new KeyValuePair<string, string>("@IsDefaultImage", Convert.ToString(IsDefaultImage)));
                    insert_Parameters.Add(new KeyValuePair<string, string>("@UpdatedBy", Convert.ToString(1)));
                    insert_Parameters.Add(new KeyValuePair<string, string>("@UpdatedDate", Convert.ToString(DateTime.Now)));
                    ProductImage.Update(insert_Parameters);


                    Resumepath = Path.Combine(ResumeDirectory, uniqeFileName);
                    file.SaveAs(Resumepath);
                }
            }
            catch (Exception err)
            {
                throw err;
            }

        }

        public List<ProductImage_DataModel> GetProductImageListById(int ProductId)
        {
            List<ProductImage_DataModel> lst_ProductImage = new List<ProductImage_DataModel>();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@ProductId", Convert.ToString(ProductId)));
            return lst_ProductImage = JsonConvert.DeserializeObject<List<ProductImage_DataModel>>(ProductImage.GetProductImageListById(getByID_Parameters));
        }

    }
}
