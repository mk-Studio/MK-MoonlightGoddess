using MK.MoonlightGoddess.Models;
using MK.MoonlightGoddess.Models.EntityModels;
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
        /// 获取 <see cref="DataSet"/>
        /// </summary>
        /// <param name="parms">实体参数</param>
        /// <param name="xmlName">xml的名称</param>
        /// <param name="sqlName">命令语句[sql语句、存储过程名称]</param>
        /// <param name="allowNull">是否允许有null值的参数，默认为 false，则会剔除掉null值的参数，反之亦然。</param>
        /// <param name="cmdType">执行方式[sql文本命令，存储过程] , 默认为 <see cref="CommandType.Text"/></param>
        /// <returns></returns>
        public static DataSet GetDataSet(TModel parms, string xmlName, string sqlName, bool allowNull = false, CommandType cmdType = CommandType.Text)
        {
            string cmdText = GetCommandText(xmlName,sqlName);
            SqlParameter[] sqlParameter = ToSqlParameterArray(parms, allowNull);
            return SqlDBHelper.GetDataSetBySql(cmdText, sqlParameter, cmdType);
        }

        /// <summary>
        /// 获取 <see cref="DataTable"/>
        /// </summary>
        /// <param name="parms">实体参数</param>
        /// <param name="xmlName">xml的名称</param>
        /// <param name="sqlName">命令语句 [sql语句、存储过程名称]</param>
        /// <param name="allowNull">是否允许有null值的参数，默认为 false，则会剔除掉null值的参数，反之亦然。</param>
        /// <param name="cmdType">执行方式 [sql文本命令，存储过程] , 默认为 <see cref="CommandType.Text"/></param>
        /// <returns></returns>
        public static DataTable GetDataTable(TModel parms, string xmlName, string sqlName, bool allowNull = false, CommandType cmdType = CommandType.Text)
        {
            string cmdText = GetCommandText(xmlName, sqlName);
            SqlParameter[] sqlParameter = ToSqlParameterArray(parms, allowNull);
            return SqlDBHelper.GetDataTableBySql(cmdText, sqlParameter, cmdType);
        }

        /// <summary>
        /// 获取 <see cref="DataSet"/>
        /// 摘要：用于动态拼接Sql，且只支持一个占位符，占位符必须为#SQL#
        /// </summary>
        /// <param name="parms">实体参数</param>
        /// <param name="xmlName">xml的名称</param>
        /// <param name="sqlName">xml sql name</param>
        /// <param name="spliceSql">要拼接的sql,拼接的替换字符格式必须为 #SQL# </param>
        /// <param name="allowNull">是否允许有null值的参数，默认为 false，则会剔除掉null值的参数，反之亦然。</param>
        /// <returns><see cref="DataSet"/></returns>
        public static DataSet GetDataSet(TModel parms, string xmlName, string sqlName, string spliceSql, bool allowNull = false)
        {
            string cmdText = GetCommandText(xmlName, sqlName).Replace("#SQL#",spliceSql);
            SqlParameter[] sqlParameter = ToSqlParameterArray(parms, allowNull);
            return SqlDBHelper.GetDataSetBySql(cmdText, sqlParameter);
        }

        /// <summary>
        /// 获取 <see cref="DataSet"/>
        /// 摘要：用于灵活动态拼接Sql
        /// </summary>
        /// <param name="parms">实体参数<</param>
        /// <param name="xmlName">xml的名称</param>
        /// <param name="sqlName">xml sql name</param>
        /// <param name="spliceSqlDictionary">灵活拼接sql字典，key：要替换XML里面sql的占位字符，value：替换占位字符的拼接sql</param>
        /// <param name="allowNull">是否允许有null值的参数，默认为 false，则会剔除掉null值的参数，反之亦然。</param>
        /// <returns></returns>
        public static DataSet GetDataSet(TModel parms, string xmlName, string sqlName, Dictionary<string,string> spliceSqlDictionary, bool allowNull = false)
        {
            StringBuilder @cmdText = new StringBuilder().Append(GetCommandText(xmlName, sqlName));
            foreach (KeyValuePair<string,string> item in spliceSqlDictionary)
            {
                @cmdText.Replace(item.Key, item.Value);
            }
            SqlParameter[] sqlParameter = ToSqlParameterArray(parms, allowNull);
            return SqlDBHelper.GetDataSetBySql(@cmdText.ToString(), sqlParameter);
        }

        /// <summary>
        /// 获取单行单列值 <see cref="string"/>
        /// </summary>
        /// <param name="parms">实体参数</param>
        /// <param name="xmlName">xml名称</param>
        /// <param name="sqlName">命令语句[sql语句、存储过程名称]</param>
        /// <param name="allowNull">是否允许有null值的参数，默认为 false，则会剔除掉null值的参数，反之亦然。</param>
        /// <param name="cmdType">执行方式 [sql文本命令，存储过程] , 默认为 <see cref="CommandType.Text"/></param>
        /// <returns></returns>
        public static string GetSingleValue(TModel parms, string xmlName, string sqlName, bool allowNull = false, CommandType cmdType = CommandType.Text)
        {
            string cmdText = GetCommandText(xmlName, sqlName);
            SqlParameter[] sqlParameter = ToSqlParameterArray(parms, allowNull);
            return SqlDBHelper.GetSingleBySql(cmdText, sqlParameter, cmdType);
        }
        
        /// <summary>
        /// 获取执行结果（add，delete，update）
        /// </summary>
        /// <param name="parms">实体参数</param>
        /// <param name="xmlName">xml名称</param>
        /// <param name="sqlName">命令语句 [sql语句、存储过程名称]</param>
        /// <param name="allowNull">是否允许有null值的参数，默认为 false，则会剔除掉null值的参数，反之亦然。</param>
        /// <param name="cmdType">执行方式 [sql文本命令，存储过程] , 默认为 <see cref="CommandType.Text"/></param>
        /// <returns></returns>
        public static bool GetExecResult(TModel parms, string xmlName, string sqlName, bool allowNull = false, CommandType cmdType = CommandType.Text)
        {
            string cmdText = GetCommandText(xmlName, sqlName);
            SqlParameter[] sqlParameter = ToSqlParameterArray(parms, allowNull);
            return SqlDBHelper.GetNumberBySql(cmdText, sqlParameter,cmdType) > 0 ? true : false;
        }

        /// 获取单行Model
        /// </summary>
        /// <param name="parms">实体参数</param>
        /// <param name="xmlName">xml名称</param>
        /// <param name="sqlName">命令语句 [sql语句、存储过程名称]</param>
        /// <param name="allowNull">是否允许有null值的参数，默认为 false，则会剔除掉null值的参数，反之亦然。</param>
        /// <param name="cmdType">执行方式 [sql文本命令，存储过程] , 默认为 <see cref="CommandType.Text"/></param>
        /// <returns></returns>
        public static TModel GetSingleRowModel(TModel parma, string xmlName, string sqlName, bool allowNull = false, CommandType cmdType = CommandType.Text)
        {
            string cmdText = GetCommandText(xmlName, sqlName);
            SqlParameter[] sqlParameter = ToSqlParameterArray(parma,allowNull);
            TModel data = SqlDBHelper.GetSingleRowModel<TModel>(cmdText, sqlParameter, cmdType);
            return data;
        }

        /// <summary>
        /// 将 <see cref="DataTable"/> 保存到数据库。
        /// 注意：<see cref="DataTable"/> 的格式必须与数据库表格式一致
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
        private static SqlParameter[] ToSqlParameterArray(TModel model,bool allowNull = false)
        {
            List<SqlParameter> parms = new List<SqlParameter>();
            PropertyInfo[] propertys = model.GetType().GetProperties();
            foreach (PropertyInfo pi in propertys)
            {
                object value = pi.GetValue(model);
                // 判断此属性是否有get
                if (!pi.CanRead) continue;
                if (allowNull)
                {
                    var _value = value == null ? DBNull.Value : (string.IsNullOrEmpty(value.ToString()) ? DBNull.Value : (value.ToString().ToUpper() == "ALL" ? DBNull.Value : value));
                    parms.Add(new SqlParameter("@" + pi.Name, _value));
                }
                else
                {
                    if (value != null) parms.Add(new SqlParameter("@" + pi.Name, value));
                }
            }
            return parms.ToArray();
        }

        /// <summary>
        /// 从XML根据name获取sql命令文本/存储过程名
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
