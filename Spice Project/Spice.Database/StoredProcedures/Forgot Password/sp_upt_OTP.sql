CREATE PROCEDURE [dbo].[sp_upt_OTP]
	-- Add the parameters for the stored procedure here
	
	@Email varchar(50),
	@OTP varchar(100)
	
AS
BEGIN
				
	   UPDATE Customer_Master

        SET OTP = @OTP
        
        WHERE Email = @Email;

END
