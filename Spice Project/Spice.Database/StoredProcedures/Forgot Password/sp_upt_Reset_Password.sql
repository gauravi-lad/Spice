CREATE PROCEDURE [dbo].[sp_upt_Reset_Password]
	-- Add the parameters for the stored procedure here
	
	@Email nvarchar(100),
	@New_Password nvarchar(100)
	
AS

BEGIN
			
		UPDATE Customer_Master

        SET Password = @New_Password, OTP = NULL
        
        WHERE Email = @Email
		
END
