using Spice.DataContarct.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice.DataContarct.ViewModel
{
    public class UserMaster_ViewModel
    {
        public UserMaster_ViewModel()
        {
            userMaster = new UserMaster_DataModel();
            lst_userMaster = new List<UserMaster_DataModel>();
        }

        public UserMaster_DataModel userMaster { get; set; }
        public List<UserMaster_DataModel> lst_userMaster { get; set; }
    }
}
