USE [SpiceDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_ins_Update_Order_Delivery_Dates]    Script Date: 25-09-2020 1.02.07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Aditya>
-- Create date: <Create Date,24092020,>
-- Description:	<Description,sp_ins_Update_Order_Delivery_Dates,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ins_Update_Order_Delivery_Dates] 
	@json NVARCHAR(max)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRY
		   
	   UPDATE U
SET    U.Delivery_Date = J.Delivery_Date,
       U.ExpectedDelivery = J.ExpectedDelivery,
       U.ActualDelivery = J.ActualDelivery
FROM   dbo.Order_Invoice_Details AS U
JOIN   OPENJSON(@json, '$.order_Invoice_Details')
       WITH (Id INT,Delivery_Date datetime,ExpectedDelivery datetime,ActualDelivery datetime) J
       ON J.Id = U.Id


		   declare @OrderId int;
           set @OrderId = JSON_VALUE(@json, '$.orderMaster.Id') ;

          EXEC [SpiceDB].[dbo].[sp_get_id_OrderMaster]@OrderId;


		  END TRY
BEGIN CATCH
   SELECT ERROR_NUMBER(), ERROR_MESSAGE();
END CATCH

END
GO