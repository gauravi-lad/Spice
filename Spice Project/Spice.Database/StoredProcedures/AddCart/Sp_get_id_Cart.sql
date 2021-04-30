USE [SPICE]
GO
/****** Object:  StoredProcedure [dbo].[Sp_get_id_Cart]    Script Date: 28-08-2020 18:24:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_get_id_Cart] 
	-- Add the parameters for the stored procedure here
	@id integer 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select *  from [dbo].[Cart]
	 where Customer_ID=@id
    
END
