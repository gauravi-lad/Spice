using Newtonsoft.Json;
using Spice.DAL;
using Spice.DataContarct.DataModel;
using System;
using System.Collections.Generic;

namespace Spice.BAL
{
    public class Blog_BAL
    {
        public Blog_BAL()
        {
            obj_Blog_DAL = new Blog_DAL();
        }

        readonly Blog_DAL obj_Blog_DAL;

        public string Insert_Update_Blog(BlogDataModel Blog_Model)
        {
            string result = "";
            List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();
            insert_Parameters.Add(new KeyValuePair<string, string>("@Blog_Id", Convert.ToString(Blog_Model.Blog_Id)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Blog_Name", Convert.ToString(Blog_Model.Blog_Name)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Blog_Discription", Convert.ToString(Blog_Model.Blog_Discription)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Product_Id", Convert.ToString(Blog_Model.Product_Id)));
            result = obj_Blog_DAL.Insert_Update_Blog(insert_Parameters);
            return result;
        }
        public BlogDataModel GetBlogById(int Id)
        {
            BlogDataModel obj_CF = new BlogDataModel();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@Blog_Id", Convert.ToString(Id)));
            obj_CF = JsonConvert.DeserializeObject<BlogDataModel>(obj_Blog_DAL.GetBlogById(getByID_Parameters));
            return obj_CF;
        }
        public List<BlogDataModel> GetBlogListing()
        {
            List<BlogDataModel> obj_lst_blog = new List<BlogDataModel>();
            List<KeyValuePair<string, string>> Parameters = new List<KeyValuePair<string, string>>();
            obj_lst_blog = JsonConvert.DeserializeObject<List<BlogDataModel>>(obj_Blog_DAL.GetBlogListing(Parameters));
            return obj_lst_blog;
        }
    }
}
