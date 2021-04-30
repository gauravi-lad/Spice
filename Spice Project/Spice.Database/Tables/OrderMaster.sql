USE [SpiceDB]
GO

/****** Object:  Table [dbo].[OrderMaster]    Script Date: 22-09-2020 8.55.39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_Id] [int] NOT NULL,
	[Order_Invoice_Number] [nvarchar](50) NOT NULL,
	[Order_Date] [datetime] NOT NULL,
	[Orde_Status] [int] NOT NULL,
	[CustomerAdressId] [int] NULL,
	[Shipping_Charges] [int] NULL,
	[Payment_Status] [int] NULL,
	[Payment_Method] [int] NULL,
	[Payment_Mode] [int] NULL,
	[Return_Refund] [int] NULL
) ON [PRIMARY]
GO




USE [SpiceDB]
GO

/****** Object:  Table [dbo].[Order_Item_Details]    Script Date: 22-09-2020 9.12.02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Order_Item_Details](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[VendorId] [int] NULL,
	[Quantity] [int] NOT NULL,
	[Unit] [nvarchar](20) NOT NULL,
	[UnitPrice] [int] NOT NULL,
	[Discount] [int] NULL,
	[TaxId] [int] NOT NULL,
	[TaxAmmount] [int] NOT NULL,
	[FinalAmmount] [int] NOT NULL
) ON [PRIMARY]
GO




USE [SpiceDB]
GO

/****** Object:  Table [dbo].[Order_Invoice_Details]    Script Date: 22-09-2020 9.06.49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Order_Invoice_Details](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[Invoice_Number] [nvarchar](50) NOT NULL,
	[Vendor_Id] [int] NOT NULL,
	[Invoice_Date] [datetime] NOT NULL,
	[Delivery_Date] [datetime] NULL,
	[ExpectedDelivery] [datetime] NULL,
	[ActualDelivery] [datetime] NULL,
	[Invoice_Status] [int] NOT NULL
) ON [PRIMARY]
GO



USE [SpiceDB]
GO

/****** Object:  Table [dbo].[Order_Status_History]    Script Date: 11-09-2020 4.01.51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Order_Status_History](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[Status_Id] [int] NOT NULL,
	[Update_Date] [datetime] NOT NULL
	
) ON [PRIMARY]
GO




USE [SpiceDB]
GO

/****** Object:  Table [dbo].[Invoice_Status_History]    Script Date: 22-09-2020 9.19.43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Invoice_Status_History](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[Invoice_Number] [navrchar](50) NOT NULL,
	[Status_Id] [int] NOT NULL,
	[Update_Date] [datetime] NOT NULL
) ON [PRIMARY]
GO
