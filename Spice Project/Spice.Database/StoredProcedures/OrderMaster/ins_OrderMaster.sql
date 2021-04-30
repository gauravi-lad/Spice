USE [SpiceDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_ins_OrderMaster]    Script Date: 24-09-2020 12.11.39 AM ******/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Aditya>
-- Create date: <Create Date,13092020,>
-- Description:	<Description,sp_ins_OrderMaster,>
-- =============================================
CREATE PROCEDURE sp_ins_OrderMaster 
	@json NVARCHAR(max)
	
AS
BEGIN
	
-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [dbo].[OrderMaster]
           ([Customer_Id]
		   ,[Order_Invoice_Number]
           ,[Order_Date]
           ,[Shipping_Charges]
           ,[Orde_Status]
		   ,[CustomerAdressId]
           ,[Payment_Status]
           ,[Payment_Method]
           ,[Payment_Mode]
           ,[Return_Refund])
   
		   SELECT *
           FROM OPENJSON(@json,'$.orderMaster')
           WITH (
		    Customer_Id int,
			Order_Invoice_Number nvarchar(50),
            Order_Date datetime,
           Shipping_Charges int,
		   Orde_Status int,
           CustomerAdressId int,
           Payment_Status int,
           Payment_Method int,
           Payment_Mode int,
           Return_Refund int
		   )
		   
		   declare @OrderId int;
           set @OrderId = (SELECT SCOPE_IDENTITY());

	
	INSERT INTO [dbo].[Order_Item_Details]
           ([OrderId]
           ,[ProductId]
           ,[VendorId]
           ,[Quantity]
           ,[Unit]
           ,[UnitPrice]
           ,[Discount]
           ,[TaxId]
           ,[TaxAmmount]
           ,[FinalAmmount])
     
	 SELECT @OrderId AS OrderId,*
           FROM OPENJSON(@json,'$.order_Item_Details')
           WITH (
             ProductId int
           , VendorId int
           , Quantity int
           , Unit nvarchar(20)
           , UnitPrice int
           , Discount int
           , TaxId int
           , TaxAmmount int
           , FinalAmmount int
		   )

		   INSERT INTO [dbo].[Order_Status_History]
           ([OrderId]
           ,[Status_Id]
           ,[Update_Date])
     SELECT  @OrderId AS OrderId,*
           FROM OPENJSON(@json,'$.order_Status_History')
           WITH (
            Status_Id int 
           ,Update_Date datetime 
		   )

EXEC [SpiceDB].[dbo].[sp_get_id_OrderMaster]@OrderId;

END
GO