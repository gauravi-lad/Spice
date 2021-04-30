using Spice.CommanUtilities;
using System.Collections.Generic;

namespace Spice.DAL
{
    public class VideoMaster_DAL
    {
        public string GetVideoListing(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("Sp_lst_Video_Master", parameters);
        }


        public string GetVideoById(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("Sp_get_id_Video_Master", parameters);
        }


        public string Insert_Update_Video(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("Sp_ins_upd_Video_Master", parameters);
        }
    }
}
