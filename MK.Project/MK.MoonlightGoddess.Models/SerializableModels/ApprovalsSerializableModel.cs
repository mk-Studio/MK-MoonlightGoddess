using MK.MoonlightGoddess.Core;
using MK.MoonlightGoddess.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.SerializableModels
{
    public class ApprovalsSerializableModel 
    {
        public readonly string ApprovedTaskID = Guid.NewGuid().ToString();
        public readonly string CreateDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        public string ApprovalsTypeID { get; set; }
        public string ApproveorID { get; set; }
        public string ApproveorName { get; set; }
        public string TitleValue { get; set; }
        public string DescValue { get; set; }

        public List<MK_Info_ApprovedTaskDetail> ApprovedTaskDetail { get; set; }
        public List<MK_Info_ApprovedTaskCC> ApprovedTaskCC { get; set; }
        public List<MK_Info_ApprovedTaskImages> ApprovedTaskImages { get; set; }
        
    }
}
