using MK.MoonlightGoddess.Core;
using MK.MoonlightGoddess.Data;
using MK.MoonlightGoddess.Models;
using MK.MoonlightGoddess.Models.EntityModels;
using MK.MoonlightGoddess.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Service
{
    public static class ServiceContent<TModel> where TModel : class
    {
        /// <summary>
        /// 返回一个 <see cref="DataTable"/> 类型
        /// </summary>
        /// <param name="model"></param>
        /// <param name="xmlName"></param>
        /// <param name="sqlName"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public static DataTable SelectData(TModel model, string xmlName, string sqlName, bool allowNull = false, CommandType cmdType = CommandType.Text)
        {
            var _Data = DBContent<TModel>.GetDataTable(model, xmlName, sqlName, allowNull, cmdType);
            return _Data;
        }

        /// <summary>
        ///  统一加载下拉框的函数，XML => MK_Info_SelectOptions.xml;
        /// 根据SqlName获取下拉框要绑定的数据，返回类型：List[<see cref="SelectOptionsResultModel"/>]。
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sqlName"></param>
        /// <returns></returns>
        public static List<SelectOptionsResultModel> GetSelectOptionsBySqlName(TModel model, string sqlName)
        {
            var _Data = DBContent<TModel>.GetDataTable(model, "MK_Info_SelectOptions", sqlName);
            var resultList = ConvertHelper.TableToList<SelectOptionsResultModel>(_Data);
            return resultList;
        }

        /// <summary>
        /// 获取绑定到Layui Table的数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="xmlName"></param>
        /// <param name="sqlName"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public static Object Select(TModel model, string xmlName, string sqlName, bool allowNull = false, CommandType cmdType = CommandType.Text)
        {
            var _Data = DBContent<TModel>.GetDataTable(model, xmlName, sqlName, allowNull, cmdType);
            if (_Data != null ? true : false)
            {
                layuiTableResult = new LayuiTableResultModel(){
                    code = _Data != null ? 0 : -1,
                    count = _Data.Rows.Count,
                    data = ConvertHelper.TableToList<TModel>(_Data),
                    msg = "success"                     
                };
            }
            return layuiTableResult;
        }

        /// <summary>
        /// 获取绑定到Layui Table的数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="xmlName"></param>
        /// <param name="sqlName"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public static Object Query(TModel model, string xmlName, string sqlName, bool allowNull = false, CommandType cmdType = CommandType.Text)
        {
            var _Data = DBContent<dynamic>.GetDataSet(model, xmlName, sqlName, allowNull, cmdType);
            if (_Data != null ? true : false)
            {
                layuiTableResult = new LayuiTableResultModel()
                {
                    code = _Data != null ? 0 : -1,
                    count = Convert.ToInt32(_Data.Tables[1].Rows[0]["rows"]),
                    data = ConvertHelper.TableToList<TModel>(_Data.Tables[0]),
                    msg = "success"
                };
            }
            return layuiTableResult;
        }

        /// <summary>
        /// 获取绑定到Layui Table的数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="xmlName"></param>
        /// <param name="sqlName"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public static Object Query(TModel model,  string xmlName, string sqlName,string spliceSql, bool allowNull = false)
        {
            var _Data = DBContent<dynamic>.GetDataSet(model, xmlName, sqlName, spliceSql, allowNull);
            if (_Data != null ? true : false)
            {
                layuiTableResult = new LayuiTableResultModel()
                {
                    code = _Data != null ? 0 : -1,
                    count = Convert.ToInt32(_Data.Tables[1].Rows[0]["rows"]),
                    data = ConvertHelper.TableToList<TModel>(_Data.Tables[0]),
                    msg = "success"
                };
            }
            return layuiTableResult;
        }

        /// <summary>
        /// 获取一个指定返回的类型 <see cref="TModel"/>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="xmlName"></param>
        /// <param name="sqlName"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public static TModel SelectSingleModel(TModel model, string xmlName, string sqlName, bool allowNull = false, CommandType cmdType = CommandType.Text)
        {
            return DBContent<TModel>.GetSingleRowModel(model, xmlName, sqlName, allowNull, cmdType);
        }

        /// <summary>
        /// 获取一个指定返回的类型。
        /// 返回结构为统一Ajax请求的对象结构 <see cref="AjaxResultModel"/>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="xmlName"></param>
        /// <param name="sqlName"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public static Object AjaxSingleModel(TModel model, string xmlName, string sqlName, bool allowNull = false, CommandType cmdType = CommandType.Text)
        {
            var _Data = DBContent<TModel>.GetSingleRowModel(model, xmlName, sqlName, allowNull, cmdType);
            if (_Data != null ? true : false)
            {
                ajaxResult = new AjaxResultModel()
                {
                    IsError = false,
                    Code = 0,
                    Msg = "success",
                    Data = _Data
                };
            }
            return ajaxResult;
        }

        /// <summary>
        /// 获取一个单行单列值
        /// </summary>
        /// <param name="model"></param>
        /// <param name="xmlName"></param>
        /// <param name="sqlName"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public static string SelectSingle(TModel model, string xmlName, string sqlName, bool allowNull = false, CommandType cmdType = CommandType.Text)
        {
            var _Data = DBContent<TModel>.GetSingleValue(model, xmlName, sqlName, allowNull, cmdType);
            return _Data;
        }

        /// <summary>
        /// 获取一个单行单列值。
        /// 返回结构为统一Ajax请求的对象结构 <see cref="AjaxResultModel"/>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="xmlName"></param>
        /// <param name="sqlName"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public static Object AjaxSingle(TModel model, string xmlName, string sqlName, bool allowNull = false, CommandType cmdType = CommandType.Text)
        {
            var _Data = DBContent<TModel>.GetSingleValue(model, xmlName, sqlName, allowNull, cmdType);
            if (_Data != null ? true : false)
            {
                ajaxResult = new AjaxResultModel()
                {
                    IsError = false,
                    Code = 0,
                    Msg = "success",
                    Data = _Data
                };
            }
            return ajaxResult;
        }

        /// <summary>
        /// 获取执行增、删、改 后的结果
        /// </summary>
        /// <param name="model"></param>
        /// <param name="xmlName"></param>
        /// <param name="sqlName"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public static bool SelectSIDU(TModel model, string xmlName, string sqlName, bool allowNull = false, CommandType cmdType = CommandType.Text)
        {
            var _Data = DBContent<TModel>.GetExecResult(model, xmlName, sqlName, allowNull, cmdType);
            return _Data;
        }

        /// <summary>
        /// 获取执行增、删、改 后的结果
        /// 返回结构为统一Ajax请求的对象结构 <see cref="AjaxResultModel"/>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="xmlName"></param>
        /// <param name="sqlName"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public static Object AjaxSIDU(TModel model, string xmlName, string sqlName, bool allowNull = false, CommandType cmdType = CommandType.Text)
        {
            var _Data = DBContent<TModel>.GetExecResult(model, xmlName, sqlName, allowNull, cmdType);
            if (_Data)
            {
                ajaxResult = new AjaxResultModel()
                {
                    IsError = false,
                    Code = 0,
                    Msg = "success",
                    Data = _Data
                };
            }
            return ajaxResult;
        }

        public static bool DataTableToSQLServer(DataTable dt, string dbMappingTableName)
        {
            bool result = DBContent<dynamic>.DataTableToSQLServer(dt, dbMappingTableName);
            return result;
        }

        /// <summary>
        /// 释放请求资源
        /// </summary>
        public static void Disposable()
        {
            ajaxResult = null;
            layuiTableResult = null;
        }

        /// <summary>
        /// 统一的Ajax请求的返回类型
        /// </summary>
        private static AjaxResultModel ajaxResult = new AjaxResultModel(){
            IsError = true,
            Code = -1,
            Msg = "fail",
            Data = null
        };

        /// <summary>
        /// 统一的Layui Table数据加载的返回类型
        /// </summary>
        private static LayuiTableResultModel layuiTableResult = new LayuiTableResultModel() {
            code = -1,
            count = 0,
            data = null,
            msg = "fail"
        };
    }
}
