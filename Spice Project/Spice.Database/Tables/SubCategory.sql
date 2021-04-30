-- Table [SubCategory]================Author > Aditya================================

USE [SpiceDB]
GO

/****** Object:  Table [dbo].[SubCategory]    Script Date: 04-08-2020 11.45.07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SubCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[SubCategoryName] [nvarchar](20) NOT NULL,
	[SubCategoryDesc] [nvarchar](20) NOT NULL
) ON [PRIMARY]
GO
