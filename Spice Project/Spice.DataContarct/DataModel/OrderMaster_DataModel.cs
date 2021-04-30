using System;

namespace Spice.DataContarct.DataModel
{
    public class OrderMaster
    {
        public int Id { get; set; }

        public int Customer_Id { get; set; }

        public DateTime Order_Date { get; set; }

        public int Orde_Status { get; set; }

        public int CustomerAdressId { get; set; } //Shipping Address Id

        public int CustomerBillingAdressId { get; set; } //Billing Address Id

        public int Shipping_Charges { get; set; }

        public int Payment_Status { get; set; }

        public int Payment_Method { get; set; }

        public int Payment_Mode { get; set; }

        public int Return_Refund { get; set; }

        public string Order_Invoice_Number { get; set; }

        public string Customer_Name { get; set; }

        public string Customer_City { get; set; }

        public int Total_Without_Tax { get; set; }

        public int Total_Taxation_Amount { get; set; }

        public string EnumOrderStatus { get; set; }

    }

    public class Order_Item_Details
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int? VendorId { get; set; }

        public int Quantity { get; set; }

        public string Unit { get; set; }

        public string ProductSKUCode { get; set; }

        public int UnitPrice { get; set; }

        public int Discount { get; set; }

        public int TaxId { get; set; }

        public int TaxAmmount { get; set; }

        public int FinalAmmount { get; set; }

        public string ProductName { get; set; }

        public string SKU { get; set; }
        public decimal RatePerPc { get; set; }
        public string Product_ID { get; set; }
        public string ProductSku_ID { get; set; }
    }


    public class Order_Invoice_Details
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string Invoice_Number { get; set; }

        public int? Vendor_Id { get; set; }

        public DateTime? Invoice_Date { get; set; }

        public DateTime? Delivery_Date { get; set; }

        public DateTime? ExpectedDelivery { get; set; }

        public DateTime? ActualDelivery { get; set; }

        public int Invoice_Status { get; set; }

        public string Vendor_Name { get; set; }
    }


    public class Order_Status_History
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int Status_Id { get; set; }

        public DateTime Update_Date { get; set; }
    }

    public class Invoice_Status_History
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string Invoice_Number { get; set; }

        public int Status_Id { get; set; }

        public DateTime Update_Date { get; set; }
    }

}
