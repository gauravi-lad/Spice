Create PROCEDURE [dbo].[sp_insert_product_category_mapping]
	-- Add the parameters for the stored procedure here
	
	@ProductId int,
	@CategoryId int
	
AS
     BEGIN
			INSERT INTO ProductSubCategoryMapping
		    (ProductId, 
			 CategoryId
		    )
     VALUES
             (@ProductId,
			  @CategoryId
             )
	 END