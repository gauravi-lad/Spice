namespace Spice.DataContarct.DataModel
{
    public class CustomerFavourites_DataModel
    {
        public int ID { get; set; }
        public int Customer_Id { get; set; }
        public int Product_Id { get; set; }

        public string Customer_Name { get; set; }
        public string  Product_Name { get; set; }

    }
}
