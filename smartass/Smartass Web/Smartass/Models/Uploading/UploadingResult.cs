using System.Collections.Generic;
using Smartass.Models.Uploading.JsonAlchemy;
using Smartass.Models.Uploading.JsonClarifai;

namespace Smartass.Models.Uploading
{
    public class UploadingResult : IPlanResult
    {
        public UploadingResult()
        {
            this.BestGuesses = new SortedList<double, string>(new SortDescendingComparer());
        }

        public SortedList<double, string> BestGuesses { get; private set; }

        public URLGetRankedImageKeywordsResponse AlchemyKeywords { get; set; }
        
        public ClarifaiImageKeywords ClarifaiKeywords { get; set; }

        public string GoogleBestGuess { get; internal set; }

        public Dictionary<string, int> GoogleKeywords { get; internal set; }
    }

    public class SortDescendingComparer : Comparer<double>
    {
        public override int Compare(double x, double y)
        {
            if (x < y)
            {
                return 1;
            }

            return -1;
        }
    }

}