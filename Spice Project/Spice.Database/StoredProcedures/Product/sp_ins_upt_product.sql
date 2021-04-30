CREATE PROCEDURE [dbo].[sp_ins_upt_product]
	-- Add the parameters for the stored procedure here
	@ID int,
	@ProductCode varchar(50),
	@ProductName varchar(100),
	@Product_Short_Desc varchar(100),
	@Product_Long_Desc varchar(100),
	@Product_Features varchar(100),
	@IsActive bit,
	@IsRefundable bit,
	@IsFeatured bit,
	@IsRecommended bit,
	@CreatedBy int ,
	@CreatedDate datetime,
	@UpdatedBy int,
	@UpdatedDate datetime

	
AS
BEGIN

		If(@ID = '0')
		BEGIN
			INSERT INTO Product
		    (ProductCode, 
			ProductName, 
			Product_Short_Desc, 
			Product_Long_Desc, 
			Product_Features, 
			IsActive, 
			IsRefundable, 
			IsFeatured, 
			IsRecommended,
			CreatedBy,
			Createddate,
			UpdatedBy,
			Updateddate
            )

			 
			VALUES(@ProductCode,
			 @ProductName, 
			 @Product_Short_Desc, 
			 @Product_Long_Desc, 
			 @Product_Features, 
			 @IsActive, 
			 @IsRefundable, 
			 @IsFeatured, 
			 @IsRecommended,
			 @CreatedBy,
			 @Createddate,
			 @UpdatedBy,
			 @UpdatedDate
			 )

			 select SCOPE_IDENTITY() As ProductId;
		END

		Else
		BEGIN
				UPDATE Product SET 
				ProductCode=@ProductCode,
				ProductName= @ProductName,
				Product_Short_Desc=@Product_Short_Desc,
				Product_Long_Desc= @Product_Long_Desc,
				Product_Features= @Product_Features,
				IsActive= @IsActive, 
				IsRefundable=@IsRefundable,
				IsFeatured= @IsFeatured,
				IsRecommended=@IsRecommended,
				UpdatedBy=@UpdatedBy,
				Updateddate=@UpdatedDate
				WHERE ProductId=@ID

        select @ID as ProductId;
		END
END