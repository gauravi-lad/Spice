CREATE Procedure [dbo].[sp_ins_upt_productPriceSKU](  
@ID Int,  
@ProductId int,  
@Unit int,
@SKU varchar (max)=null,
@RatePerPc decimal,
@MinOrderQuantity int,
@MaxOrderQuantity int,
@CreatedBy int,
@CreatedDate datetime,
@UpdatedBy int,
@UpdatedDate datetime
) AS  
BEGIN  
--set nocount on  
  
IF @ID = 0   
BEGIN  
 Insert into ProductPriceSKU(ProductId, Unit, SKU, RatePerPc,MinOrderQuantity,MaxOrderQuantity, CreatedBy, Createddate, UpdatedBy, Updateddate) 
 values (@ProductId, @Unit, @SKU, @RatePerPc,@MinOrderQuantity,@MaxOrderQuantity, @CreatedBy, @CreatedDate, @UpdatedBy, @UpdatedDate)  
END  
ELSE  
BEGIN  
 Update ProductPriceSKU set ProductId = @ProductId, Unit = @Unit, SKU = @SKU,RatePerPc=@RatePerPc,
 MinOrderQuantity = @MinOrderQuantity,MaxOrderQuantity=@MaxOrderQuantity, UpdatedBy = @UpdatedBy, Updateddate = @UpdatedDate
 Where ProductPriceSKUId = @ID
END  
END  