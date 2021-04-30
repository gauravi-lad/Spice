CREATE PROC [dbo].[Sp_get_id_Vendor]  
(  
@Id int  
)  
AS  
BEGIN  
SELECT Id, [FirstName], [MiddleName], [LastName], [MobileNo], [Email], [Address], [IsActive], [State], [GST]  
FROM VendorMaster WHERE ID=@Id AND IsActive=1  
END  