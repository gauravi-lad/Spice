using Newtonsoft.Json.Linq;
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
    public class SubCategory_BAL
    {
        public SubCategory_BAL()
        {
            obj_SubCategory_DAL = new SubCategory_DAL();
        }

        readonly SubCategory_DAL obj_SubCategory_DAL;

        public string Insert_Update(SubCategory_DataModel SubCategory_DM, HttpPostedFileBase file)
        {
            string Status = string.Empty;
            int Sub_Category_Id = 0;
            List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();
            insert_Parameters.Add(new KeyValuePair<string, string>("@Id", SubCategory_DM.Id));
            insert_Parameters.Add(new KeyValuePair<string, string>("@CategoryId", SubCategory_DM.CategoryId));
            insert_Parameters.Add(new KeyValuePair<string, string>("@SubCategoryName", SubCategory_DM.SubCategoryName));
            insert_Parameters.Add(new KeyValuePair<string, string>("@SubCategoryDesc", SubCategory_DM.SubCategoryDesc));           
            insert_Parameters.Add(new KeyValuePair<string, string>("@IsActive", Convert.ToString(SubCategory_DM.IsActive)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@CreatedBy",""));
            insert_Parameters.Add(new KeyValuePair<string, string>("@SubCategoryCode", SubCategory_DM.SubCategoryCode));

            var result = obj_SubCategory_DAL.Insert_Update(insert_Parameters);
            //var result = CategoryMasterDAL.InsertCategory(parameters);
            if (result != "")
            {
                var statusObj = JObject.Parse(result);
                Status = (string)statusObj["Status"];
                Sub_Category_Id = (int)statusObj["SubCategoryId"];

            }
            //if (file != null)
            if (!string.IsNullOrEmpty(file.FileName))
            {
                var ResumefileName = "";

                var Resumepath = "";

                string ResumeDirectory = "";

                string UniqueFilename = "";

                ResumeDirectory = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["SubCategoryImage"].ToString());

                string[] ext = ResumefileName.Split('.');
                string extension = Path.GetExtension(file.FileName);
                bool directoryExists = System.IO.Directory.Exists(ResumeDirectory);

                if (!directoryExists)
                {
                    System.IO.Directory.CreateDirectory(ResumeDirectory);
                }
                ResumefileName = SubCategory_DM.SubCategoryName.Substring(0, 3) + "_Img_" + Sub_Category_Id + extension;

                Resumepath = Path.Combine(ResumeDirectory, ResumefileName);
                file.SaveAs(Resumepath);

                insert_Parameters = new List<KeyValuePair<string, string>>();
                insert_Parameters.Add(new KeyValuePair<string, string>("@SubCategoryId", Convert.ToString(Sub_Category_Id)));
                insert_Parameters.Add(new KeyValuePair<string, string>("@Filename", ResumefileName));
                obj_SubCategory_DAL.UpdateSubCategoryImage(insert_Parameters);

            }
            return Status;
        }

        public string Get_Listing(string SubCategoryName, string CategoryId)
        {
            List<KeyValuePair<string, string>> listing_Parameters = new List<KeyValuePair<string, string>>();           
            return obj_SubCategory_DAL.Get_Listing(listing_Parameters);
        }

        public string GetByID(string Id)
        {
            List<KeyValuePair<string, string>> details_Parameters = new List<KeyValuePair<string, string>>();
            details_Parameters.Add(new KeyValuePair<string, string>("@Id", Id));
            return obj_SubCategory_DAL.GetByID(details_Parameters);
        }

        public string Delete_SubCategory(string Id)
        {
            List<KeyValuePair<string, string>> details_Parameters = new List<KeyValuePair<string, string>>();
            details_Parameters.Add(new KeyValuePair<string, string>("@Id", Id));
            details_Parameters.Add(new KeyValuePair<string, string>("@Result", null));
            return obj_SubCategory_DAL.Delete_SubCategory(details_Parameters);
        }

        public bool CheckExisting_SubCategoryCode(string SubCategoryCode)
        {
            bool flag = false;
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("@SubCategoryCode", SubCategoryCode));
            //return Convert.ToBoolean(obj_SubCategory_DAL.CheckSubCategoryExist(parameters));
            //return  Convert.ToBoolean(CategoryMasterDAL.CheckCategoryExist(parameters));
            var result = obj_SubCategory_DAL.CheckSubCategoryExist(parameters);
            if (result != "")
            {
                var statusObj = JObject.Parse(result);

                flag = (bool)statusObj["subcategoryExist"];

            }
            return flag;

        }

        public List<CategoryMasterDataModel> GetSubCategoryListByCategoryId(int CategoryId)
        {
            List<CategoryMasterDataModel> obj_lst_categoy = new List<CategoryMasterDataModel>();
            List<KeyValuePair<string, string>> Parameters = new List<KeyValuePair<string, string>>();
            Parameters.Add(new KeyValuePair<string, string>("@CategoryId", CategoryId.ToString()));
            obj_lst_categoy = JsonConvert.DeserializeObject<List<CategoryMasterDataModel>>(obj_SubCategory_DAL.GetSubCategoryListByCategoryId(Parameters));
            return obj_lst_categoy;
        }
    }
}
 