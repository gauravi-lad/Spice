
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Aditya>
-- Create date: <Create Date,04102020,>
-- Description:	<Description,sp_ins_Update_Order_status,>
-- =============================================
CREATE PROCEDURE sp_ins_Update_Order_status 
	@json NVARCHAR(max)
AS
BEGIN
	
	declare @OrderId int,@status int;

set @OrderId = JSON_VALUE(@json, '$.orderMaster.Id') ;
set @status = JSON_VALUE(@json, '$.orderMaster.Orde_Status') ;


Update dbo.OrderMaster set Orde_Status = @status where Id = @OrderId ;

Insert into dbo.Order_Status_History 
(
OrderId,
Status_Id,
Update_Date
)
values
(
@OrderId,
@status,
(Select GETDATE())
);

EXEC [SpiceDB].[dbo].[sp_get_id_OrderMaster]@OrderId;

END
GO
