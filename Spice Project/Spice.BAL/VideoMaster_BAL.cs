using Newtonsoft.Json;
using Spice.DAL;
using Spice.DataContarct.DataModel;
using System;
using System.Collections.Generic;

namespace Spice.BAL
{
    public class VideoMaster_BAL
    {
        public VideoMaster_BAL()
        {
            obj_Video_DAL = new VideoMaster_DAL();
        }

        readonly VideoMaster_DAL obj_Video_DAL;

        public string Insert_Update_Video(VideoMaster_DataModel Video_Model)
        {
            string result = "";
            List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();
            insert_Parameters.Add(new KeyValuePair<string, string>("@Video_Id", Convert.ToString(Video_Model.Video_Id)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Video_Name", Convert.ToString(Video_Model.Video_Name)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Video_Discription", Convert.ToString(Video_Model.Video_Discription)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Video_Url", Convert.ToString(Video_Model.Video_Url)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Receipe_Id", Convert.ToString(Video_Model.Receipe_Id)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Product_Id", Convert.ToString(Video_Model.Product_Id)));
            result = obj_Video_DAL.Insert_Update_Video(insert_Parameters);
            return result;
        }
        public VideoMaster_DataModel GetVideoById(int Video_Id)
        {
            VideoMaster_DataModel obj_CF = new VideoMaster_DataModel();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@Video_Id", Convert.ToString(Video_Id)));
            obj_CF = JsonConvert.DeserializeObject<VideoMaster_DataModel>(obj_Video_DAL.GetVideoById(getByID_Parameters));
            return obj_CF;
        }
        public List<VideoMaster_DataModel> GetVideoListing()
        {
            List<VideoMaster_DataModel> obj_lst_Video = new List<VideoMaster_DataModel>();
            List<KeyValuePair<string, string>> Parameters = new List<KeyValuePair<string, string>>();
            obj_lst_Video = JsonConvert.DeserializeObject<List<VideoMaster_DataModel>>(obj_Video_DAL.GetVideoListing(Parameters));
            return obj_lst_Video;
        }
    }
}
