using System;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using Smartass.Models;
using Smartass.Models.Uploading;
using System.Web.Http;
using System.Net;
using System.IO;
using System.Globalization;

namespace Smartass.Steps.Uploading
{
    internal class ReceiveUploadedFileStep : StepBase
    {
        protected override async Task ProcessAsync(Plan plan)
        {
            var request = (plan.Request as UploadingRequest).Request;
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
            }

            var workingPath = Path.GetTempPath();
            var streamProvider = new MultipartFormDataStreamProvider(workingPath);            
            await request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith(t =>
            {
                if (t.IsFaulted || t.IsCanceled)
                {
                    log4net.LogManager.GetLogger("smartass").Fatal("exception when reading multipart", t.Exception);
                    throw t.Exception;
                }
            });

            var uploadedFile = streamProvider.FileData.First();
            log4net.LogManager.GetLogger("smartass").InfoFormat(CultureInfo.InvariantCulture, "uploaded file: {0}", uploadedFile.LocalFileName);
            var destination = Path.Combine(workingPath, uploadedFile.Headers.ContentDisposition.FileName.Replace("\"", ""));
            if (File.Exists(destination))
            {
                File.Delete(destination);
            }

            File.Move(uploadedFile.LocalFileName, destination);
            
            log4net.LogManager.GetLogger("smartass").InfoFormat(CultureInfo.InvariantCulture, "processing file {0}", destination);

            var docket = new ReceiveUploadedFileDocket(new FileInfo(destination));
            plan.Dockets.Add(docket);
        }
    }
}