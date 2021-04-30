USE [SPICE]
GO

/****** Object:  Table [dbo].[Video_Master]    Script Date: 28-08-2020 18:39:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Video_Master](
	[Video_Id] [int] IDENTITY(1,1) NOT NULL,
	[Video_Name] [nvarchar](50) NULL,
	[Video_Url] [nvarchar](50) NULL,
	[Video_Discription] [nvarchar](500) NULL,
	[Receipe_Id] [nvarchar](10) NULL,
	[Product_Id] [nvarchar](10) NULL,
 CONSTRAINT [PK_Video_Master] PRIMARY KEY CLUSTERED 
(
	[Video_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

