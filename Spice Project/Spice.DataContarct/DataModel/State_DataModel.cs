using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice.DataContarct.DataModel
{
   public class State_DataModel
    {  
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
    }

    public class GST_DataModel
    {
        public int GSTId { get; set; }
        public string GSTValue { get; set; }
        public bool IsActive { get; set; }

    }
    public class Country_DataModel
    {
      public int CountryId { get; set; }
      public string CountryName { get; set; }
      public string Iso { get; set; }
      public string Iso3 { get; set; }


    }
}
