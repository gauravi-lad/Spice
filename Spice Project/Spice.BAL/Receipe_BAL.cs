using Newtonsoft.Json;
using Spice.DAL;
using Spice.DataContarct.DataModel;
using System;
using System.Collections.Generic;

namespace Spice.BAL
{
    public class Receipe_BAL
    {
        public Receipe_BAL()
        {
            obj_ReceipeDAL = new Receipe_DAL();
        }

        Receipe_DAL obj_ReceipeDAL;
        #region Receipe Crud
        public string InsertReceipe(Receipe_DataModel receipe)
        {
            string result = "";
            List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();
            insert_Parameters.Add(new KeyValuePair<string, string>("@ReceipeId", Convert.ToString(receipe.ReceipeId)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@ReceipeName", receipe.ReceipeName));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Description", receipe.Description));
            insert_Parameters.Add(new KeyValuePair<string, string>("@ProductId", Convert.ToString(receipe.ProductId)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@IsActive", Convert.ToString(receipe.IsActive)));

            result = obj_ReceipeDAL.Insert(insert_Parameters);
            return result;
        }
        public Receipe_DataModel GetReceipeById(int ReceipeId)
        {
            Receipe_DataModel obj_receipe = new Receipe_DataModel();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@ReceipeId", Convert.ToString(ReceipeId)));
            obj_receipe = JsonConvert.DeserializeObject<Receipe_DataModel>(obj_ReceipeDAL.GetByID(getByID_Parameters));
            return obj_receipe;
        }
        public List<Receipe_DataModel> GetReceipeListing()
        {
            List<Receipe_DataModel> obj_lst_receipe = new List<Receipe_DataModel>();
            List<KeyValuePair<string, string>> Parameters = new List<KeyValuePair<string, string>>();
            obj_lst_receipe = JsonConvert.DeserializeObject<List<Receipe_DataModel>>(obj_ReceipeDAL.Get_Listing(Parameters));
            return obj_lst_receipe;
        }
        public int DeleteReceipe(int ReceipeId)
        {
            Receipe_DataModel obj_receipe = new Receipe_DataModel();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@ReceipeId", Convert.ToString(ReceipeId)));
            obj_receipe = JsonConvert.DeserializeObject<Receipe_DataModel>(obj_ReceipeDAL.DeleteByID(getByID_Parameters));
            return 1;
        }
        public List<Receipe_DataModel> GetReceipeByProductId(int ProductId)
        {
            List<Receipe_DataModel> obj_lst_receipe = new List<Receipe_DataModel>();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@ProductId", Convert.ToString(ProductId)));
            obj_lst_receipe = JsonConvert.DeserializeObject<List<Receipe_DataModel>>(obj_ReceipeDAL.GetReceipeByProductId(getByID_Parameters));
            return obj_lst_receipe;
        }
        #endregion
    }
}
