using Spice.DataContarct.DataModel;
using System.Collections.Generic;

namespace Spice.DataContarct.ViewModel
{
    public class CategoryMasterViewModel
    {
        public CategoryMasterViewModel()
        {
            category = new CategoryMasterDataModel();
            lst_category = new List<CategoryMasterDataModel>();

        }
        public CategoryMasterDataModel category { get; set; }
        public List<CategoryMasterDataModel> lst_category { get; set; }
    }

}