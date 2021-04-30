using Spice.DataContarct.DataModel;
using System.Collections.Generic;

namespace Spice.DataContarct.ViewModel
{
    public class Receipe_ViewModel
    {
        public Receipe_ViewModel()
        {
            Receipe = new Receipe_DataModel();
            lst_Receipe = new List<Receipe_DataModel>();
            lst_Product = new List<Product_DataModel>();
        }

        public Receipe_DataModel Receipe { get; set; }
        public List<Receipe_DataModel> lst_Receipe { get; set; }
        public List<Product_DataModel> lst_Product { get; set; }
    }
}
