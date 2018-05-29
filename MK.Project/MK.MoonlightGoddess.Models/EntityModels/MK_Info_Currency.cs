using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.EntityModels
{
    public class MK_Info_Currency : BaseModel
    {
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public string Remark { get; set; }
    }
}
