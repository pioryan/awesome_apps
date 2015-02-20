using Newtonsoft.Json;

namespace Smartass.Models.Uploading.JsonClarifai
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ClarifaiImageKeyword
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nearest_urls")]
        public string[] NearestUrls { get; set; }

        [JsonProperty("predicted_classes")]
        public string[] PredictedClasses { get; set; }

        [JsonProperty("predicted_probs")]
        public float[] predictedProbabilities { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}