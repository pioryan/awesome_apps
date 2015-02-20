using System;
using System.Linq;
using System.Threading.Tasks;
using Smartass.Models;
using Smartass.Models.Uploading;

namespace Smartass.Steps.Uploading
{
    internal class FinalizeStep : StepBase
    {
        protected override async Task ProcessAsync(Plan plan)
        {
            var result = new UploadingResult();
            var google = plan.Dockets.OfType<ParsedGoogleImageSearchDocket>().First();
            result.GoogleKeywords = google.Keywords;
            if (google.Keywords.Any())
            {
                var averageGoogleScore = google.Keywords.Average(k => k.Value);
                result.BestGuesses.Add(averageGoogleScore / 10,
                    String.Concat(google.Keywords
                    .Where(k => k.Value >= averageGoogleScore)
                    .OrderByDescending(k => k.Value)
                    .Take(3)
                    .Select(k => k.Key + " ")).TrimEnd());
            }

            var alchemy = plan.Dockets.OfType<AlchemyImageKeywordsDocket>().FirstOrDefault();
            if (alchemy != null)
            {
                result.AlchemyKeywords = alchemy.ImageKeywords;
                if (result.AlchemyKeywords.ImageKeywords.Any())
                {
                    foreach (var item in result.AlchemyKeywords.ImageKeywords)
                    {
                        result.BestGuesses.Add(item.Score, item.Text);
                    }
                }
            }

            var clarifai = plan.Dockets.OfType<ClarifaiImageKeywordDocket>().FirstOrDefault();
            if (clarifai != null)
            {
                if (clarifai.ImageKeywords.Files.Any() && clarifai.ImageKeywords.Files.First().PredictedClasses.Any())
                {
                    result.ClarifaiKeywords = clarifai.ImageKeywords;
                    var file = result.ClarifaiKeywords.Files.First();
                    for (int i = 0; i < file.PredictedClasses.Length; i++)
                    {
                        result.BestGuesses.Add(file.predictedProbabilities.ElementAtOrDefault(i), file.PredictedClasses[i]);
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(google.BestGuess))
            {
                result.GoogleBestGuess = google.BestGuess;
                result.BestGuesses.Add(0.99, google.BestGuess);
            }

            plan.Result = result;
            await Task.Delay(10);
        }
    }
}