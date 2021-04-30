CREATE procedure [dbo].[sp_get_GetBestSellerProductList]
AS
select * from Product where IsActive=1