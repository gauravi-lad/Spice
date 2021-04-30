CREATE proc [dbo].[sp_delete_id_VendorProduct]
(
@VendorProductId INT
)
AS
BEGIN
UPDATE  VendorProductMapping SET IsActive=0
Where VendorProductId=@VendorProductId
 

END