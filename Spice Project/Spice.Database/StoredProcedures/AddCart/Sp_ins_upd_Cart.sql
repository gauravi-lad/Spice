USE [SPICE]
GO
/****** Object:  StoredProcedure [dbo].[Sp_ins_upd_Cart]    Script Date: 28-08-2020 18:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_ins_upd_Cart]
		   @Customer_ID nvarchar(10),
           @Product_ID nvarchar(10),
           @ProductSku_ID nvarchar(10),
           @Unit nvarchar(10),
           @Quantity nvarchar(10),
           @Amount nvarchar(10),
           @Discount nvarchar(10)
	
AS

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if EXISTS (Select * from [dbo].[Cart]  where Customer_ID=@Customer_ID)

	BEGIN
	UPDATE [dbo].[Cart]
	set
		   Product_ID=@Product_ID,
           ProductSku_ID=@ProductSku_ID,
           Unit=@Unit,
		   Quantity= @Quantity, 
           Amount=@Amount, 
           Discount=@Discount

	END
	ELSE
	BEGIN
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Cart]
           ([Customer_ID],
            [Product_ID],
			[ProductSku_ID],
			[Unit],
			[Quantity],
			[Amount],
			[Discount])
     VALUES
           (@Customer_ID,
           @Product_ID,
           @ProductSku_ID,
           @Unit,
           @Quantity, 
           @Amount, 
           @Discount)
	END
