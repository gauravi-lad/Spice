USE [SPICE]
GO
/****** Object:  StoredProcedure [dbo].[Sp_get_id_Video_Master]    Script Date: 28-08-2020 18:35:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_get_id_Video_Master]
	-- Add the parameters for the stored procedure here
	@Video_Id	nvarchar(10),
	@Receipe_Id	nvarchar(10),
	@Product_Id nvarchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   Select * from [dbo].[Video_Master]
   Where Video_Id=@Video_Id
	and Receipe_Id=@Receipe_Id
	and Product_Id=@Product_Id
END
