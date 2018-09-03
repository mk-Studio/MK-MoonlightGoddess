using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.ResultModels
{
    public class ApprovalsCollaResultModel
    {
        public static object GetApprovalsGroups(DataTable data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            List<ApprovedGroup> groups = new List<ApprovedGroup>();
            DataRowCollection rows = data.Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                var typesString = rows[i]["ApprovedTypes"].ToString();
                List<ApprovedType> typeList = SerializableTypes(typesString);
                if (typeList.Count == 0)
                    continue;
                ApprovedGroup group = new ApprovedGroup();
                group.ID = rows[i]["ID"].ToString();
                group.ApprovedGroupName = rows[i]["ApprovedGroupName"].ToString();
                group.ApprovedTypes = typeList;
                groups.Add(group);
            }
            return groups;
        }

        static List<ApprovedType> SerializableTypes(string ms)
        {
            if (string.IsNullOrEmpty(ms))
                return new List<ApprovedType>();
            string[] typeObj = ms.TrimEnd(';').Split(';');
            List<ApprovedType> types = new List<ApprovedType>();
            for (int i = 0; i < typeObj.Length; i++)
            {
                ApprovedType _type = new ApprovedType();
                var type = typeObj[i].ToString().Split(',');
                if (type.Length < 4)
                    throw new Exception("要序列化的审批类型格式不正确。");
                _type.ID = type[0];
                _type.ApprovedTypeName = type[1];
                _type.ClassIconfont = type[2];
                _type.BackgroundColor = type[3];
                _type.HasTemplate = type[4].IndexOf("#N#") >= 0 ? false : true ;
                types.Add(_type);
            }
            return types;
        }


    }
    public class ApprovedGroup
    {
        public string ID { get; set; }

        public string ApprovedGroupName { get; set; }

        public List<ApprovedType> ApprovedTypes { get; set; }
    }

    public class ApprovedType
    {
        public string ID { get; set; }

        public string ApprovedTypeName { get; set; }

        public string ClassIconfont { get; set; }

        public string BackgroundColor { get; set; }

        public bool HasTemplate { get; set; }

    }
}
