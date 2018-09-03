using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.EntityModels
{
    public class MK_Info_ApprovedTask:BaseModel
    {
        public string ApprovedTypeID { get; set; }
        public string ApproveorID { get; set; }
        public string ApproveorName { get; set; }
        public string CCName { get; set; }
        public string ApprovedGroupName { get; set; }
        public string ApprovedTypeName { get; set; }
        public string ApprovedGroupID { get; set; }
        public string TitleValue { get; set; }
        public string DescValue { get; set; }
        public string ApproveStatus { get; set; }
        public string ApprovedResultDesc { get; set; }
        
    }
}
