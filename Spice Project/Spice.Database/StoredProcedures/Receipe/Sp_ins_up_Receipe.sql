Create PROC [dbo].[Sp_ins_up_Receipe]
(
@ReceipeId int,
@ReceipeName nvarchar(50),
@Description nvarchar(max),
@ProductId int,
@IsActive bit
)
AS
BEGIN
IF EXISTS(SELECT ReceipeId FROM ReceipeMaster WHERE ReceipeId=@ReceipeId)
BEGIN
UPDATE ReceipeMaster SET
ReceipeName=@ReceipeName,
Description=@Description,
ProductId=@ProductId,
IsActive=@IsActive
WHERE ReceipeId=@ReceipeId 

Select 2 as Status;
END
ELSE
BEGIN
INSERT INTO ReceipeMaster
(
ReceipeName,
Description,
ProductId,
IsActive
)
VALUES
(
@ReceipeName,
@Description,
@ProductId,
@IsActive
)

Select 1 as Status;
END
END
