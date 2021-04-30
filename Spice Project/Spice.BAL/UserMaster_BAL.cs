using Newtonsoft.Json;
using Spice.DAL;
using Spice.DataContarct.DataModel;
using Spice.DataContarct.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice.BAL
{
    public class UserMaster_BAL
    {
        public UserMaster_BAL()
        {
            UserMaster = new UserMaster_DAL();
        }

        UserMaster_DAL UserMaster;

        public void Insert_Data(UserMaster_DataModel usermaster_DataModel)
        {
            List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();
            insert_Parameters.Add(new KeyValuePair<string, string>("@Id", Convert.ToString(usermaster_DataModel.Id)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Username", Convert.ToString(usermaster_DataModel.Username)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Password", Convert.ToString(usermaster_DataModel.Password)));
            insert_Parameters.Add(new KeyValuePair<string, string>("@Role", Convert.ToString(usermaster_DataModel.Role)));
            UserMaster.Insert(insert_Parameters);
        }

        public UserMaster_ViewModel GetDataById(int Id)
        {
            UserMaster_ViewModel usermasterVM = new UserMaster_ViewModel();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@Id", Convert.ToString(Id)));
            usermasterVM.userMaster = JsonConvert.DeserializeObject<UserMaster_DataModel>(UserMaster.GetByID(getByID_Parameters));
            return usermasterVM;
        }

        public UserMaster_ViewModel GetDataListing()
        {
            UserMaster_ViewModel usermasterVM = new UserMaster_ViewModel();
            List<KeyValuePair<string, string>> listing_Parameters = new List<KeyValuePair<string, string>>();
            usermasterVM.lst_userMaster = JsonConvert.DeserializeObject<List<UserMaster_DataModel>>(UserMaster.Get_Listing(listing_Parameters));
            return usermasterVM;
        }
    }
}
