CREATE  PROCEDURE [dbo].[sp_get_Customer_By_Email_For_Reset_Password]
@Email nvarchar(100)  ,
@OTP  nvarchar(100) 
AS
BEGIN

 SELECT * FROM Customer_Master WHERE Email =@Email and OTP=@OTP;
		
END
