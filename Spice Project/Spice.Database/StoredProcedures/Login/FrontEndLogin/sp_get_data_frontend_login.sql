CREATE PROCEDURE [dbo].[sp_get_data_frontend_login]

	@Email varchar(max),
	@Password varchar(max)
AS
BEGIN
	SELECT * FROM CUSTOMER_MASTER WHERE EMAIL=@Email AND [PASSWORD]=@Password
END
GO
