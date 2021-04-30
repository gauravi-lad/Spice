using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Spice.DAL;
using Spice.DataContarct.DataModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;

namespace Spice.BAL
{
    public class CategoryMasterBAL
    {
        readonly CategoryMasterDAL CategoryMasterDAL = null;
        List<KeyValuePair<string, string>> parameters = null;
        public CategoryMasterBAL()
        {
            CategoryMasterDAL = new CategoryMasterDAL();
        }

        public string InsertCategory(CategoryMasterDataModel categoryMasterDataModel, HttpPostedFileBase file)
        {
            string Status = string.Empty;
            int Category_Id = 0;
          
            parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("@CategoryId", categoryMasterDataModel.CategoryId.ToString()));
            parameters.Add(new KeyValuePair<string, string>("@CategoryName", categoryMasterDataModel.CategoryName));
            parameters.Add(new KeyValuePair<string, string>("@CategoryShortDescription", categoryMasterDataModel.CategoryShortDescription));
            parameters.Add(new KeyValuePair<string, string>("@CategoryLongDescription", categoryMasterDataModel.CategoryLongDescription));
            parameters.Add(new KeyValuePair<string, string>("@IsActive", categoryMasterDataModel.IsActive.ToString()));
            parameters.Add(new KeyValuePair<string, string>("@CreatedBy", ""));
            parameters.Add(new KeyValuePair<string, string>("@ModifiedBy", ""));
            parameters.Add(new KeyValuePair<string, string>("@CategoryCode", categoryMasterDataModel.CategoryCode));
            var result= CategoryMasterDAL.InsertCategory(parameters);
            if (result != "")
            {
                var statusObj = JObject.Parse(result);
                Status= (string)statusObj["Status"]; 
                Category_Id = (int)statusObj["CategoryId"];
               
            }

            //if (file.FileName != null)
            if (!string.IsNullOrEmpty(file.FileName))
            {
                var ResumefileName = "";

                var Resumepath = "";

                string ResumeDirectory = "";

                string UniqueFilename = "";

                ResumeDirectory = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["CategoryImage"].ToString());
                
                string[] ext = ResumefileName.Split('.');
                string extension = Path.GetExtension(file.FileName);
                bool directoryExists = System.IO.Directory.Exists(ResumeDirectory);

                if (!directoryExists)
                {
                    System.IO.Directory.CreateDirectory(ResumeDirectory);
                }
                ResumefileName = categoryMasterDataModel.CategoryName.Substring(0, 3) + "_Img_" + Category_Id + extension;

                Resumepath = Path.Combine(ResumeDirectory, ResumefileName);
                file.SaveAs(Resumepath);

                parameters = new List<KeyValuePair<string, string>>();
                parameters.Add(new KeyValuePair<string, string>("@CategoryId", Convert.ToString(Category_Id)));
                parameters.Add(new KeyValuePair<string, string>("@Filename", ResumefileName));
                CategoryMasterDAL.UpdateCategoryImage(parameters);

            }
            return Status;
        }
        public List<CategoryMasterDataModel> GetCategoryList()
        {
            List<CategoryMasterDataModel> obj_lst_categoy = new List<CategoryMasterDataModel>();
            List<KeyValuePair<string, string>> Parameters = new List<KeyValuePair<string, string>>();
            obj_lst_categoy = JsonConvert.DeserializeObject<List<CategoryMasterDataModel>>(CategoryMasterDAL.GetCategoryList(Parameters));
            return obj_lst_categoy;
        }       
        public string GetByCategoryId(int CategoryId)
        {
            parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("@CategoryId", CategoryId.ToString()));
            return CategoryMasterDAL.GetByCategoryId(parameters);
        }

        public bool CheckExisting_CategoryCode(string CategoryCode)
        {
            bool flag = false;
            parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("@CategoryCode", CategoryCode));
            //return  Convert.ToBoolean(CategoryMasterDAL.CheckCategoryExist(parameters));
            var result = CategoryMasterDAL.CheckCategoryExist(parameters);
            if (result != "")
            {
                var statusObj = JObject.Parse(result);
                
                flag = (bool)statusObj["categoryExist"];

            }
            return flag;

        }

    }
}
