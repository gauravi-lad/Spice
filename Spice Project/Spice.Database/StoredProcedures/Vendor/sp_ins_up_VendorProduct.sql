CREATE proc [dbo].[sp_ins_up_VendorProduct]  
(  
@VendorProductId INT,
@VendorId INT,  
@ProductId INT,  
@VendorPriority INT,  
@VendorPrice DECIMAL,  
@IsActive BIT  
)  
AS  
BEGIN  
IF EXISTS (SELECT VendorProductId from VendorProductMapping WHERE VendorProductId=@VendorProductId)  
BEGIN 
UPDATE VendorProductMapping set 
VendorId=@VendorId ,
ProductId=@ProductId ,
VendorPriority=@VendorPriority, 
VendorPrice=@VendorPrice,
IsActive =@IsActive
WHERE VendorProductId=@VendorProductId

Select 2 as Status

END
ELSE
BEGIN

INSERT INTO VendorProductMapping  
(  
VendorId,  
ProductId,  
VendorPriority,  
VendorPrice,  
IsActive  
)  
VALUES  
(  
@VendorId,  
@ProductId,  
@VendorPriority,  
@VendorPrice,  
@IsActive  
)  

select 1 as Status
END  


END
