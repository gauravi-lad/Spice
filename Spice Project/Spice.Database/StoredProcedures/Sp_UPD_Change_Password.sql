USE [SPICE]
GO
/****** Object:  StoredProcedure [dbo].[Sp_UPD_Change_Password]    Script Date: 28-08-2020 18:40:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Sp_UPD_Change_Password]
	 @Id		nvarchar(10),
     @Password  nvarchar(10)
AS
BEGIN
	update [dbo].[Customer_Master] 
	set
	Password=@Password
	where Id=@Id;
	SELECT 3 AS Status;
END

