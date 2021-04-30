USE [SPICE]
GO
/****** Object:  StoredProcedure [dbo].[Sp_get_id_Blog]    Script Date: 28-08-2020 18:26:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================

ALTER PROCEDURE [dbo].[Sp_get_id_Blog]
	-- Add the parameters for the stored procedure here
	@Blog_Id integer
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * from [dbo].[Blog_Master] 
	Where Blog_Id=@Blog_Id
END
