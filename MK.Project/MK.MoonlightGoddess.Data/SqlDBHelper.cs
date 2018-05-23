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
        public static string connectionString = "server=.;database=MK_MoonlightGoddess;uid=sa;pwd=123456;";

        /// <summary>
        /// 根据sql查询表返回DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetDataSetBySql(string sql, SqlParameter[] sqlParameter, CommandType cmdType = CommandType.Text)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlDataAdapter sdr = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            SetSqlCmd(conn, cmd, sql, sqlParameter, cmdType);
            sdr.SelectCommand = cmd;
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
        public static DataTable GetDataTableBySql(string sql, SqlParameter[] sqlParameter, CommandType cmdType = CommandType.Text)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlDataAdapter sdr = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            SetSqlCmd(conn,cmd,sql, sqlParameter, cmdType);
            sdr.SelectCommand = cmd;
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
        public static string GetSingleBySql(string sql, SqlParameter[] sqlParameter, CommandType cmdType = CommandType.Text)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            SetSqlCmd(conn, comm, sql, sqlParameter, cmdType);
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
        public static int GetNumberBySql(string sql, SqlParameter[] sqlParameter, CommandType cmdType = CommandType.Text)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand();
            SetSqlCmd(conn, comm, sql, sqlParameter, cmdType);
            int number = -1;
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

        /// <summary>
        /// 批量数据插入数据库
        /// </summary>
        /// <param name="dt">要插入的数据（字段列必须一致）</param>
        /// <param name="TabName">要插入的表名</param>
        public static bool DataTableToSQLServer(DataTable dt, string TabName)
        {
            bool result = false;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
                {
                    try
                    {
                        //将DataTable表名作为待导入库中的目标表名 
                        bulkCopy.DestinationTableName = TabName;
                        foreach (DataColumn item in dt.Columns)
                        {
                            bulkCopy.ColumnMappings.Add(item.ColumnName, item.ColumnName);
                        }
                        bulkCopy.WriteToServer(dt);
                        result = true;
                    }
                    catch
                    {
                        return result;
                    }
                }
            }
            return result;
        }

        private static void SetSqlCmd(SqlConnection con, SqlCommand currSqlCmd, string cmdText, SqlParameter[] cmdParms, CommandType cmdType = CommandType.Text)
        {
            currSqlCmd.Connection = con;
            currSqlCmd.CommandText = cmdText;
            currSqlCmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    currSqlCmd.Parameters.Add(parm);
            }
        }

    }
}
