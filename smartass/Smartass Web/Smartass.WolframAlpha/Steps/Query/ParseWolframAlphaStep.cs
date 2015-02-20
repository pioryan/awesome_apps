using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Smartass.Models;
using Smartass.Steps;
using Smartass.WolframAlpha.Models.Query;

namespace Smartass.WolframAlpha.Steps.Query
{
    internal class ParseWolframAlphaStep : StepBase
    {
        protected  async override Task ProcessAsync(Plan plan)
        {
            var docket = plan.Dockets.OfType<RunWolframAlphaQueryDocket>().FirstOrDefault();
            var request = plan.Request as WolframAlphaQueryRequest;
            if (docket != null)
            {
                var cardItems = new List<GlassCardItem>();
                var wolframResult = docket.QueryResult;
                //var result = new StringBuilder();
                //result.Append("<html><body>");
                if (wolframResult.Success)
                {
                    var pods = wolframResult.Pods.Where(p => !p.Error).ToArray();
                    foreach (var pod in pods)
                    {
                        //result.Append("<article><section>");
                        foreach (var subpod in pod.Subpods)
                        {
                            if (subpod.Plaintext != null)
                            {
                                cardItems.Add(new GlassCardItem()
                                {
                                    Text = subpod.Plaintext
                                });
                            }
                            else
                            {
                                var source = subpod.Image.DocumentElements.FirstOrDefault(d => d.Name == "src");
                                cardItems.Add(new GlassCardItem()
                                {
                                    Text = pod.Title,
                                    ImageUrl = source != null ? source.InnerXml : null
                                });
                                //result.Append(subpod.Image.Xml);
                                //result.AppendLine("<br>");
                            }
                        }

                        //result.AppendFormat("<p>{0}</p>", pod.Title);
                        //result.AppendLine("</section></article>");
                    }
                }
                else
                {
                    cardItems.Add(new GlassCardItem()
                    {
                        Text = string.Format(CultureInfo.CurrentCulture, "no facts found for: {0}", request.Input)
                    });
                    ////result.AppendFormat("no facts found for: <strong>{0}</strong><br>", request.Input);
                    //result.Append("<article><section>");
                    //result.AppendFormat("<p>no facts found for: {0}</p>", request.Input);
                    //result.AppendLine("</section></article>");
                    ////if (wolframResult.DidYouMeans != null && wolframResult.DidYouMeans.Any())
                    ////{
                    ////    result.AppendLine("<ul>");
                    ////    foreach (var alternate in wolframResult.DidYouMeans)
                    ////    {
                    ////        result.AppendFormat(
                    ////            "<li><a href='factoid?input={0}'>{1}</a></li>",
                    ////            HttpUtility.UrlEncode(alternate.Text),
                    ////            alternate.Text);
                    ////    }

                    ////    result.AppendLine("</ul>");
                    ////}
                }

                //result.Append("</body></html>");
                //var result = await JsonConvert.SerializeObjectAsync(cardItems);

                plan.Result = new WolframAlphaQueryResult(cardItems);
            }

            await Task.Delay(10);
        }
    }
}
