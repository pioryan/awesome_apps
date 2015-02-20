using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using Smartass.Models;
using Smartass.WolframAlpha.Models.Query;
using Smartass.WolframAlpha.Steps.Query;

namespace Smartass.Web.Controllers
{
    public class FactoidController : ApiController
    {
        // GET api/factoid?input=input
        public async Task<HttpResponseMessage> Get(string input)
        {
            //string returnHtml = "<html><body>image could not be identified. sorry. :(</body></html>";
            string returnHtml;// = "<article><section>image could not be identified. sorry. :(</section></article>";
            if (!string.IsNullOrWhiteSpace(input))
            {
                var plan = new Plan(new WolframAlphaQueryRequest(input));
                await QueryChain.Create().RunAsync(plan);
                returnHtml = JsonConvert.SerializeObject(plan.Result as WolframAlphaQueryResult);
            }
            else
            {
                returnHtml = JsonConvert.SerializeObject(new[]
                {
                    new GlassCardItem()
                    {
                        Text = "image could not be identified. sorry. :("
                    }
                });
            }

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(returnHtml);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
    }
}