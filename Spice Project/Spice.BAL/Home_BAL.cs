using Newtonsoft.Json;
using Spice.CommanUtilities;
using Spice.DAL;
using Spice.DataContarct.DataModel;
using Spice.DataContarct.ViewModel;
using System;
using System.Collections.Generic;

namespace Spice.BAL
{
    public class Home_BAL
    {
        public Home_BAL()
        {
            Home = new Home_DAL();
        }

        readonly Home_DAL Home;

        public void ProcessData()
        {
            Home_ViewModel homeVM = new Home_ViewModel();

            #region Processing Data in Single table

            List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();
            insert_Parameters.Add(new KeyValuePair<string, string>("@ID", "4"));
            insert_Parameters.Add(new KeyValuePair<string, string>("@FirstName", "R 4 FName"));
            insert_Parameters.Add(new KeyValuePair<string, string>("@LastName", "R 4 LName"));
            Home.Insert(insert_Parameters);


            List<KeyValuePair<string, string>> listing_Parameters = new List<KeyValuePair<string, string>>();
            listing_Parameters.Add(new KeyValuePair<string, string>("@FirstName", null));
            homeVM.lst_home = JsonConvert.DeserializeObject<List<Home_DataModel>>(Home.Get_Listing(listing_Parameters));


            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@ID", "2"));
            homeVM.home = JsonConvert.DeserializeObject<Home_DataModel>(Home.GetByID(getByID_Parameters));

            Logger.log(homeVM.home, Convert.ToString(LogDirectory.Data_Log));

            #endregion

            #region Processing Data in Multiple tables

            #endregion

        }



    }
}
