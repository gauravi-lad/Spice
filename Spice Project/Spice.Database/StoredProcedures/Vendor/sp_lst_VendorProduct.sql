
Create proc [dbo].[sp_lst_VendorProduct]  
AS  
BEGIN  
Select   
[VendorProductId], VPM.VendorId, VPM.ProductId, [VendorPriority], [VendorPrice], VPM.IsActive,VM.FirstName +' '+ VM.LastName as VendorName,PM.ProductName
from VendorProductMapping VPM
inner join VendorMaster VM on VM.Id=VPM.VendorId 
inner join Product PM on PM.ProductId=VPM.ProductId

Where VPM.IsActive=1  
  
END  