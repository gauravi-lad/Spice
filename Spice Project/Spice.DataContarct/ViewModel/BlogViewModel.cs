using Spice.DataContarct.DataModel;
using System.Collections.Generic;

namespace Spice.DataContarct.ViewModel
{
    public class BlogViewModel
    {

        public BlogViewModel()
        {
            Blog = new BlogDataModel();
            lst_Blog = new List<BlogDataModel>();
            lst_Product = new List<Product_DataModel>();
        }

        public BlogDataModel Blog { get; set; }
        public List<BlogDataModel> lst_Blog { get; set; }
        public List<Product_DataModel> lst_Product { get; set; }
    }

}
