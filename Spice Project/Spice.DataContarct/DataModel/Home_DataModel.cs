namespace Spice.DataContarct.DataModel
{
    public class Home_DataModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Home_Data_SubModel subModule { get; set; }
    }

    public class Home_Data_SubModel
    {
        public int ID { get; set; }
        public string visited_City { get; set; }
    }

    public class demo_category
    {
        public int CategoryId { get; set; }

        public string CatagoryName { get; set; }

        public string CategoryDescription { get; set; }
    }

}
