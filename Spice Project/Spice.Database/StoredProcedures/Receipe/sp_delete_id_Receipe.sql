Create proc [dbo].[sp_delete_id_Receipe]
(
@ReceipeId INT
)
AS
BEGIN
UPDATE ReceipeMaster SET IsActive=0
Where ReceipeId=@ReceipeId AND IsActive=1
 
END