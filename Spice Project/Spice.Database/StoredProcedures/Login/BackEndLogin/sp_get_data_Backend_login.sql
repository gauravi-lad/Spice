CREATE PROCEDURE [dbo].[sp_get_data_Backend_login]
	@Username varchar(max),
	@Password varchar(max)
AS
BEGIN
	SELECT *  FROM [usermaster] WHERE [Username]=@Username AND [Password]=@Password
END
GO
