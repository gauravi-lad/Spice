using Spice.BAL;
using System.Web;
using System.Web.Mvc;

namespace Spice.Web.Controllers
{
    public class ProductImageController : Controller
    {
        public ProductImageController()
        {
            obj_ProductImage = new ProductImage_BAL();
        }

        readonly ProductImage_BAL obj_ProductImage;



        [HttpPost]
        public JsonResult InsertUpdateProductImage(HttpPostedFileBase File, string Name, int ProductId, bool isDefault)
        {
            obj_ProductImage.UploadDocument(Name, File, ProductId, isDefault);
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateDocumentUpload(HttpPostedFileBase File, string Name, int ProductId, string uniqeFileName, int DocumentId, bool IsDefaultImage)
        {
            obj_ProductImage.UpdateUploadDocument(Name, File, ProductId, uniqeFileName, DocumentId, IsDefaultImage);
            return Json(null, JsonRequestBehavior.AllowGet);
        }


    }
}