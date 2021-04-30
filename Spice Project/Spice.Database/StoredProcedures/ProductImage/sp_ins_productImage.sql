Create Procedure [dbo].[sp_ins_productImage](      
@ProductId int,      
--@ProductPriceSKU int,    
@Image varchar (max)=null,    
-- @UniqueFileName varchar (max)=null,    
@IsDefaultImage bit,    
@CreatedBy int,    
@CreatedDate datetime,    
@UpdatedBy int,    
@UpdatedDate datetime,  
@ImageNo int,
@ext varchar(20)  
) AS      
     
BEGIN     
declare @Productcode nvarchar(max);    
declare @PK_ProductImage int;    
declare @Unique_File_Name nvarchar(max);    
declare @ScopeId int ;    
SET @Productcode = (Select ProductCode from Product where ProductId =@ProductId);    
-- SET @PK_ProductImage = (Select Top 1 ProductImageId from ProductImage where ProductId =@ProductId order by ProductId desc);    
-- SET @Unique_File_Name =  @Productcode+'_'+@PK_ProductImage    
   
 delete ProductImage where ProductId=@ProductId and ImageNo=@ImageNo;   
     
 Insert into ProductImage(ProductId, Image,IsDefaultImage, CreatedBy, Createddate, UpdatedBy, Updateddate,ImageNo)     
 values (@ProductId, @Image,@IsDefaultImage, @CreatedBy, @CreatedDate, @UpdatedBy, @UpdatedDate,@ImageNo)      
    
 SET @ScopeId = (Select SCOPE_IDENTITY());    
    
 -- select @ScopeId    
    
 SET @PK_ProductImage = (Select Top 1 ProductImageId from ProductImage where ProductId =@ProductId order by ProductImageId desc);    
--  SET @Unique_File_Name =  @Productcode+'_'+@PK_ProductImage    
  SET @Unique_File_Name = (SELECT @Productcode+'_Image'+  CAST(@PK_ProductImage AS varchar(12)) AS Result);    
    
 -- select @Unique_File_Name;    
    
 update ProductImage Set UniqueFileName = @Unique_File_Name+@ext where ProductImageId = @ScopeId and ProductId= @ProductId;    
 select @Unique_File_Name+@ext as UniqueFileName;    
    
END 