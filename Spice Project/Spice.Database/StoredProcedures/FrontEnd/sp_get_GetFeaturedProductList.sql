CREATE procedure [dbo].[sp_get_GetFeaturedProductList]
AS
select * from Product where IsFeatured=1 and IsActive=1