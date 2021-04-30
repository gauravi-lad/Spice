using Spice.BAL;
using Spice.DataContarct.ViewModel;
using System.Web.Mvc;

namespace Spice.Web.Controllers
{
    public class ProductSubCategoryMappingController : Controller
    {
        public ProductSubCategoryMappingController()
        {
            obj_ProductSubCategoryMapping = new ProductSubCategoryMapping_BAL();
        }

        readonly ProductSubCategoryMapping_BAL obj_ProductSubCategoryMapping;

        [HttpPost]
        public JsonResult InsertUpdateProductDetails(ProductSubCategoryMapping_ViewModel obj_ProductSubCategoryMappingVM)
        {
            obj_ProductSubCategoryMapping.Add(obj_ProductSubCategoryMappingVM);

            return Json(obj_ProductSubCategoryMappingVM);
        }




    }
}