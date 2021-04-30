
CREATE TABLE [dbo].[ProductPriceSKU](
	[ProductPriceSKUId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Unit] [int] NULL,
	[SKU] [nvarchar](100) NULL,
	[RatePerPc] [decimal](18, 2) NULL,
	[MinOrderQuantity] [int] NULL,
	[MaxOrderQuantity] [int] NULL,
	[CreatedBy] [int] NULL,
	[Createddate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[Updateddate] [datetime] NULL)