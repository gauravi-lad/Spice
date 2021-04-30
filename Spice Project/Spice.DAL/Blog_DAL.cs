using Spice.CommanUtilities;
using System.Collections.Generic;

namespace Spice.DAL
{
    public class Blog_DAL
    {
        public string GetBlogListing(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("Sp_lst_Blog", parameters);
        }


        public string GetBlogById(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("Sp_get_id_Blog", parameters);
        }


        public string Insert_Update_Blog(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("Sp_ins_upd_Blog", parameters);
        }
    }
}
