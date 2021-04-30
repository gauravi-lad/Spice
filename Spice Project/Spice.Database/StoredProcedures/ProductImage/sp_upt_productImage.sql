CREATE Procedure [dbo].[sp_upt_productImage](  
@DocumentId Int,  
@ProductId int,  
@Image varchar (max)=null,
@UniqueFileName varchar (max)=null,
@IsDefaultImage bit ,
@UpdatedBy int,
@UpdatedDate datetime
) AS  

BEGIN  
 Update ProductImage set ProductId = @ProductId, Image = @Image,UniqueFileName=@UniqueFileName,
 IsDefaultImage=@IsDefaultImage, UpdatedBy = @UpdatedBy, Updateddate = @UpdatedDate
 Where ProductImageId = @DocumentId
END  
