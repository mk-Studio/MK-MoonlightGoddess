using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.EntityModels
{
    public class MK_Type_DataDictionary : MK_Type_DictionaryLabel
    {
        public string DataLabelID { get; set; }

        public string DataTypeName { get; set; }

        public string DataDesc { get; set; }

        public string DataPlaceholder { get; set; }
    }
}
