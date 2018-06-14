using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.EntityModels
{
    public class MK_Info_Supplier:BaseModel
    {
        public string SupplierName { get; set; }
        public string LianXiRen { get; set; }
        public string LianXiFangShi { get; set; }
        public string Address { get; set; }
        public string WuLiaoDetail { get; set; }
    }

    public class SupelierWuLiaoDetail
    {
        public string val { get; set; }
        public string name { get; set; }
    }

    public class FormSelectes : SupelierWuLiaoDetail
    {

    }
}
