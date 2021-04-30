CREATE TABLE [dbo].[ProductImage](
	[ProductImageId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[Image] [nvarchar](100) NULL,
	[UniqueFileName] [nvarchar](max) NULL,
	[IsDefaultImage] [bit] NULL,
	[CreatedBy] [int] NULL,
	[Createddate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[Updateddate] [datetime] NULL, 
    [ImageNo] INT NULL)