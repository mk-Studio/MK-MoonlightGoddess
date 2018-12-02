using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace MK.MoonlightGoddess.Web.Controllers
{
    public class DownloadController : ApiController
    {
        /// <summary>
        /// 从WebAPI下载文件
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetFileFromWebApi(string resourceUrlOrPath)
        {
            var browser = String.Empty;
            if (HttpContext.Current.Request.UserAgent != null)
            {
                browser = HttpContext.Current.Request.UserAgent.ToUpper();
            }
            Stream streamImage = WebRequest.Create(resourceUrlOrPath).GetResponse().GetResponseStream();
            //string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Files\2018-08\", "20180829225913login-bg-img.jpg");
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            //FileStream fileStream = File.OpenRead(filePath);
            httpResponseMessage.Content = new StreamContent(streamImage);
            httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName =
                    browser.Contains("FIREFOX")
                        ? Path.GetFileName($"{Guid.NewGuid().ToString()}.jpg")
                        : HttpUtility.UrlEncode(Path.GetFileName($"{Guid.NewGuid().ToString()}.jpg"))
                //FileName = HttpUtility.UrlEncode(Path.GetFileName(filePath))
            };
            return ResponseMessage(httpResponseMessage);
        }
    }
}