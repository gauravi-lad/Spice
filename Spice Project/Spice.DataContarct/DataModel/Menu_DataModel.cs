using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice.DataContarct.DataModel
{
    public class Menu_DataModel
    {

        public Menu_DataModel()
        {
            //SubMenuList = new List<SubMenuInfo>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryShortDescription { get; set; }
        public string CategoryLongDescription { get; set; }

        public int? SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string SubCategoryDesc { get; set; }

        //public int Menu_Id { get; set; }

        //public string Menu_Name { get; set; }

        //public string Menu_URL { get; set; }

        //public List<SubMenuInfo> SubMenuList { get; set; }
    }

    public class SubMenuInfo
    {
        public int Menu_Id { get; set; }

        public int SubMenu_Id { get; set; }

        public string SubMenu_Name { get; set; }
    }
}
