CREATE procedure [dbo].[sp_get_GetRecentProductList]
AS
select TOP 10 * from Product where IsActive=1 
Order by Createddate desc