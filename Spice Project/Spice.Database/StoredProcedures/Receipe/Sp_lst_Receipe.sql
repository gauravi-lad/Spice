CREATE PROC [dbo].[Sp_lst_Receipe]
AS
BEGIN
SELECT ReceipeId,ReceipeName,Description,RM.ProductId,RM.IsActive,P.ProductName

FROM ReceipeMaster RM
LEFT JOIN Product P on P.ProductId=RM.ProductId and P.IsActive=1
WHERE  RM.IsActive=1
END
