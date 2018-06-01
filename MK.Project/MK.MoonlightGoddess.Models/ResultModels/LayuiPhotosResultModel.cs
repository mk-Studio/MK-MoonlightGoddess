using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.ResultModels
{

    [Serializable]
    public class LayuiPhotosResultModel
    {
        //相册标题
        public string title { get; set; }
        //相册id
        public int id { get; set; }
        //初始显示的图片序号，默认0
        public int start { get; set; }
        //相册包含的图片，数组格式
        public List<data> data { get; set; }
        
        public static Object CreateResult(string title, int id, int start, List<data> data)
        {
            return new LayuiPhotosResultModel() {
                title = title,
                id = id,
                start = start,
                data = data,
            };
        }
    }

    /// <summary>
    /// 相册包含的图片，数组格式
    /// </summary>
    [Serializable]
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
