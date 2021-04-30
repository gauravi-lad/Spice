using System;
using System.ComponentModel.DataAnnotations;

namespace Spice.DataContarct.DataModel
{
    public class CustomerMaster_DataModel
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Second_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Mobile_Number { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string ProfilePicture { get; set; }
        public string LastProfilePicture { get; set; }
        public string Gender { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        
        public DateTime? DOB { get; set; }
        public string DOB_string { get; set; }

        public int Mobile_Verified { get; set; }
    }
}
