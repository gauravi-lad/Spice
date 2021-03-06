USE [SPICE]
GO
/****** Object:  StoredProcedure [dbo].[Sp_delete_cart]    Script Date: 28-08-2020 18:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_delete_cart] 
	@Customer_ID integer,
	@Product_ID	integer
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM  [dbo].[Cart] WHERE  Customer_ID=@Customer_ID and Product_ID=@Product_ID;
END
