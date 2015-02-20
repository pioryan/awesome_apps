using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Smartass.Models;
using Smartass.Models.Uploading;

namespace Smartass.Steps.Uploading
{
    internal class ParseGoogleImageSearchStep : StepBase
    {
        static Regex InvalidWordRegex = new Regex("^[^\\w]$*");
        protected override async Task ProcessAsync(Plan plan)
        {
            var imageSearchDocket = plan.Dockets.OfType<GoogleImageSearchDocket>().First();
            var parsedDocket = new ParsedGoogleImageSearchDocket();
            HtmlDocument doc = new HtmlDocument();
            using (var stream = new StringReader(imageSearchDocket.Content))
            {
                doc.Load(stream);
                foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
                {
                    if (link.ParentNode != null)
                    {
                        if (link.ParentNode.Name.Equals("h3", StringComparison.OrdinalIgnoreCase))
                        {
                            var crumbs = link.InnerText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var crumb in crumbs.Distinct())
                            {
                                if (InvalidWordRegex.Match(crumb).Success)
                                {
                                    continue;
                                }

                                if (parsedDocket.Keywords.ContainsKey(crumb))
                                {
                                    parsedDocket.Keywords[crumb]++;
                                }
                                else
                                {
                                    parsedDocket.Keywords.Add(crumb, 1);
                                }
                            }
                        }
                        else if (link.ParentNode.InnerText.StartsWith("Best guess for this image:", StringComparison.OrdinalIgnoreCase))
                        {
                            parsedDocket.BestGuess = link.InnerText;
                        }
                    }
                }
            }

            plan.Dockets.Add(parsedDocket);
            await Task.Delay(10);
        }
    }
}