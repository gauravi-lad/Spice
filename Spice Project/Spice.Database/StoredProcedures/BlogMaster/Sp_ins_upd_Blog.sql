USE [SPICE]
GO
/****** Object:  StoredProcedure [dbo].[Sp_ins_upd_Blog]    Script Date: 28-08-2020 18:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_ins_upd_Blog]
	
		   @Blog_Id			 int =0,
           @Blog_Name		 nvarchar(10),
           @Blog_Discription nvarchar(10),
           @Product_Id		 nvarchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	SET NOCOUNT ON;
	if EXISTS (Select * from [dbo].[Blog_Master]  where Blog_Id=@Blog_Id)

	BEGIN
			UPDATE [dbo].[Blog_Master]
			set
				   Blog_Name=@Blog_Name,
				   Blog_Discription=@Blog_Discription,
				   Product_Id=@Product_Id
				   where Blog_Id=@Blog_Id
				   
			END

	ELSE
			BEGIN
			-- Insert statements for procedure here
			INSERT INTO [dbo].[Blog_Master]
				   ([Blog_Name],
					[Blog_Discription],
					[Product_Id])
			 VALUES
				   (@Blog_Name,
				   @Blog_Discription,
				   @Product_Id)
			END

END
