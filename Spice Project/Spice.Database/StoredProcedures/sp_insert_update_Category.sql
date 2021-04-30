CREATE Procedure [dbo].[sp_insert_update_Category](  
@CategoryId Int,  
@CategoryName varchar(100),  
@CategoryShortDescription varchar (max)=null,
@CategoryLongDescription varchar (max)=null,
@IsActive bit,
@CreatedBy varchar(20),
@ModifiedBy varchar(20)
) AS  
BEGIN  
--set nocount on  
  
IF @CategoryId = 0   
BEGIN  
 Insert into CategoryMaster(CategoryName, CategoryShortDescription, CategoryLongDescription, IsActive, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn) 
 values (@CategoryName, @CategoryShortDescription, @CategoryLongDescription, @IsActive, @CreatedBy, getdate(), null, null)  
END  
ELSE  
BEGIN  
 Update CategoryMaster set CategoryName = @CategoryName, CategoryShortDescription = @CategoryShortDescription, CategoryLongDescription = @CategoryLongDescription,
 IsActive = @IsActive, ModifiedBy = @ModifiedBy, ModifiedOn = getdate()
 Where CategoryId = @CategoryId  
END  
  
--return SCOPE_IDENTITY() 
  
END  