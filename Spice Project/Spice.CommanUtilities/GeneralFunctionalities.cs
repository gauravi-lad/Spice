using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Spice.CommanUtilities
{
    public static class GeneralFunctionalities
    {
        public static string SetPagination(IEnumerable<object> list, int page, int pageSize)
        {
            if (list != null)
            {
                return JsonConvert.SerializeObject(list.Skip((page) * pageSize).Take(pageSize).ToList());
            }
            else
            {
                return "";
            }
        }


        //The upgraded Code V2.0 to be use instead of Code V1.0

        //Implementation Date - 27.07.2020
        #region Code V1.0 - Comman function to process data (Insert / Get_by_id / Listing) only for single table (Data table)
        public static string Process_Insert_Data_Single_Table(string sp_name, List<KeyValuePair<string, string>> parameters)
        {
            string result = string.Empty;

            DataTable dataTable = new DataTable();

            List<SqlParameter> dbParameters = new List<SqlParameter>();

            foreach (var items in parameters)
            {
                dbParameters.Add(new SqlParameter(items.Key, items.Value));
            }

            dataTable = SQLHelper.ExecuteDataTable(dbParameters, sp_name);

            //  result = JsonConvert.SerializeObject(dataTable); 

            if (dataTable.Rows.Count > 0)
            {
                result = new JObject(dataTable.Columns.Cast<DataColumn>().Select(c => new JProperty(c.ColumnName, JToken.FromObject(dataTable.Rows[0][c])))).ToString(Formatting.None);
            }

            return result;
        }

        public static string Process_Listing_Data_Single_Table(string sp_name, List<KeyValuePair<string, string>> parameters)
        {
            string result = string.Empty;

            DataTable dataTable = new DataTable();

            List<SqlParameter> dbParameters = new List<SqlParameter>();

            if (parameters != null)
            {
                foreach (var items in parameters)
                {
                    dbParameters.Add(new SqlParameter(items.Key, items.Value));
                }
            }

            dataTable = SQLHelper.ExecuteDataTable(dbParameters, sp_name);

            result = JsonConvert.SerializeObject(dataTable);

            return result;
        }

        public static string Process_GetById_Data_Single_Table(string sp_name, List<KeyValuePair<string, string>> parameters)
        {
            string result = string.Empty;

            DataTable dataTable = new DataTable();

            List<SqlParameter> dbParameters = new List<SqlParameter>();

            foreach (var items in parameters)
            {
                dbParameters.Add(new SqlParameter(items.Key, items.Value));
            }

            dataTable = SQLHelper.ExecuteDataTable(dbParameters, sp_name);

            if (dataTable.Rows.Count > 0)
            {
                result = new JObject(dataTable.Columns.Cast<DataColumn>().Select(c => new JProperty(c.ColumnName, JToken.FromObject(dataTable.Rows[0][c])))).ToString(Formatting.None);
            }

            //result = JsonConvert.SerializeObject(dataTable);

            return result;
        }

        #endregion

        //Implementation Date - 13.09.2020
        #region Code V2.0 - The upgraded Code for Comman function to process data (Insert / Get_by_id / Listing) for single as well as Multiple table (Json Based)

        // This upgraded functionalities are based on Json where as Insert Method require Json as I/p and Get method returns Json as o/p

        public static string Process_Insert_Json_Data(string sp_name, string parameters)
        {
            string result = string.Empty;

            DataTable dataTable = new DataTable();

            List<SqlParameter> dbParameters = new List<SqlParameter>();

            dbParameters.Add(new SqlParameter("@json", parameters));

            dataTable = SQLHelper.ExecuteDataTable(dbParameters, sp_name);

            if (dataTable.Rows.Count > 0)
            {
                result = Convert.ToString(dataTable.Rows[0][0]);
            }

            return result;
        }

        // This Method can be use for get_by_Id as well as for Listing as it accept n number of parameters and returns o/p in json format 
        public static string Process_GetById_GetListing_Json_Data(string sp_name, List<KeyValuePair<string, string>> parameters)
        {
            string result = string.Empty;

            DataTable dataTable = new DataTable();

            List<SqlParameter> dbParameters = new List<SqlParameter>();

            foreach (var items in parameters)
            {
                dbParameters.Add(new SqlParameter(items.Key, items.Value));
            }

            dataTable = SQLHelper.ExecuteDataTable(dbParameters, sp_name);

            if (dataTable.Rows.Count > 0)
            {
                result = Convert.ToString(dataTable.Rows[0][0]);
            }

            return result;
        }

        #endregion


    }
}
