Create PROCEDURE [dbo].[sp_get_id_productPriceSKU]
@ID int 
AS
BEGIN

 SELECT * FROM ProductPriceSKU WHERE ProductPriceSKUId =@ID;
		
END