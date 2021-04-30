USE [SPICE]
GO

/****** Object:  Table [dbo].[Customer_Rating]    Script Date: 28-08-2020 18:39:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer_Rating](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_Id] [int] NULL,
	[Product_Id] [int] NULL,
	[Rating] [int] NULL,
	[Reviews] [nvarchar](500) NULL,
	[Date] [date] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Customer_Rating] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

