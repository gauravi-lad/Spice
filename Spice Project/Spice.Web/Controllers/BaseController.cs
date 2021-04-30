using Spice.CommanUtilities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spice.Web.Controllers
{
    public class BaseController : Controller
    {
        public FrontEnd_JWTInfo _claimFrontEnd;

        public BackEnd_JWTInfo _claimBackEnd;
        public BaseController()
        {
            _claimFrontEnd = new FrontEnd_JWTInfo();

            _claimBackEnd = new BackEnd_JWTInfo();
        }

        [NonAction]
        public void FrontEnd_Parse_Claim()
        {
            if (Request.Cookies["FrontEndToken"] != null)
            {
                string token = Request.Cookies["FrontEndToken"].Value;

                using (JWT_Provider jWT_Provider = new JWT_Provider())
                {
                    _claimFrontEnd = jWT_Provider.Decode_FrontEnd_Token(token);
                }
            }
            else
            {
                _claimFrontEnd = null;
             }
        }

        public void BackEnd_Parse_Claim()
        {
            if (Request.Cookies["BackEndToken"] != null)
            {
                string token = Request.Cookies["BackEndToken"].Value;

                using (JWT_Provider jWT_Provider = new JWT_Provider())
                {
                    _claimBackEnd = jWT_Provider.Decode_BackEnd_JWTInfoToken(token);

                }
                
            }
            else
            {
                _claimBackEnd = null;

                //throw new Exception("Claim can only be parsed only when 'Access_Token' is passed through request Header");
            }
        }
    }
}