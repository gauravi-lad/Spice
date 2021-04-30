CREATE PROC [dbo].[Sp_lst_Vendor]  
AS  
BEGIN  
SELECT  Id,FirstName, MiddleName, LastName, MobileNo, Email, [Address], VM.IsActive, SM.StateName,State,GST,GM.GSTValue  
FROM VendorMaster VM
LEFT JOIN StateMaster SM on SM.StateId= VM.State
LEFT JOIN GSTMaster GM on GM.GstId= VM.GST AND GM.IsActive=1 
WHERE  VM.IsActive=1  
END  