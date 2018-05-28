using MK.MoonlightGoddess.Models;
using MK.MoonlightGoddess.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Data
{
    public static class DBContent<TModel> where TModel : class
    {
        /// <summary>
        /// 获取多表数据
        /// </summary>
        /// <param name="cmdText">命令语句[sql语句、存储过程名称]</param>
        /// <param name="parms">实体model</param>
        /// <param name="cmdType">执行方式</param>
        /// <returns></returns>
        public static DataSet GetDataSet(TModel parms, string xmlName, string sqlName, CommandType cmdType = CommandType.Text)
        {
            string cmdText = GetCommandText(xmlName,sqlName);
            SqlParameter[] sqlParameter = ToSqlParameterArray(parms);
            return SqlDBHelper.GetDataSetBySql(cmdText, sqlParameter, cmdType);
        }

        /// <summary>
        /// 获取单表数据
        /// </summary>
        /// <param name="cmdText">命令语句[sql语句、存储过程名称]</param>
        /// <param name="parms">实体model</param>
        /// <param name="cmdType">执行方式</param>
        /// <returns></returns>
        public static DataTable GetDataTable(TModel parms, string xmlName, string sqlName, CommandType cmdType = CommandType.Text)
        {
            string cmdText = GetCommandText(xmlName, sqlName);
            SqlParameter[] sqlParameter = ToSqlParameterArray(parms);
            return SqlDBHelper.GetDataTableBySql(cmdText, sqlParameter, cmdType);
        }

        /// <summary>
        /// 获取单行单列值
        /// </summary>
        /// <param name="cmdText">命令语句[sql语句、存储过程名称]</param>
        /// <param name="parms">实体model</param>
        /// <param name="cmdType">执行方式</param>
        /// <returns></returns>
        public static string GetSingleValue(TModel parms, string xmlName, string sqlName, CommandType cmdType = CommandType.Text)
        {
            string cmdText = GetCommandText(xmlName, sqlName);
            SqlParameter[] sqlParameter = ToSqlParameterArray(parms);
            return SqlDBHelper.GetSingleBySql(cmdText, sqlParameter, cmdType);
        }

        /// <summary>
        /// 获取执行结果（add，delete，update）
        /// </summary>
        /// <param name="cmdText">命令语句[sql语句、存储过程名称]</param>
        /// <param name="parms">实体model</param>
        /// <param name="cmdType">执行方式</param>
        /// <returns></returns>
        public static bool GetExecResult(TModel parms, string xmlName, string sqlName, CommandType cmdType = CommandType.Text)
        {
            string cmdText = GetCommandText(xmlName, sqlName);
            SqlParameter[] sqlParameter = ToSqlParameterArray(parms);
            return SqlDBHelper.GetNumberBySql(cmdText, sqlParameter,cmdType) > 0 ? true : false;
        }

        /// <summary>
        /// 获取单行Model
        /// </summary>
        /// <param name="cmdText">命令语句[sql语句、存储过程名称]</param>
        /// <param name="commandType">执行方式</param>
        /// <param name="parma">实体model</param>
        /// <returns></returns>
        public static TModel GetSingleRowModel(TModel parma, string xmlName, string sqlName, CommandType cmdType = CommandType.Text)
        {
            string cmdText = GetCommandText(xmlName, sqlName);
            SqlParameter[] sqlParameter = ToSqlParameterArray(parma);
            TModel data = SqlDBHelper.GetSingleRowModel<TModel>(cmdText, sqlParameter, cmdType);
            return data;
        }

        /// <summary>
        /// 将datatable保存到数据库
        /// </summary>
        /// <param name="dt">要保存的数据，注意:表格式必须一致</param>
        /// <param name="dbMappingTableName">对应的数据库表名</param>
        /// <returns></returns>
        public static bool DataTableToSQLServer(DataTable dt, string dbMappingTableName)
        {
            bool result = SqlDBHelper.DataTableToSQLServer(dt,dbMappingTableName);
            return result;
        }

        /// <summary>
        /// <remarks>
        /// <para>将实体类/匿名对象转换为SqlParameter列表</para>
        /// </remarks>
        /// </summary>
        /// <param name="obj">实体类/匿名对象</param>
        /// <returns>SqlParameter参数数组</returns>
        private static SqlParameter[] ToSqlParameterArray(TModel model)
        {
            List<SqlParameter> parms = new List<SqlParameter>();
            PropertyInfo[] propertys = model.GetType().GetProperties();
            foreach (PropertyInfo pi in propertys)
            {
                object value = pi.GetValue(model);
                // 判断此属性是否有get
                if (!pi.CanRead) continue;
                if (value != null) parms.Add(new SqlParameter("@" + pi.Name, value));
            }
            return parms.ToArray();
        }

        /// <summary>
        /// 获取sql
        /// </summary>
        /// <param name="xmlName"></param>
        /// <param name="sqlName"></param>
        /// <returns></returns>
        private static string GetCommandText(string xmlName, string sqlName)
        {
            SqlXmlContent sqlXmlContent = new SqlXmlContent(xmlName, sqlName);
            return sqlXmlContent.CommandText;
        }
    }
}
