using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using Smartass.Models;
using Smartass.Steps;
using Smartass.WolframAlpha.Models.Query;
using Smartass.WolframAlpha.Models.Xml;

namespace Smartass.WolframAlpha.Steps.Query
{
    internal class RunWolframAlphaQueryAsTextStep : StepBase
    {
        protected override async Task ProcessAsync(Plan plan)
        {
            var request = plan.Request as WolframAlphaQueryRequest;
            using (var client = new HttpClient(plan.HttpClientHandler, false))
            {
                var builder = new UriBuilder("http://api.wolframalpha.com/v2/query");
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["appid"] = "AY647U-T9WEGKWWQW";
                query["input"] = request.Input;
                query["format"] = "plaintext";

                builder.Query = query.ToString();
                string url = builder.ToString();

                var response = await client.GetAsync(url);
                var contentsStream = await response.Content.ReadAsStreamAsync();
                var serializer = new XmlSerializer(typeof(QueryResult));
                var docket = new RunWolframAlphaQueryDocket(serializer.Deserialize(contentsStream) as QueryResult);
                plan.Dockets.Add(docket);
            }
        }
    }
}