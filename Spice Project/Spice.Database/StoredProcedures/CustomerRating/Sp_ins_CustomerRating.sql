USE [SPICE]
GO
/****** Object:  StoredProcedure [dbo].[Sp_ins_CustomerRating]    Script Date: 28-08-2020 18:32:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_ins_CustomerRating]
	@Customer_Id nvarchar(10),
	@Product_Id nvarchar(10),
	@Rating nvarchar(5),
	@Reviews nvarchar(500),
	@Date nvarchar(50),
	@IsActive nvarchar(10)
AS
BEGIN
	
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Customer_Rating]
           ([Customer_Id]
           ,[Product_Id]
           ,[Rating]
           ,[Reviews]
           ,[Date]
           ,[IsActive])
     VALUES
	 (	@Customer_Id,
		@Product_Id,
		@Rating,
		@Reviews,
		GETDATE(),
		@IsActive
	 )
           
	
END
