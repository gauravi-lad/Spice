USE [SpiceDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer_Master](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[First_Name] [nvarchar](100) NULL,
	[Second_Name] [nvarchar](100) NULL,
	[Middle_Name] [nvarchar](20) NULL,
	[Mobile_Number] [nvarchar](13) NULL,
	[Email] [nvarchar](100) NULL,
	[Password] [nvarchar](100)  NULL,
	[IsActive] [bit] NULL,
	[ProfilePicture] [nvarchar](500) NULL,
	[Gender] [nvarchar](10) NULL,
	[DOB] [datetime] NULL,
	[Mobile_Verified] [int]  NULL,
 CONSTRAINT [PK_Customer_Master] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


