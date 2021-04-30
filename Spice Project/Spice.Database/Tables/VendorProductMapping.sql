CREATE TABLE [dbo].[VendorProductMapping](
	[VendorProductId] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[VendorPriority] [int] NULL,
	[VendorPrice] [decimal](18, 0) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_VendorProductMapping] PRIMARY KEY CLUSTERED 
(
	[VendorProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[VendorProductMapping]  WITH CHECK ADD  CONSTRAINT [FK_VendorProductMapping_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO

ALTER TABLE [dbo].[VendorProductMapping] CHECK CONSTRAINT [FK_VendorProductMapping_Product]
GO

ALTER TABLE [dbo].[VendorProductMapping]  WITH CHECK ADD  CONSTRAINT [FK_VendorProductMapping_VendorMaster] FOREIGN KEY([VendorId])
REFERENCES [dbo].[VendorMaster] ([Id])
GO

ALTER TABLE [dbo].[VendorProductMapping] CHECK CONSTRAINT [FK_VendorProductMapping_VendorMaster]
GO