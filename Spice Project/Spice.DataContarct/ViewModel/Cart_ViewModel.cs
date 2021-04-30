using Spice.DataContarct.DataModel;
using System.Collections.Generic;

namespace Spice.DataContarct.ViewModel
{
    public class Cart_ViewModel
    {
        public Cart_ViewModel()
        {
            cart_DataModel = new CartDataModel();
            lst_CartDataModel = new List<CartDataModel>();
        }
        public CartDataModel cart_DataModel { get; set; }
        public List<CartDataModel> lst_CartDataModel { get; set; }
    }
}
