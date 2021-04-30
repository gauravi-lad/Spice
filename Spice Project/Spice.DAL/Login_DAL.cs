using Spice.CommanUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice.DAL
{
    public class Login_DAL
    {
        public string GetFrontEndInfoByID(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("sp_get_data_frontend_login", parameters);
        }
        public string GetBackEndInfoByID(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("sp_get_data_backend_login", parameters);
        }
    }
}
