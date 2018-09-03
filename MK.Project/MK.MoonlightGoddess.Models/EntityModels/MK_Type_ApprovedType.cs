using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.EntityModels
{
    public class MK_Type_ApprovedType : MK_Type_ApprovedGroup
    {
        public string ApprovedGroupID { get; set; }

        public string ApprovedTypeName { get; set; }

        public string ClassIconfont { get; set; }

        public string BackgroundColor { get; set; }

        public string HasTemplate { get; set; }
    }
}
