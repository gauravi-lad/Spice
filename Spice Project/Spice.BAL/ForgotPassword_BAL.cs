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
    public class ForgotPassword_BAL
    {
        private CustomerMaster_DataModel _customer = null;

        private string message = null;

        int OTP = 0;

        bool flag = true;

        bool IsPasswordUpdateSuccessfully = true;

        public ForgotPassword_BAL()

        {
            obj_ForgotPasswordDAL = new ForgotPassword_DAL();
        }

        ForgotPassword_DAL obj_ForgotPasswordDAL;

        public bool VerifyUser(string Username)
        {

            try
            {
                Get_User(Username);

                if (_customer != null)
                {
                    Genrate_OTP();

                    Update_OTP(Username);

                    Send_Message();

                    flag = true;
                }
                else
                {
                    flag = false;
                    //throw new Exception(string.Format("Invalid Username."));

                }
            }

            catch (Exception ex)
            {
                throw;
            }

            return flag;
        }

        private void Get_User(string MobileNo)
        {
            ForgotPassword_ViewModel obj_ForgotPasswordVM = new ForgotPassword_ViewModel();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@MobileNo", Convert.ToString(MobileNo)));
            _customer = JsonConvert.DeserializeObject<CustomerMaster_DataModel>(obj_ForgotPasswordDAL.GetCustomerByEmail(getByID_Parameters));
        }

        private void Genrate_OTP()
        {
            string str = string.Empty;

            int _minStart = 1000;
            int _maxEnd = 9999;
            Random _rdm = new Random();

            OTP = _rdm.Next(_minStart, _maxEnd);
            message = "Welcome to ReShapeMe, We are happy to have registered with us Your OTP is " + OTP + "\nThanks";


        }

        public void Update_OTP(string MobileNo)
        {

            List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();

            insert_Parameters.Add(new KeyValuePair<string, string>("@MobileNo", MobileNo));
            insert_Parameters.Add(new KeyValuePair<string, string>("@OTP", Convert.ToString(OTP)));
            obj_ForgotPasswordDAL.UpdateOTP(insert_Parameters);
        }

        private string Send_Message()
        {
            string str = string.Empty;
            try
            {
                //System.Net.WebRequest req = System.Net.WebRequest.Create("https://login.bulksmsgateway.in/sendmessage.php?user="+"Pooja2690"+"&password=pooja@100&mobile="+message+"&sender=RESHAP&type=3");
                System.Net.WebRequest req = System.Net.WebRequest.Create("https://login.bulksmsgateway.in/sendmessage.php?user=" +
                                "Pooja2690" + "&password=pooja@100&mobile=" + _customer.Mobile_Number + "&message=" + message + "&sender=RESHAP&type=3"); req.Proxy = new System.Net.WebProxy(); //true means no proxy
                System.Net.WebResponse resp = req.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                str = sr.ReadToEnd().Trim();
            }
            catch (Exception ex)
            {
                // Logger.CreateLog("SendSMS", ex.Message);
                return str;
            }
            return str;


        }

        public bool ResetPassword(ForgotPassword_ViewModel obj_ForgotPasswordVM)
        {

            try
            {
                Get_User_For_Reset_Password(obj_ForgotPasswordVM.forgotPassword.MobileNo, obj_ForgotPasswordVM.forgotPassword.OTP);

                if (_customer != null)
                {
                    Update_Reseted_Password(obj_ForgotPasswordVM.forgotPassword.MobileNo, obj_ForgotPasswordVM.forgotPassword.NewPassword);
                    IsPasswordUpdateSuccessfully = true;
                }
                else
                {
                    IsPasswordUpdateSuccessfully = false;
                    //throw new Exception(string.Format("OTP does not match with Username."));

                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return IsPasswordUpdateSuccessfully;
        }

        private void Get_User_For_Reset_Password(string MobileNo, string OTP)
        {
            _customer = null;
            ForgotPassword_ViewModel obj_ForgotPasswordVM = new ForgotPassword_ViewModel();
            List<KeyValuePair<string, string>> getByID_Parameters = new List<KeyValuePair<string, string>>();
            getByID_Parameters.Add(new KeyValuePair<string, string>("@MobileNo", Convert.ToString(MobileNo)));
            getByID_Parameters.Add(new KeyValuePair<string, string>("@OTP", Convert.ToString(OTP)));
            _customer = JsonConvert.DeserializeObject<CustomerMaster_DataModel>(obj_ForgotPasswordDAL.GetUserResetPassword(getByID_Parameters));
        }

        public void Update_Reseted_Password(string MobileNo, string NewPassword)
        {

            List<KeyValuePair<string, string>> insert_Parameters = new List<KeyValuePair<string, string>>();

            insert_Parameters.Add(new KeyValuePair<string, string>("@MobileNo", MobileNo));
            insert_Parameters.Add(new KeyValuePair<string, string>("@New_Password", NewPassword));
            obj_ForgotPasswordDAL.Update_Reseted_Password(insert_Parameters);

        }





    }
}
