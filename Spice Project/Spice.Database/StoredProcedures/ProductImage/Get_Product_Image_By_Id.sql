
Create Procedure [dbo].[sp_get_id_productImage](
@ID int
) AS  

BEGIN  
 SELECT * FROM ProductImage WHERE ProductId=@ID;
END  
