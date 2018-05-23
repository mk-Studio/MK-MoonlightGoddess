using MK.MoonlightGoddess.Data;
using MK.MoonlightGoddess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Service
{
    public static class ServiceContent<TModel> where TModel : BaseModel
    {
        public static LayuiTableResultModel Select(TModel model, string xmlName, string sqlName)
        {
            var _Data = DBContent<TModel>.GetDataTable(model, xmlName, sqlName);
            if (_Data != null ? true : false)
            {
                layuiTableResult = new LayuiTableResultModel(){
                    code = _Data != null ? 0 : -1,
                    count = _Data.Rows.Count,
                    data = _Data,
                    msg = "success"
                };
            }
            return layuiTableResult;
        }

        public static AjaxResultModel AjaxSIDU(TModel model, string xmlName, string sqlName)
        {
            var _Data = DBContent<TModel>.GetDataTable(model, xmlName, sqlName);
            if (_Data != null ? false : true)
            {
                ajaxResult = new AjaxResultModel()
                {
                    IsError = true,
                    Code = 0,
                    Msg = "执行成功",
                    Data = _Data
                };
            }
            return ajaxResult;
        }

        private static AjaxResultModel ajaxResult = new AjaxResultModel(){
            IsError = false,
            Code = -1,
            Msg = "获取失败",
            Data = null
        };

        private static LayuiTableResultModel layuiTableResult = new LayuiTableResultModel() {
            code = -1,
            count = 0,
            data = null,
            msg = "N"
        };
        
        public void Dispose()
        {
            ajaxResult = null;
            layuiTableResult = null;
        }
    }
}
