namespace Spice.DataContarct.DataModel
{
    public class CartDataModel
    {
        public string Customer_ID { get; set; }
        public string Product_ID { get; set; }
        public string ProductSku_ID { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public string Amount { get; set; }
        public string image { get; set; }
        public string ProductName { get; set; }
        public decimal RatePerPc { get; set; }
        public decimal Total { get; set; }
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? VendorId { get; set; }
        public int UnitPrice { get; set; }
        public int Discount { get; set; }
        public int TaxId { get; set; }
        public int TaxAmmount { get; set; }
        public int FinalAmmount { get; set; }
        public string SKU { get; set; }
    }
}
