using Spice.DataContarct.DataModel;
using System.Collections.Generic;

namespace Spice.DataContarct.ViewModel
{
    public class VideoMaster_ViewModel
    {
        public VideoMaster_ViewModel()
        {
            Video = new VideoMaster_DataModel();
            lst_Video = new List<VideoMaster_DataModel>();
            lst_Product = new List<Product_DataModel>();
            lst_Receipe = new List<Receipe_DataModel>();
        }

        public VideoMaster_DataModel Video { get; set; }
        public List<VideoMaster_DataModel> lst_Video { get; set; }

        public List<Product_DataModel> lst_Product { get; set; }

        public List<Receipe_DataModel> lst_Receipe { get; set; }
    }
}
