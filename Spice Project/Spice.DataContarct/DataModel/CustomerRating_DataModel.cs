using System;

namespace Spice.DataContarct.DataModel
{
    public class CustomerRating_DataModel
    {
        public int Id { get; set; }

        public int Customer_Id { get; set; }
        public int Product_Id { get; set; }
        public int Rating { get; set; }
        public string Reviews { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public string Customer_Name { get; set; }
        public string Product_Name { get; set; }
    }
}
