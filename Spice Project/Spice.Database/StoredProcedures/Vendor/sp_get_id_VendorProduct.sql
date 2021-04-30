alter proc [dbo].[sp_get_id_VendorProduct]
(
@VendorProductId INT
)
AS
BEGIN
Select 
[VendorProductId], VPM.VendorId, VPM.ProductId, VendorPriority, VendorPrice, VPM.IsActive
from VendorProductMapping VPM
inner join VendorMaster VM on VM.Id=VPM.VendorId and VM.IsActive=1
inner join Product PM on PM.ProductId=VPM.ProductId and PM.IsActive=1
Where VendorProductId=@VendorProductId and VPM.IsActive=1

END