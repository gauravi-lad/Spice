USE [SpiceDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_lst_OrderMaster]    Script Date: 24-09-2020 12.11.39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Aditya>
-- Create date: <Create Date,13092020,>
-- Description:	<Description,sp_lst_OrderMaster,  The Sp returns Json as a form of Result>
-- =============================================
CREATE PROCEDURE [dbo].[sp_lst_OrderMaster] 
	@order_Id Int,
	@order_from_Date date,
	@order_to_Date date,
	@order_Status int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @Json nvarchar(max) = 
(
-- this Section of Sp will return a  json node with the singular set of data -----Start------
    SELECT
     JSON_QUERY((
       select * from OrderMaster where 
	   Id = IIF(@order_Id IS NULL, Id, @order_Id) AND 
	  CONVERT(date, Order_Date) >= IIF(@order_from_Date IS NULL, Order_Date, @order_from_Date) AND
	   CONVERT(date,  Order_Date) <= IIF(@order_to_Date IS NULL, Order_Date, @order_to_Date) AND
	   Orde_Status = IIF(@order_Status IS NULL, Orde_Status, @order_Status)

        FOR JSON PATH
        , INCLUDE_NULL_VALUES
    )) AS [OrderMaster]
-- this Section of Sp will return a  json node with the singular set of data -----End------




    FOR JSON PATH
    , WITHOUT_ARRAY_WRAPPER
);

SELECT @Json;

END
GO

