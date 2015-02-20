using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Smartass.Models;
using Smartass.Models.Uploading;
using Smartass.Models.Uploading.JsonClarifai;

namespace Smartass.Steps.Uploading
{
    internal class ClarifaiImageKeywordStep : StepBase
    {
        protected override async Task ProcessAsync(Plan plan)
        {
            var fileUrl = plan.Dockets.OfType<ExposeUploadedFileDocket>().First().FileUrl;
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var timestamp = (long)DateTime.UtcNow.Subtract(origin).TotalMilliseconds;

            var requestContent = new MultipartFormDataContent("----WebKitFormBoundaryvc8JBx5niPZI9Np0");
            var contentTimestamp = new ByteArrayContent(new StringContent(timestamp.ToString()).ReadAsByteArrayAsync().Result);//((int)timestamp).ToString());
            contentTimestamp.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "\"timestamp\""
            };

            requestContent.Add(contentTimestamp);
            var contentImageurl = new ByteArrayContent(new StringContent(fileUrl).ReadAsByteArrayAsync().Result);
            contentImageurl.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "\"image_url\""
            };
            requestContent.Add(contentImageurl);
            {
                var content = new ByteArrayContent(new StringContent("AyDKbScZN7XWvBxmQkpqLmXkf7tSabuI").ReadAsByteArrayAsync().Result);
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "\"csrfmiddlewaretoken\""
                };
                requestContent.Add(content);
            }
            {
                var content = new ByteArrayContent(new StringContent("true").ReadAsByteArrayAsync().Result);
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "\"nearest\""
                };
                requestContent.Add(content);
            }
            {
                var content = new ByteArrayContent(new StringContent("true").ReadAsByteArrayAsync().Result);
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "\"fd\""
                };
                requestContent.Add(content);
            }
            {
                var content = new ByteArrayContent(new StringContent("default").ReadAsByteArrayAsync().Result);
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "\"model\""
                };
                requestContent.Add(content);
            }
            using (var client = new HttpClient(plan.HttpClientHandler, false))
            {
                var builder = new UriBuilder("http://clarifai.com/demo/upload");
                var query = HttpUtility.ParseQueryString(builder.Query);
                builder.Port = -1;
                builder.Query = query.ToString();
                var url = builder.ToString();
                var request = new HttpRequestMessage(HttpMethod.Post, builder.ToString());
                request.Headers.Referrer = new Uri("http://clarifai.com/");
                requestContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = fileUrl
                };
                request.Headers.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.99 Safari/537.36");                                
                request.Content = requestContent;

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var contents = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<ClarifaiImageKeywords>(contents);
                plan.Dockets.Add(new ClarifaiImageKeywordDocket(jsonResponse));
            }
        }
    }
}
