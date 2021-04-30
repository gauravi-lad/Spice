using Newtonsoft.Json.Linq;
using Spice.BAL;
using Spice.DataContarct.ViewModel;
using System.Web.Mvc;

namespace Spice.Web.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog


        public BlogController()
        {
            Blog = new Blog_BAL();
            obj_Product = new Product_BAL();
        }

        readonly Blog_BAL Blog;
        Product_BAL obj_Product;

        public ActionResult BlogMaster()
        {
            BlogViewModel obj_Blog = new BlogViewModel();
            if (TempData["Result"] != null)
                ViewBag.Result = TempData["Result"].ToString();
            obj_Blog.lst_Product = obj_Product.GetAllProducts();
            return View(obj_Blog);
        }

        public ActionResult Insert_Update_Blog(BlogViewModel obj_Blog)
        {
           var result= Blog.Insert_Update_Blog(obj_Blog.Blog);
            if (result != "")
            {
                var statusObj = JObject.Parse(result);
                TempData["Result"] = (string)statusObj["Status"];
            }
            else
            {
                TempData["Result"] = "0";
            }
            return RedirectToAction("BlogMaster");
        }
        public ActionResult GetBlogListing()
        {
            BlogViewModel obj_Blog = new BlogViewModel();
            obj_Blog.lst_Blog = Blog.GetBlogListing();
            return Json(obj_Blog.lst_Blog, JsonRequestBehavior.AllowGet);
        }

        
        //public ActionResult GetBlogById(int Id)
        //{
        //    BlogViewModel obj_Blog = new BlogViewModel();
        //    obj_Blog.Blog = Blog.GetBlogById(Id);
        //    obj_Blog.lst_Product = obj_Product.GetAllProducts();
        //    return View("BlogMaster", obj_Blog);
        //}
    }
}