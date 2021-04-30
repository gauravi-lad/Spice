USE [SPICE]
GO
/****** Object:  StoredProcedure [dbo].[Sp_get_id_CustomerRating]    Script Date: 28-08-2020 18:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_get_id_CustomerRating]
	@id integer 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * from [dbo].[Customer_Rating]  t where t.Id=@id;
END
