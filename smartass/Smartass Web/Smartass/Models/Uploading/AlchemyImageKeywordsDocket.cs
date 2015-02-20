using Smartass.Models.Uploading.JsonAlchemy;

namespace Smartass.Models.Uploading
{
    internal class AlchemyImageKeywordsDocket : UploadingDocketBase
    {
        public AlchemyImageKeywordsDocket(URLGetRankedImageKeywordsResponse imageKeywords)
        {
            this.ImageKeywords = imageKeywords;
        }

        internal URLGetRankedImageKeywordsResponse ImageKeywords { get; private set; }
    }
}