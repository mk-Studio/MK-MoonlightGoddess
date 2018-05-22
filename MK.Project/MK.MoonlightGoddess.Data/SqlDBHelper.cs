using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Data
{
    public class SqlDBHelper
    {
        //链接数据库
        public static string connectionString = "server=.;database=MK_MoonlightGoddess;uid=sa;pwd123456;";

        /// <summary>
        /// 根据sql查询表返回DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetDataSetBySql(string sql)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(sql,conn);
            DataSet ds = new DataSet();
            try
            {
                sdr.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 根据sql查询表返回DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetDataTableBySql(string sql)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            try
            {
                sdr.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 查询sql单行单列值(单个值)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static string GetSingleBySql(string sql)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand(sql,conn);
            string str = string.Empty;
            try
            {
                str = (string)comm.ExecuteScalar();
                return str;
            }
            catch
            {
                return str;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 执行(增、删、改)sql后返回的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int GetNumberBySql(string sql)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand(sql,conn);
            int number = 0;
            try
            {
                number = comm.ExecuteNonQuery();
                return number;
            }
            catch
            {
                return number;
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
