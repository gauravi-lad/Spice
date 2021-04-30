using Spice.CommanUtilities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice.DataContarct.DataModel
{
    public class BackEndLogin_DataModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public BackEnd_JWTInfo backEnd_JWTInfo { get; set; }
    }

  
}
