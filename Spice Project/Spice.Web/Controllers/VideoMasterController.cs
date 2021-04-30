using Newtonsoft.Json.Linq;
using Spice.BAL;
using Spice.DataContarct.ViewModel;
using System.Web.Mvc;

namespace Spice.Web.Controllers
{
    public class VideoMasterController : Controller
    {
        // GET: VideoMaster
        public VideoMasterController()
        {
            Video = new VideoMaster_BAL();
            obj_Product = new Product_BAL();
            obj_Receipe = new Receipe_BAL();
        }

        readonly VideoMaster_BAL Video;
        Product_BAL obj_Product;
        Receipe_BAL obj_Receipe;

        public ActionResult VideoMaster()
        {
            VideoMaster_ViewModel obj_Video = new VideoMaster_ViewModel();
            if (TempData["Result"] != null)
                ViewBag.Result = TempData["Result"].ToString();
            obj_Video.lst_Product = obj_Product.GetAllProducts();
            obj_Video.lst_Receipe = obj_Receipe.GetReceipeListing();
            return View(obj_Video);
        }

        public ActionResult Insert_Update_Video(VideoMaster_ViewModel obj_Video)
        {
            var result = Video.Insert_Update_Video(obj_Video.Video);
            if (result != "")
            {
                var statusObj = JObject.Parse(result);
                TempData["Result"] = (string)statusObj["Status"];
            }
            else
            {
                TempData["Result"] = "0";
            }
            return RedirectToAction("VideoMaster");
        }

        public ActionResult GetVideoListing()
        {
            VideoMaster_ViewModel obj_Video = new VideoMaster_ViewModel();
            obj_Video.lst_Video = Video.GetVideoListing();
            return Json(obj_Video.lst_Video, JsonRequestBehavior.AllowGet);
        }

       
        //public ActionResult GetVideoById(int Video_Id)
        //{
        //    VideoMaster_ViewModel obj_Video = new VideoMaster_ViewModel();
        //    obj_Video.Video = Video.GetVideoById(Video_Id);
        //    obj_Video.lst_Product = obj_Product.GetAllProducts();
        //    obj_Video.lst_Receipe = obj_Receipe.GetReceipeListing();
        //    return View("VideoMaster", obj_Video);
        //}
    }
}