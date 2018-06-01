using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.ResultModels
{
    [Serializable]
    public class SelectOptionsResultModel
    {
        /// <summary>
        /// 下拉框Value属性
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 下拉框Text属性
        /// </summary>
        public string Text { get; set; }
    }
}
