CREATE procedure sp_get_categoryId
(
@CategoryId Int
)
AS
select * from CategoryMaster where CategoryId = @CategoryId