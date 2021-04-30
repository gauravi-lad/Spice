
CREATE PROC [dbo].[Sp_ins_up_Vendor]
(
@Id int,
@FirstName nvarchar(20),
@MiddleName nvarchar(20),
@LastName nvarchar(20),
@MobileNo bigint,
@Email nvarchar(50),
@Address nvarchar(500),
@IsActive bit,
@State int,
@GST int
)
AS
BEGIN
IF EXISTS(SELECT Id FROM VendorMaster WHERE ID=@Id AND IsActive=1)
BEGIN
UPDATE VendorMaster SET
FirstName=@FirstName,
MiddleName=@MiddleName,
LastName=@LastName,
MobileNo=@MobileNo,
Email=@Email,
[Address]=@Address,
IsActive=@IsActive,
[State]=@State,
GST=@GST 
WHERE ID=@ID AND IsActive=1

SELECT 2 AS Status;

END
ELSE
BEGIN
INSERT INTO VendorMaster
(
FirstName,
MiddleName,
LastName,
MobileNo,
Email,
Address,
IsActive,
[State],
GST
)
VALUES
(
@FirstName,
@MiddleName,
@LastName,
@MobileNo,
@Email,
@Address,
@IsActive,
@State,
@GST
)

SELECT 1 AS Status;
END
END

