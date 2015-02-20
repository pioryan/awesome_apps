using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Smartass.Models;
using Smartass.Models.Uploading;

namespace Smartass.Steps.Uploading
{
    internal class ExposeUploadedFileStep : StepBase
    {
        protected override async Task ProcessAsync(Plan plan)
        {
            var fileInfo = plan.Dockets.OfType<ReceiveUploadedFileDocket>().First().FileInfo;
            var filename = Path.GetFileName(fileInfo.Name);
            var workingDirectory = HttpContext.Current.Server.MapPath("~/upload");
            var destination = Path.Combine(workingDirectory, filename);
            if (File.Exists(destination))
            {
                //System.Web.Hosting.HostingEnvironment.MapPath("");
                File.Delete(destination);
            }
            
            File.Move(fileInfo.FullName, destination);
            var fileUrl = string.Format("http://ys-mailroom.cloudapp.net:8888/upload/{0}", filename);
            var docket = new ExposeUploadedFileDocket(fileUrl);            
            plan.Dockets.Add(docket);

            await Task.Delay(10);

            //using (var requestContent = new MultipartFormDataContent())
            //{
            //    using (var fileContent = new StreamContent(fileInfo.OpenRead()))
            //    {                                       
                    
            //        fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            //        {
            //            Name = "\"file\"",
            //            FileName = "\"" + filename + "\""
            //        };

            //        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(MimeMapping.GetMimeMapping(fileInfo.Name));
            //        requestContent.Add(fileContent);
            //        requestContent.Headers.Add("upload-method", "misc");
            //        requestContent.Headers.Add("dump-directory", "misc");

            //        using (var handler = new HttpClientHandler())
            //        {
            //            handler.Credentials = new NetworkCredential("ys-mailroom", "Adcorp!234");
            //            using (var client = new HttpClient(handler, true))
            //            {
            //                var response = await client.PostAsync("http://ys-mailroom.cloudapp.net/breeze/Upload/UploadFile", requestContent);
            //                response.EnsureSuccessStatusCode();
            //                var now = DateTime.UtcNow;
            //                var fileUrl = string.Format("http://ys-mailroom.cloudapp.net/upload_dump/misc/{0}-{1:d2}-{2:d2}/{3}", now.Year, now.Month, now.Day, filename);
            //                var docket = new ExposeUploadedFileDocket(fileUrl);
            //                plan.Dockets.Add(docket);
            //            }
            //        }
            //    }
            //}
        }
    }
}