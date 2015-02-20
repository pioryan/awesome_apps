using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Smartass.Models;
using Smartass.Models.Uploading;
using Smartass.Steps.Uploading;
using Smartass.WolframAlpha.Models.Query;
using Smartass.WolframAlpha.Steps.Query;
using System.Linq;
using System.Net;
using System;
using System.Web;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Smartass.Web.Controllers
{
    public class UploadController : ApiController
    {
        // POST api/upload
        //public async Task<JsonResult<IPlanResult>> Post()
        public async Task<HttpResponseMessage> Post()
        {
            var plan = new Plan(new UploadingRequest(this.Request));
            await UploadingChain.Create().RunAsync(plan);
            //return this.Json(plan.Result);
            var result = plan.Result as UploadingResult;
            string bestGuess = null;
            if (result.BestGuesses.Any())
            {
                bestGuess = result.BestGuesses.OrderByDescending(r => r.Key).First().Value;
            }

            log4net.LogManager.GetLogger("smartass").InfoFormat(
                "evaluation: {0}",                
                JsonConvert.SerializeObject(result));            

            //var wolframInput = new Dictionary<string, object>();
            //wolframInput.Add("input", bestGuess);            
            //var response = Request.CreateResponse(HttpStatusCode.Moved);            
            //var builder = new UriBuilder();
            //builder.Host = Request.RequestUri.Host;            
            //builder.Port = Request.RequestUri.Port;
            //builder.Path = "api/factoid";
            //var query = HttpUtility.ParseQueryString(builder.Query);            
            //query["input"] = bestGuess;
            //builder.Query = query.ToString();
            //response.Headers.Location = new Uri(builder.ToString());
            //return response;

            string returnHtml;
            if (!string.IsNullOrWhiteSpace(bestGuess))
            {
                var factoidPlan = new Plan(new WolframAlphaQueryRequest(bestGuess));
                await QueryChain.Create().RunAsync(factoidPlan);
                var cardItems = (factoidPlan.Result as WolframAlphaQueryResult).CardItems;
                result.BestGuesses.OrderByDescending(r => r.Key)
                        .Take(3)
                        .OrderBy(r=>r.Key)
                        .Select((k) => string.Format("{0:N3}: {1}", k.Key, k.Value))
                        .ToList()
                        .ForEach(c =>
                        {
                            cardItems.Insert(0, new GlassCardItem()
                            {
                                Text = c
                            });
                        });
                returnHtml = JsonConvert.SerializeObject(cardItems);
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