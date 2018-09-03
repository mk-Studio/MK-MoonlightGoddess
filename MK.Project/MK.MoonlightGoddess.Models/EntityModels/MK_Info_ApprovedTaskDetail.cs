using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.EntityModels
{
    public class MK_Info_ApprovedTaskDetail : BaseModel
    {
        public string ApprovedTaskID { get; set; }
        public string DictionaryLabelID { get; set; }
        public string DataDictionaryID { get; set; }
        [Core.DataTableToDBColumns]
        public string DataTypeName { get; set; }
        public string DataParameter { get; set; }
    }
}
