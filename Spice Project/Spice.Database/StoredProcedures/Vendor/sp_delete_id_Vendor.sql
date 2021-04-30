Create proc [dbo].[sp_delete_id_Vendor]
(
@VendorId INT
)
AS
BEGIN
DELETE FROM  VendorMaster
Where Id=@VendorId AND IsActive=1
 
END