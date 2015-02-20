using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Smartass.Models.Uploading.JsonAlchemy
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ImageKeyword
    {
        [JsonProperty("score")]
        public float Score { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}