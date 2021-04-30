
CREATE PROC [dbo].[Sp_get_id_Receipe]
(
@ReceipeId int
)
AS
BEGIN
SELECT ReceipeId,ReceipeName,Description,RM.ProductId,RM.IsActive,P.ProductName
FROM ReceipeMaster RM
LEFT JOIN Product P on P.ProductId=RM.ProductId and P.IsActive=1
WHERE RM.ReceipeId=@ReceipeId AND RM.IsActive=1
END

