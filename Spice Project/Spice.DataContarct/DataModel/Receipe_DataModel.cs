namespace Spice.DataContarct.DataModel
{
    public class Receipe_DataModel
    {
        public int ReceipeId { get; set; }
        public string ReceipeName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
