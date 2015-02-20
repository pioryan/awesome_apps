using System;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using Smartass.Models;
using Smartass.Models.Uploading;

namespace Smartass.Steps.Uploading
{
    internal class GoogleImageSearchStep : StepBase
    {
        protected override async Task ProcessAsync(Plan plan)
        {
            using (var client = new HttpClient(plan.HttpClientHandler, false))
            {
                var fileUrl = plan.Dockets.OfType<ExposeUploadedFileDocket>().First().FileUrl;
                var builder = new UriBuilder("https://www.google.com/searchbyimage");
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["image_url"] = fileUrl;
                builder.Port = -1;
                builder.Query = query.ToString();
                string url = builder.ToString();

                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.99 Safari/537.36");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var docket = new GoogleImageSearchDocket(content);
                plan.Dockets.Add(docket);
            }
        }
    }
}