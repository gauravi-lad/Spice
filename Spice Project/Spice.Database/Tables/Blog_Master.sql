USE [SPICE]
GO

/****** Object:  Table [dbo].[Blog_Master]    Script Date: 28-08-2020 18:40:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Blog_Master](
	[Blog_Id] [int] IDENTITY(1,1) NOT NULL,
	[Blog_Name] [nvarchar](50) NULL,
	[Blog_Discription] [nvarchar](500) NULL,
	[Product_Id] [nvarchar](10) NULL,
 CONSTRAINT [PK_Blog_Master] PRIMARY KEY CLUSTERED 
(
	[Blog_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

