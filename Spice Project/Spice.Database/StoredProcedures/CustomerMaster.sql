USE [SpiceDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_get_id_customer_master]
	@Id int
AS
BEGIN
	
	SET NOCOUNT ON;
    SELECT * FROM Customer_Master WHERE Id=@Id;
END

GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ins_upt_customer_master]
	@Id int,
 @First_Name nvarchar(100),  
 @Second_Name nvarchar(100),  
 @Middle_Name nvarchar(100),  
 @Mobile_Number nvarchar(13),  
 @Email nvarchar(100),
 @Password nvarchar(100),  
 @IsActive bit,  
 @ProfilePicture nvarchar(500),  
 @Gender nvarchar(10),  
 @DOB datetime,  
 @Mobile_Verified int 

AS
BEGIN
	
	IF @Id=0
	BEGIN
    INSERT INTO Customer_Master
	([First_Name],
	 [Second_Name],
	 [Middle_Name],
	 [Mobile_Number],
	 [Email],
	 [Password],  
	 [IsActive],
	 [ProfilePicture],
	 [Gender],
	 [DOB],
	 [Mobile_Verified])
    VALUES 
	(@First_Name, 
	@Second_Name,
	@Middle_Name,
	@Mobile_Number,
	@Email,
	@Password,
	@IsActive,
	@ProfilePicture,
	@Gender,
	@DOB,
	@Mobile_Verified)
	SELECT * from Customer_Master where Id = CAST(Scope_Identity() AS int);
	END
	Else
	BEGIN
	UPDATE Customer_Master SET 
	[First_Name]=@First_Name,
	[Second_Name]=@Second_Name,
	[Middle_Name]=@Middle_Name,
	[Mobile_Number]=@Mobile_Number,
	[Email]=@Email,
	[IsActive]=@IsActive,
	[ProfilePicture]=@ProfilePicture,
	[Gender]=@Gender,
	[DOB]=@DOB,
	[Mobile_Verified]=@Mobile_Verified
	WHERE Id=@Id
	SELECT * from Customer_Master where Id =@Id;
	END 
END

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_lst_customer_master]
	
AS
BEGIN
	SELECT * FROM Customer_Master;
END

GO

