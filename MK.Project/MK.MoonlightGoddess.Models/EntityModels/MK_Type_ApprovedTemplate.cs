using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.EntityModels
{
    public class MK_Type_ApprovedTemplate : MK_Type_ApprovedType
    {
        public string ApprovedTemplateID { get; set; }

        public string ApprovedTemplateName { get; set; }
        
        public string ApprovedTypeID { get; set; }

        public string TitleLabel { get; set; }

        public string DataLabeName { get; set; }

        public string DataLabelID { get; set; }

        public string DataParameter { get; set; }

        public string DescLabel { get; set; }

        public int ImageMinNum { get; set; }

        public int ImageMaxNum { get; set; }
    }
}
