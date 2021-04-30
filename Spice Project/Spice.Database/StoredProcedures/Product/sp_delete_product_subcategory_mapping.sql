CREATE PROCEDURE [dbo].[sp_delete_product_subcategory_mapping]
	-- Add the parameters for the stored procedure here
	@Product_ID int
	
AS
     BEGIN
			DELETE FROM ProductSubCategoryMapping WHERE ProductId =@Product_ID; 
	 END