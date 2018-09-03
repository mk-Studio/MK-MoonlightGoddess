using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.EntityModels
{
    public class MK_Info_ApprovedTaskCC : BaseModel
    {
        public string ApprovedTaskID { get; set; }
        public string CCID { get; set; }
        public string CCName { get; set; }
    }
}
