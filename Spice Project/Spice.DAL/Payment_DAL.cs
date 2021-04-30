using Spice.CommanUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice.DAL
{
    public class Payment_DAL
    {
        public string Insert_Payment(List<KeyValuePair<string, string>> parameters)
        {
            return GeneralFunctionalities.Process_Insert_Data_Single_Table("Sp_ins_upd_PaymentMaster", parameters);
        }
    }
}
