using Spice.CommanUtilities;
using System.Collections.Generic;

namespace Spice.DAL
{
    public class FrontEnd_DAL
    {
        public string GetMenuList()
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_get_MenuList", null);
        }
    }
}
