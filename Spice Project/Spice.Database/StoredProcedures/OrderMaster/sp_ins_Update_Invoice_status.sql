
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Aditya>
-- Create date: <Create Date,04102020,>
-- Description:	<Description,sp_ins_Update_Invoice_status,>
-- =============================================
CREATE PROCEDURE sp_ins_Update_Invoice_status 
	@json NVARCHAR(max)
AS
BEGIN
	
	declare @OrderId int,@status int;

set @OrderId = JSON_VALUE(@json, '$.orderMaster.Id') ;



	   UPDATE U
SET    U.Invoice_Status = J.Invoice_Status
FROM   dbo.Order_Invoice_Details AS U
JOIN   OPENJSON(@json, '$.order_Invoice_Details')
       WITH (Id INT,Invoice_Status INT) J
       ON J.Id = U.Id ;


Insert into dbo.Invoice_Status_History
(
OrderId,
Invoice_Number,
Status_Id,
Update_Date
)

 SELECT *,(Select GETDATE()) as Update_Date FROM OPENJSON(@json,'$.order_Invoice_Details')
           WITH (
		    OrderId int,
			Invoice_Number nvarchar(50),
            Invoice_Status int   
		   );



EXEC [SpiceDB].[dbo].[sp_get_id_OrderMaster]@OrderId;

END
GO
