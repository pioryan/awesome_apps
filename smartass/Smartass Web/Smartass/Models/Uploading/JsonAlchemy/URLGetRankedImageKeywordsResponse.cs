
using Newtonsoft.Json;

namespace Smartass.Models.Uploading.JsonAlchemy
{
    [JsonObject( MemberSerialization.OptIn)]
    public class URLGetRankedImageKeywordsResponse
    {
        [JsonProperty("imageKeywords")]
        public ImageKeyword[] ImageKeywords { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}