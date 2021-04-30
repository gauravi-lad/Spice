-- Stored procedure [sub_category]============Start====================================

-- ===================1>
GO
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Aditya>
-- Create date: <Create Date,04082020,>
-- Description:	<Description,Sub-Category,>
-- =============================================
CREATE PROCEDURE sp_get_id_sub_category
	@id Int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select * from dbo.SubCategory where id = @id
    
END
GO


-- ===================2>

GO
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Aditya>
-- Create date: <Create Date,04082020,>
-- Description:	<Description,Sub-Category,>
-- =============================================
CREATE PROCEDURE sp_lst_sub_category
	@SubCategoryName nvarchar(20),
	@CategoryId int = null
AS
BEGIN
	SET NOCOUNT ON;
	select * from dbo.SubCategory  where CategoryId = IIF(@CategoryId IS NULL, CategoryId, @CategoryId) AND SubCategoryName like '%'+IIF(@SubCategoryName IS NULL, SubCategoryName, @SubCategoryName)+'%'
END

GO


-- =================== 3>

GO
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Aditya>
-- Create date: <Create Date,04082020,>
-- Description:	<Description,Sub-Category,>
-- =============================================
CREATE PROCEDURE sp_ins_upt_sub_category
    @Id int = NULL,
    @CategoryId int,
	@SubCategoryName nvarchar(20),
	@SubCategoryDesc nvarchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	IF ISNULL(@Id, '') = ''
	BEGIN
	
	INSERT INTO dbo.SubCategory
           (CategoryId,
		    SubCategoryName,
            SubCategoryDesc)
     VALUES
           (@CategoryId,
		    @SubCategoryName,
            @SubCategoryDesc)
    
	SELECT * from dbo.SubCategory WHERE Id = (SELECT SCOPE_IDENTITY());

	END
     ELSE
    BEGIN

	UPDATE dbo.SubCategory
   SET CategoryId = @CategoryId,
       SubCategoryName = @SubCategoryName,
       SubCategoryDesc = @SubCategoryDesc
   WHERE Id =@Id

   SELECT * from dbo.SubCategory WHERE Id = @Id;
     END
END
GO

-- ===================4>


GO
/****** Object:  StoredProcedure [dbo].[sp_lst_drpDwn_category]    Script Date: 05-08-2020 12.04.35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Aditya>
-- Create date: <Create Date,04082020,>
-- Description:	<Description,Sub-Category,>
-- =============================================
Create PROCEDURE [dbo].[sp_lst_drpDwn_category]
	
AS
BEGIN
	SET NOCOUNT ON;
	select * from dbo.CategoryMaster
END


-- ======================5>

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Aditya>
-- Create date: <Create Date,04082020,>
-- Description:	<Description,sub_category,>
-- =============================================
CREATE PROCEDURE sp_delete_sub_category
@Id int,
@Result INT OUTPUT  
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET NOCOUNT ON;
 BEGIN TRY
  DELETE FROM dbo.SubCategory
      WHERE Id = @Id
	   SET @Result = 1;
	   select @Result;
     END TRY 
    BEGIN CATCH
      SET @Result = 0;
	  select @Result;
   END CATCH

END;   

-- Stored procedure [sub_category]============End====================================
