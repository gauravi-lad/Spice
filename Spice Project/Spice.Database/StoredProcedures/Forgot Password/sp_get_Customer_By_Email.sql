
-- =============================================
-- Author:		Trupti Shirdhankar
-- Create date: 02 August 2020
-- Description:	Insert the deatils of products 
-- =============================================
CREATE PROCEDURE [dbo].[sp_get_Customer_By_Email]
@Email nvarchar(100) 
AS
BEGIN

 SELECT * FROM Customer_Master WHERE Email =@Email;
		
END

