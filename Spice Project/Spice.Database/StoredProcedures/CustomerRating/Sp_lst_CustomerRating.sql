USE [SPICE]
GO
/****** Object:  StoredProcedure [dbo].[Sp_lst_CustomerRating]    Script Date: 28-08-2020 18:32:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_lst_CustomerRating]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * from [dbo].[Customer_Rating];
END
