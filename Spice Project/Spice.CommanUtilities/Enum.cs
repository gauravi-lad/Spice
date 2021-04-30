namespace Spice.CommanUtilities
{
    public enum LogDirectory
    {
        Spice_Exception_Log,
        View_Exception_Log,
        DB_Connection_Exception_Log,
        Data_Log
    }

    public enum OrderStatus
    {
        Order_Placed = 1,
        Order_In_Progress = 2,
        Order_Delivered = 3,
        Order_Return = 4,
        Order_Replaced = 5,
        Order_Canceled = 6,
        Order_Closed = 7
    }

    public enum InvoiceStatus
    {
        Invoice_Generated = 1,
        In_Delivery_Channel = 2,
        Items_Delivered = 3,
        Order_Item_Return = 4,
        Order_Item_Replaced = 5,
        Order_Item_Canceled = 6
    }

    public enum RefundReturnStatus
    {
        No_Return_Refund = 0,
        Return_Applied = 1,
        Refund_Applied = 2,
        Return_Process = 3,
        Refund_Process = 4
    }

    public enum PaymentStatus
    {
        Pending = 0,
        Done = 1,
        Failed = 2
    }
}
