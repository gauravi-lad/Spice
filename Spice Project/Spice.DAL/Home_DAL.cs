using Spice.CommanUtilities;
using System.Collections.Generic;

namespace Spice.DAL
{
    public class Home_DAL
    {
        public string Get_Listing(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("DummyListing_StoreProcedure", parameters);
        }


        public string GetByID(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("DummyGetByID_StoreProcedure", parameters);
        }


        public string Insert(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("DummyInsert_StoreProcedure", parameters);
        }
    }
}
