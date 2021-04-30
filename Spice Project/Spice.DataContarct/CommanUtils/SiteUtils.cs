using Spice.CommanUtilities;
using System;
using System.Collections.Generic;

namespace Spice.DataContarct.CommanUtils
{
    public static class SiteUtils
    {
        public static int Pagination_Page_Count { get; set; }

        public static string login_view
        {
            get
            {
                return "~/Views/Login/Login.cshtml";
            }
        }

        public static List<int> Pagination_pages(int total_records, int current_page)
        {
            var page_no = new List<int>();
            decimal value;

            decimal pages = Decimal.Divide(total_records, 10);

            if (Decimal.TryParse(Convert.ToString(pages), out value))
            {
                string[] parts = Convert.ToString(pages).Split('.');

                pages = int.Parse(parts[0]) + 1;
                Pagination_Page_Count = Convert.ToInt32(pages);
            }

            if (pages >= 0)
            {
                for (int i = 1; i <= pages; i++)
                {
                    if (current_page < 7 && i <= 10)
                    {
                        page_no.Add(i);
                    }
                    else if (i > current_page - 6 && i <= current_page + 4)
                    {
                        page_no.Add(i);
                    }

                }

            }

            return page_no;
        }

        public static List<KeyValuePair<string, string>> Gender()
        {
            var list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("Male", "M"));
            list.Add(new KeyValuePair<string, string>("Female", "F"));
            return list;
        }

        // For refrence --> check demo_category in Home_ViewModel 
        //Demo Category list set in Class attribut--> directly load from database No need to write code in controller
        public static string Get_drpDwn_Category()
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("sp_lst_drpDwn_category", parameters);
        }

        public static string Get_drpDwn_Vendor()
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("Sp_lst_Vendor", parameters);
        }

        public static string Get_Product_Vendor_Mapping()
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            return GeneralFunctionalities.Process_Listing_Data_Single_Table("Sp_lst_Product_Vendor_Mapping", parameters);
        }
    }
}

