using MK.MoonlightGoddess.Core;
using MK.MoonlightGoddess.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MK.MoonlightGoddess.Web.Controllers
{
    public class UploadController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Upload()
        {
            int code = -1; string msg = ""; string src = "";
            HttpFileCollection _filelist = HttpContext.Current.Request.Files;
            if (_filelist != null && _filelist.Count > 0)
            {
                for (int i = 0; i < _filelist.Count; i++)
                {
                    HttpPostedFile file = _filelist[i];
                    string _pathImgFile = DateTime.Now.ToString("yyyy-MM");
                    string _filename = DateTime.Now.ToString("yyyyMMddHHmmss")+ file.FileName;
                    string _savePath = System.Web.Hosting.HostingEnvironment.MapPath("~/")+"Files\\";
                    string _filePath = _savePath + _pathImgFile + @"\";
                    DirectoryInfo di = new DirectoryInfo(_filePath);
                    if (!di.Exists) { di.Create(); }
                    try
                    {
                        file.SaveAs(_filePath + _filename);
                        code = 0;
                        msg = "success";
                        src = string.Format(@"/Files/{0}/{1}",_pathImgFile,_filename);
                    }
                    catch (Exception ex)
                    {
                        return Json(LayuiUploadResultModel.CreateResult(code,ex.Message , new { src = src }));
                    }
                }
            }
            return Json(LayuiUploadResultModel.CreateResult(code, msg, new { src = src }));
        }

    }
}
