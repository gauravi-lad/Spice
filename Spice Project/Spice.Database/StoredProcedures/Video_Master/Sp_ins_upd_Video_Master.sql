USE [SPICE]
GO
/****** Object:  StoredProcedure [dbo].[Sp_ins_upd_Video_Master]    Script Date: 28-08-2020 18:35:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_ins_upd_Video_Master]
	@Video_Id			int=0,
	@Video_Name			nvarchar(50),
	@Video_Url			nvarchar(100),	
	@Video_Discription	nvarchar(500),
	@Receipe_Id			nvarchar(10),
	@Product_Id			nvarchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
if EXISTS (Select * from [dbo].[Video_Master]  where Video_Id=@Video_Id and Receipe_Id=@Receipe_Id and Product_Id=@Product_Id)

	BEGIN
			UPDATE [dbo].[Video_Master]
			set
				   Video_Name=@Video_Name,
				   Video_Url=@Video_Url,
				   Video_Discription=@Video_Discription
				   where Video_Id=@Video_Id
				   and Receipe_Id=@Receipe_Id
				   and Product_Id=@Product_Id
				   
			END

	ELSE
			BEGIN
			-- Insert statements for procedure here
			INSERT INTO [dbo].[Video_Master]
				   ([Video_Name],
					[Video_Url],
					[Video_Discription],
					[Receipe_Id],
					[Product_Id])
			 VALUES
				   (@Video_Name,
				   @Video_Url,
				   @Video_Discription,
				   @Receipe_Id,
				   @Product_Id)
			END

END
