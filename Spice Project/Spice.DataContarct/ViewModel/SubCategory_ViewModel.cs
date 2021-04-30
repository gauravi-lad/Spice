using Newtonsoft.Json;
using Spice.DataContarct.CommanUtils;
using Spice.DataContarct.DataModel;
using System.Collections.Generic;

namespace Spice.DataContarct.ViewModel
{
    public class SubCategory_ViewModel
    {
        public SubCategory_ViewModel()
        {
            subCategory = new SubCategory_DataModel();
            lst_subCategory = new List<SubCategory_DataModel>();
            drpDwn_Category = new List<CategoryMasterDataModel>();
        }
        public SubCategory_DataModel subCategory { get; set; }

        public List<SubCategory_DataModel> lst_subCategory { get; set; }

        public List<CategoryMasterDataModel> drpDwn_Category
        {
            get
            {
                List<CategoryMasterDataModel> result = new List<CategoryMasterDataModel>();
                result = JsonConvert.DeserializeObject<List<CategoryMasterDataModel>>(SiteUtils.Get_drpDwn_Category());
                return result;
            }
            set {  }
        }
    }
}
