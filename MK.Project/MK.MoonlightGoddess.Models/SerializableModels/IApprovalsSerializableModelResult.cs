using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.SerializableModels
{
    public interface IApprovalsSerializableModelResult
    {
        object ExecuteResult(ApprovalsSerializableModel model,EntityModels.MK_Info_User currUserInfo);
    }
}
