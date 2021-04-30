USE [SpiceDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_ins_Assign_Order_Vendors]    Script Date: 25-09-2020 1.02.07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Aditya>
-- Create date: <Create Date,24092020,>
-- Description:	<Description,sp_ins_Assign_Order_Vendors,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ins_Assign_Order_Vendors] 
	@json NVARCHAR(max)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRY

declare @OrderId int;
set @OrderId = JSON_VALUE(@json, '$.orderMaster.Id') ;

   
   INSERT INTO [dbo].[Order_Invoice_Details]
           ([OrderId]
           ,[Invoice_Number]
           ,[Vendor_Id]
           ,[Invoice_Date]
           ,[Invoice_Status])
   
		   SELECT *
           FROM OPENJSON(@json,'$.order_Invoice_Details')
           WITH (
		    OrderId int,
			Invoice_Number nvarchar(50),
            Vendor_Id int,
		    Invoice_Date datetime,
            Invoice_Status int   
		   );

INSERT INTO [dbo].[Invoice_Status_History]
           ([OrderId]
           ,[Invoice_Number]
           ,[Status_Id]
           ,[Update_Date]
           )
   
		   SELECT *
           FROM OPENJSON(@json,'$.lst_Invoice_Status_History')
           WITH (
		    OrderId int,
			Invoice_Number nvarchar(50),
		    Status_Id int,
			Update_Date datetime
		   );

Update dbo.OrderMaster set Orde_Status = 2 where Id = @OrderId ; 

Insert into dbo.Order_Status_History
(OrderId,
Status_Id,
Update_Date)
values
(
@OrderId,
2,
(SELECT GETDATE())
)


		   
	   UPDATE U
SET    U.VendorId = J.VendorId
FROM   dbo.Order_Item_Details AS U
JOIN   OPENJSON(@json, '$.order_Item_Details')
       WITH (Id INT,VendorId INT) J
       ON J.Id = U.Id ;




 



EXEC [SpiceDB].[dbo].[sp_get_id_OrderMaster]@OrderId;


		  END TRY
BEGIN CATCH
   SELECT ERROR_NUMBER(), ERROR_MESSAGE();
END CATCH

END

