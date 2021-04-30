USE [SpiceDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_get_id_customer_address]
	@Id int
AS
BEGIN
	SELECT * FROM Customer_Address WHERE Id=@Id;
END

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_ins_upt_customer_address]
	@Id int,
	@Customer_Id int,
	@Street_1 nvarchar(100),
	@Street_2 nvarchar(100),
	@City nvarchar(100),
	@State nvarchar(100),
	@Pincode nvarchar(max),
	@IsShipping bit,
    @IsDelivery bit,
	@Country nvarchar(10)
AS
BEGIN
IF @Id=0
BEGIN
INSERT INTO Customer_Address(
[Customer_Id],
[Street_1],
[Street_2],
[City],
[State],
[Pincode],
[IsShipping],
[IsDelivery],
[Country]
)VALUES
(
@Customer_Id,
@Street_1,
@Street_2,
@City,
@State,
@Pincode,
@IsShipping,
@IsDelivery,
@Country
)
SELECT * from Customer_Address where Id = CAST(Scope_Identity() AS int);
END
ELSE
BEGIN
UPDATE Customer_Address SET
[Customer_Id]=@Customer_Id,
[Street_1]=@Street_1,
[Street_2]=@Street_2,
[City]=@City,
[State]=@State,
[Pincode]=@Pincode,
[IsShipping]=@IsShipping,
[IsDelivery]=@IsDelivery,
[Country]=@Country
WHERE Id=@Id
SELECT * from Customer_Address where Id =@Id;
END
END

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_lst_customer_address]
AS
BEGIN
	SELECT * FROM Customer_Address;
END

GO

Create proc [dbo].[sp_delete_id_customer_address]
(
@Id INT
)
AS
BEGIN
DELETE FROM  Customer_Address
Where Id=@Id 
 
END
GO


CREATE PROCEDURE [dbo].[sp_get_id_customer_address_by_id]
	@Customer_Id int
AS
BEGIN
	
	SET NOCOUNT ON;
    SELECT * FROM Customer_Address WHERE Customer_Id=@Customer_Id;
END

GO