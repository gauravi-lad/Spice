using Spice.CommanUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice.DAL
{
    public class ForgotPassword_DAL
    {
        public string UpdateOTP(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("sp_upt_OTP", parameters);
        }

        public string Update_Reseted_Password(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("sp_upt_Reset_Password", parameters);
        }

        public string GetCustomerByEmail(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("sp_get_Customer_By_Email", parameters);
        }

        public string GetUserResetPassword(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_GetById_Data_Single_Table("sp_get_Customer_By_Email_For_Reset_Password", parameters);
        }

    }
}
