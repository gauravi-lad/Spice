namespace Spice.DataContarct.DataModel
{
    public class VideoMaster_DataModel
    {
        public string Video_Id { get; set; }
        public string Video_Name { get; set; }
        public string Video_Url { get; set; }
        public string Video_Discription { get; set; }
        public int Receipe_Id { get; set; }
        public int Product_Id { get; set; }

        public string ReceipeName { get; set; }

        public string ProductName { get; set; }
    }
}
