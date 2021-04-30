using Newtonsoft.Json;
using Spice.DataContarct.CommanUtils;
using Spice.DataContarct.DataModel;
using System.Collections.Generic;

namespace Spice.DataContarct.ViewModel
{
    public class Home_ViewModel
    {
        public Home_ViewModel()
        {
            home = new Home_DataModel();
            lst_home = new List<Home_DataModel>();
        }

        public Home_DataModel home { get; set; }
        public List<Home_DataModel> lst_home { get; set; }

        public List<KeyValuePair<string, string>> gender
        {
            get
            {
                return SiteUtils.Gender();

            }
        }

        public List<demo_category> demo_category
        {
            get
            {
                List<demo_category> result = new List<demo_category>();
                result = JsonConvert.DeserializeObject<List<demo_category>>(SiteUtils.Get_drpDwn_Category());
                return result;

            }
        }
    }
}
