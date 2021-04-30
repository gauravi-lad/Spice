namespace Spice.DataContarct.DataModel
{
    public class Vendor_DataModel
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public bool IsActive { get; set; }
        public string MobileNo { get; set; }
        public int State { get; set; }
        public int GST { get; set; }
        public string StateName { get; set; }
        public string GSTValue { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }

    }
    public class VendorProduct_DataModel
    {
        public int VendorProductId { get; set; }
        public int VendorId { get; set; }
        public int ProductId { get; set; }
        public int VendorPriority { get; set; }
        public double VendorPrice { get; set; }
        public bool IsActive { get; set; }
        public string VendorName { get; set; }
        public string ProductName { get; set; }
    }
}
