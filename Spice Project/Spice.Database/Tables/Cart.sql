USE [SPICE]
GO

/****** Object:  Table [dbo].[Cart]    Script Date: 28-08-2020 18:40:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cart](
	[Customer_ID] [nvarchar](10) NULL,
	[Product_ID] [nvarchar](10) NULL,
	[ProductSku_ID] [nvarchar](10) NULL,
	[Unit] [nvarchar](10) NULL,
	[Quantity] [nvarchar](10) NULL,
	[Amount] [nvarchar](10) NULL,
	[Discount] [nvarchar](10) NULL
) ON [PRIMARY]
GO

