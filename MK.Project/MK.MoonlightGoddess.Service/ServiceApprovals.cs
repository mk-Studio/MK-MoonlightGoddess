using MK.MoonlightGoddess.Core;
using MK.MoonlightGoddess.Models;
using MK.MoonlightGoddess.Models.EntityModels;
using MK.MoonlightGoddess.Models.SerializableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Service
{
    public class ServiceApprovals: IApprovalsSerializableModelResult
    {
        private readonly string _XmlName;
        private readonly string _CmdName; 
        public ServiceApprovals(string xmlName,string cmdName)
        {
            _XmlName = xmlName;
            _CmdName = cmdName;
        }
        public object ExecuteResult(ApprovalsSerializableModel model,MK_Info_User user)
        {
            MK_Info_ApprovedTask apdTask = null;
            bool task = false;
            bool detailSaveStatus = false;
            bool ccSaveStatus = false;
            bool imgSaveStatus = false;
            var t1 = Task.Factory.StartNew(() => {
                apdTask = new MK_Info_ApprovedTask()
                {
                    ID = model.ApprovedTaskID,
                    ApprovedTypeID = model.ApprovalsTypeID,
                    ApproveStatus = "N",
                    ApproveorID = model.ApproveorID,
                    ApproveorName = model.ApproveorName,
                    TitleValue = model.TitleValue,
                    DescValue = model.DescValue,
                    ShowMark = "Y",
                    CreateUser = user.UserName,
                    CreateDate = model.CreateDateTime
                };
                foreach (MK_Info_ApprovedTaskDetail detail_item in model.ApprovedTaskDetail)
                {
                    detail_item.ID = Guid.NewGuid().ToString();
                    detail_item.ApprovedTaskID = model.ApprovedTaskID;
                    detail_item.ShowMark = "Y";
                    detail_item.CreateUser = user.UserName;
                    detail_item.CreateDate = model.CreateDateTime;
                }
                System.Data.DataTable detaiTable = ConvertHelper.ListToTable(model.ApprovedTaskDetail, true, true);
                task = ServiceContent<MK_Info_ApprovedTask>.SelectSIDU(apdTask, _XmlName, _CmdName);
                detailSaveStatus = ServiceContent<dynamic>.DataTableToSQLServer(detaiTable, "MK_Info_ApprovedTaskDetail");
            });
            var t2 = Task.Factory.StartNew(() => {
                foreach (MK_Info_ApprovedTaskCC cc_item in model.ApprovedTaskCC)
                {
                    cc_item.ID = Guid.NewGuid().ToString();
                    cc_item.ApprovedTaskID = model.ApprovedTaskID;
                    cc_item.ShowMark = "Y";
                    cc_item.CreateUser = user.UserName;
                    cc_item.CreateDate = model.CreateDateTime;
                }
                System.Data.DataTable ccTable = ConvertHelper.ListToTable(model.ApprovedTaskCC, true, true);
                ccSaveStatus = ServiceContent<dynamic>.DataTableToSQLServer(ccTable, "MK_Info_ApprovedTaskCC");
            });
            var t3 = Task.Factory.StartNew(() => {
                if (model.ApprovedTaskImages != null)
                {
                    foreach (MK_Info_ApprovedTaskImages img_item in model.ApprovedTaskImages)
                    {
                        img_item.ID = Guid.NewGuid().ToString();
                        img_item.ApprovedTaskID = model.ApprovedTaskID;
                        img_item.ShowMark = "Y";
                        img_item.CreateUser = user.UserName;
                        img_item.CreateDate = model.CreateDateTime;
                    }
                    System.Data.DataTable imgsTable = ConvertHelper.ListToTable(model.ApprovedTaskImages, true, true);
                    imgSaveStatus = ServiceContent<dynamic>.DataTableToSQLServer(imgsTable, "MK_Info_ApprovedTaskImages");
                }
                else
                {
                    imgSaveStatus = true;
                }
            });
            Task.WaitAll(t1, t2, t3);
            bool iserror;
            string message ;
            int code ;
            if (task && detailSaveStatus && ccSaveStatus && imgSaveStatus) {
                iserror = false;
                message = "success";
                code = 0;
            }
            else { 
                iserror = true;
                message = "error";
                code = -11;
            }
            var result = new
            {
                task,
                detailSaveStatus,
                ccSaveStatus,
                imgSaveStatus
            };
            return AjaxResultModel.CreateMessage(iserror, message, code, result);
        }
    }
}
