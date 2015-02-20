using Smartass.Models.Uploading.JsonClarifai;

namespace Smartass.Models.Uploading
{
    internal class ClarifaiImageKeywordDocket : UploadingDocketBase
    {
        public ClarifaiImageKeywordDocket(ClarifaiImageKeywords imageKeywords)
        {
            this.ImageKeywords = imageKeywords;
        }

        internal ClarifaiImageKeywords ImageKeywords { get; private set; }
    }
}