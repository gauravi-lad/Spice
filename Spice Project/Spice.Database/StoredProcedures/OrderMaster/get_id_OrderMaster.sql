USE [SpiceDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_get_id_OrderMaster]    Script Date: 24-09-2020 12.11.39 AM ******/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Aditya>
-- Create date: <Create Date,13092020,>
-- Description:	<Description,sp_get_id_OrderMaster, The Sp returns Json as a form of Result>
-- =============================================
CREATE PROCEDURE sp_get_id_OrderMaster 
	@id Int
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
      select  * from OrderMaster where Id = @id

        FOR JSON PATH
        , INCLUDE_NULL_VALUES
        , WITHOUT_ARRAY_WRAPPER  
    )) AS [OrderMaster],
-- this Section of Sp will return a  json node with the singular set of data -----End------
    
-- this Section of Sp will return a  json node with the List of data -----Start------
    (
       select * from [SpiceDB].[dbo].[Order_Item_Details] where OrderId = @id

        FOR JSON PATH
        , INCLUDE_NULL_VALUES
    ) AS [order_Item_Details] ,
-- this Section of Sp will return a  json node with the List of data -----End------
	 

-- this Section of Sp will return a  json node with the singular set of data -----Start------
    JSON_QUERY((
       Select * from [SpiceDB].[dbo].[Order_Status_History] where OrderId = @id

        FOR JSON PATH
        , INCLUDE_NULL_VALUES
    )) AS [lst_Order_Status_History] ,
-- this Section of Sp will return a  json node with the singular set of data -----End------

-- this Section of Sp will return a  json node with the singular set of data -----Start------
    JSON_QUERY((
       Select * from [SpiceDB].[dbo].[Order_Invoice_Details] where OrderId = @id

        FOR JSON PATH
        , INCLUDE_NULL_VALUES
		, WITHOUT_ARRAY_WRAPPER
    )) AS [order_Invoice_Details],
-- this Section of Sp will return a  json node with the singular set of data -----End------


-- this Section of Sp will return a  json node with the singular set of data -----Start------
    JSON_QUERY((
       Select * from [SpiceDB].[dbo].[Invoice_Status_History] where OrderId = @id

        FOR JSON PATH
        , INCLUDE_NULL_VALUES
    )) AS [lst_Invoice_Status_History]
-- this Section of Sp will return a  json node with the singular set of data -----End------



    FOR JSON PATH
    , WITHOUT_ARRAY_WRAPPER
);

SELECT @Json;

END
GO
