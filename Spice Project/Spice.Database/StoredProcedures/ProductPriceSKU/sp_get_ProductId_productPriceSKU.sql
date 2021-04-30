Create PROCEDURE [dbo].[sp_get_ProductId_productPriceSKU]  
@ProductId int   
AS  
BEGIN  
  
 SELECT * FROM ProductPriceSKU WHERE ProductId =@ProductId;  
    
END