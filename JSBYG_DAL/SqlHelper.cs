using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace JSBYG_DAL
{
    public class SqlHelper
    {
        private static readonly string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                using (SqlCommand com = con.CreateCommand())
                {
                    com.CommandText = sql;
                    com.Parameters.AddRange(parameters);
                    SqlDataAdapter sda = new SqlDataAdapter(com);
                    using (DataSet dst = new DataSet())
                    {
                        sda.Fill(dst);
                        return dst.Tables[0];
                    }
                }
            }
        }

        /// <summary>
        /// 执行非查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        public static int ExecuteNonquery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                using (SqlCommand com = con.CreateCommand())
                {
                    com.CommandText = sql;
                    com.Parameters.AddRange(parameters);
                    //foreach (SqlParameter p in parameters)
                    //{
                    //    if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                    //    {
                    //        p.Value = DBNull.Value;
                    //    }
                    //    com.Parameters.Add(p);
                    //}
                    return com.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 返回结果集中的第一行数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                using (SqlCommand com = con.CreateCommand())
                {
                    com.CommandText = sql;
                    com.Parameters.AddRange(parameters);
                    return com.ExecuteScalar();
                }
            }
        }
    }
}