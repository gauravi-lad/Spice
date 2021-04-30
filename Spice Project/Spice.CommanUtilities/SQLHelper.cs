using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Spice.CommanUtilities
{
    public static class SQLHelper
    {

        private static readonly string environment = Convert.ToString(ConfigurationManager.AppSettings["Server_Environment"]);
        private static readonly string _sqlCon = Convert.ToString(environment == "DEV" ? ConfigurationManager.ConnectionStrings["SpiceDB_DEV"] : ConfigurationManager.ConnectionStrings["SpiceDB_PROD"]);

        //To Return Multiple Tables 
        public static DataSet ExecuteDataSet(List<SqlParameter> sqlParams, string sqlQuery)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, con))
                    {

                        //SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.CommandTimeout = 300;
                        if (sqlParams != null)
                        {
                            foreach (SqlParameter sqlPrm in sqlParams)
                            {
                                if (sqlPrm.Value == null)
                                    sqlPrm.Value = DBNull.Value;
                            }
                            sqlCmd.Parameters.AddRange(sqlParams.ToArray());
                        }

                        SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd);
                        sqlDA.Fill(ds);
                    }
                }


            }
            catch (SqlException sqlEx)
            {
                Logger.log(sqlEx, Convert.ToString(LogDirectory.DB_Connection_Exception_Log));
            }
            catch (Exception ex)
            {
                Logger.log(ex, Convert.ToString(LogDirectory.DB_Connection_Exception_Log));
            }

            return ds;
        }

        //To Return Single Table  
        public static DataTable ExecuteDataTable(List<SqlParameter> sqlParams, string sqlQuery)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, con))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.CommandTimeout = 300;
                        if (sqlParams != null)
                        {
                            foreach (SqlParameter sqlPrm in sqlParams)
                            {
                                if (sqlPrm.Value == null)
                                    sqlPrm.Value = DBNull.Value;
                            }
                            sqlCmd.Parameters.AddRange(sqlParams.ToArray());
                        }

                         SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd);
                        sqlDA.Fill(dt);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Logger.log(sqlEx, Convert.ToString(LogDirectory.DB_Connection_Exception_Log));
            }
            catch (Exception ex)
            {
                Logger.log(ex, Convert.ToString(LogDirectory.DB_Connection_Exception_Log));
            }
            return dt;
        }

        //No Return type 
        public static void ExecuteNonQuery(List<SqlParameter> sqlParams, string sqlQuery)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                using (con = new SqlConnection(_sqlCon))
                {
                    con.Open();
                    using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, con))
                    {

                        //SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        if (sqlParams != null)
                        {
                            foreach (SqlParameter sqlPrm in sqlParams)
                            {
                                if (sqlPrm.Value == null)
                                    sqlPrm.Value = DBNull.Value;
                            }
                            sqlCmd.Parameters.AddRange(sqlParams.ToArray());
                        }

                        sqlCmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (con != null)
                    con.Close();

                throw sqlEx;
            }
            catch (Exception ex)
            {
                if (con != null)
                    con.Close();

                throw ex;
            }
        }

        //To Return Single value / variable
        public static object ExecuteScalerObj(List<SqlParameter> sqlParams, string sqlQuery)
        {
            SqlConnection con = new SqlConnection();

            object result = 0;
            try
            {
                using (con = new SqlConnection(_sqlCon))
                {
                    con.Open();
                    using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, con))
                    {

                        //SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        if (sqlParams != null)
                        {
                            foreach (SqlParameter sqlPrm in sqlParams)
                            {
                                if (sqlPrm.Value == null)
                                    sqlPrm.Value = DBNull.Value;
                            }
                            sqlCmd.Parameters.AddRange(sqlParams.ToArray());
                        }

                        result = sqlCmd.ExecuteScalar();
                        con.Close();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (con != null)
                    con.Close();

                throw sqlEx;
            }
            catch (Exception ex)
            {
                if (con != null)
                    con.Close();

                throw ex;
            }
            return result;
        }
    }
}
