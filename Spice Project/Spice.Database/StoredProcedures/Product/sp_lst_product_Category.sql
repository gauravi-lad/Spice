CREATE PROCEDURE [dbo].[sp_lst_product_Category]
@ID int 
AS
BEGIN

 SELECT CategoryId FROM ProductSubCategoryMapping where ProductId=@Id;
		
END