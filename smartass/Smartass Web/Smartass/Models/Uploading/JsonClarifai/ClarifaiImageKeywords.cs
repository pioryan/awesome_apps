using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Smartass.Models.Uploading.JsonClarifai
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ClarifaiImageKeywords
    {
        [JsonProperty("files")]
        public ClarifaiImageKeyword[] Files { get; set; }
    }
}
