USE [SPICE]
GO
/****** Object:  StoredProcedure [dbo].[Sp_lst_Blog]    Script Date: 28-08-2020 18:27:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_lst_Blog]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * from [dbo].[Blog_Master]
END
