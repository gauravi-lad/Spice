USE [SPICE]
GO
/****** Object:  StoredProcedure [dbo].[Sp_ins_CustomerFavourites]    Script Date: 28-08-2020 18:27:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_ins_CustomerFavourites]
	@Id int =0,
	@Customer_Id nvarchar(10),
	@Product_Id	nvarchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
IF (@Id IS NOT NULL) 
	BEGIN
    INSERT INTO [dbo].[Customer_Favourites]
           ([Customer_Id]
           ,[Product_Id])
     VALUES
           (@Customer_Id
           ,@Product_Id)
	END	   
else
	
	BEGIN
	UPDATE [dbo].[Customer_Favourites] 
	set Customer_Id=@Customer_Id ,Product_Id=@Product_Id where Id=@Id;
	commit;
END
		   --Select SCOPE_IDENTITY  ;
END
