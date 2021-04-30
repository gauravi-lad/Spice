Create PROCEDURE [dbo].[sp_get_id_product]
@ID int 
AS
BEGIN

 SELECT * FROM Product WHERE ProductId =@ID;
		
END
