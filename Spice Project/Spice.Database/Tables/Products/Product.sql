

CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductCode] [nvarchar](50) NULL,
	[ProductName] [nvarchar](50) NULL,
	[Product_Short_Desc] [nvarchar](1000) NULL,
	[Product_Long_Desc] [nvarchar](MAX) NULL,
	[Product_Features] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
	[IsRefundable] [bit] NULL,
	[IsFeatured] [bit] NULL,
	[IsRecommended] [bit] NULL,
	[CreatedBy] [int] NULL,
	[Createddate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[Updateddate] [datetime] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

