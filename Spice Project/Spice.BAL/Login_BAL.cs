using Newtonsoft.Json;
using Spice.CommanUtilities.Authentication;
using Spice.DAL;
using Spice.DataContarct.DataModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice.BAL
{
    public class Login_BAL
    {
        public Login_BAL()
        {
            Login_DAL = new Login_DAL();

            JWT_Provider = new JWT_Provider();
        }

        Login_DAL Login_DAL;

        JWT_Provider JWT_Provider;
        public FrontEnd_JWTInfo GetAccessTokenForFrontEndUser(string Email, string Password)
        {
            //string token = null;

            FrontEnd_JWTInfo fronEndJWT = new FrontEnd_JWTInfo();

            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@Email", Convert.ToString(Email)));
            getByID_Parameters.Add(new KeyValuePair<string, string>("@Password", Convert.ToString(Password)));
            fronEndJWT = JsonConvert.DeserializeObject<FrontEnd_JWTInfo>(Login_DAL.GetFrontEndInfoByID(getByID_Parameters));
            if (fronEndJWT != null)
            {
                fronEndJWT.Expire_Time = DateTime.Now.AddHours(24);
                fronEndJWT.UserToken = JWT_Provider.Generate_FrontEnd_Token(fronEndJWT);
            }
            else
            {
              fronEndJWT = new FrontEnd_JWTInfo();
                fronEndJWT.UserToken = null;
            }
            return fronEndJWT;
        }

        public BackEnd_JWTInfo GetAccessTokenForBackEndUser(string Username, string Password)
        {
            BackEnd_JWTInfo backEndJWT = new BackEnd_JWTInfo();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@Username", Convert.ToString(Username)));
            getByID_Parameters.Add(new KeyValuePair<string, string>("@Password", Convert.ToString(Password)));
            backEndJWT = JsonConvert.DeserializeObject<BackEnd_JWTInfo>(Login_DAL.GetBackEndInfoByID(getByID_Parameters));
            if (backEndJWT != null)
            {
                backEndJWT.Expire_Time = DateTime.Now.AddHours(24);
                backEndJWT.Token = JWT_Provider.Generate_BackEnd_Token(backEndJWT);
            }
            else
            {
                backEndJWT.Token = null;
            }
            return backEndJWT;
        }
    }
}
