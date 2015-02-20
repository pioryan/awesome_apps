using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Smartass.Models;
using Smartass.Models.Uploading;
using Smartass.Models.Uploading.JsonAlchemy;

namespace Smartass.Steps.Uploading
{
    internal class AlchemyImageKeywordsStep : StepBase
    {
        protected override async Task ProcessAsync(Plan plan)
        {
            var fileUrl = plan.Dockets.OfType<ExposeUploadedFileDocket>().First().FileUrl;
            using (var client = new HttpClient(plan.HttpClientHandler, false))
            {
                var builder = new UriBuilder("http://access.alchemyapi.com/calls/url/URLGetRankedImageKeywords");
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["url"] = fileUrl;
                query["apikey"] = "ee1ec6898157fbbe13c19f98990241ab73231f9f";
                query["outputMode"] = "json";
                query["forceShowAll"] = "1";
                query["knowledgeGraph"] = "0";

                builder.Query = query.ToString();
                string url = builder.ToString();

                var response = await client.GetAsync(url);
                var contents = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<URLGetRankedImageKeywordsResponse>(contents);
                plan.Dockets.Add(new AlchemyImageKeywordsDocket(jsonResponse));
            }
        }
    }
}