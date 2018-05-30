using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.ResultModels
{
    public class LayuiPhotosResultModel
    {
        //相册标题
        public string title { get; set; }
        //相册id
        public int id { get; set; }
        //初始显示的图片序号，默认0
        public int start { get; set; }
        //相册包含的图片，数组格式
        public data data { get; set; }
    }

    /// <summary>
    /// 相册包含的图片，数组格式
    /// </summary>
    public class data
    {
        //图片名
        public string alt { get; set; }
        //图片id
        public int pid { get; set; }
        //原图地址
        public string src { get; set; }
        //缩略图地址
        public string thumb { get; set; }
    }
}
