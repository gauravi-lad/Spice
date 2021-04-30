﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice.DataContarct.DataModel.Common
{
    public class FrontEnd_JWTInfo
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Second_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Mobile_Number { get; set; }
        public string Email { get; set; }
        public string IsActive { get; set; }
        public string ProfilePicture { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Mobile_Verified { get; set; }
    }
}
