using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice.CommanUtilities.Authentication
{
    public class BackEnd_JWTInfo
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public DateTime Expire_Time { get; set; }
        public string Token { get; set; }
        
    }

}
