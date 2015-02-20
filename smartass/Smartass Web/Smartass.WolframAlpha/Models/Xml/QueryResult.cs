using System.Xml.Serialization;

namespace Smartass.WolframAlpha.Models.Xml
{
    [XmlRoot("queryresult")]
    public class QueryResult
    {
        [XmlAttribute("success")]
        public bool Success { get; set; }

        [XmlAttribute("error")]
        public bool Error { get; set; }

        [XmlElement("pod")]
        public Pod[] Pods { get; set; }

        [XmlArray("didyoumeans")]
        [XmlArrayItem("didyoumean")]
        public DidYouMean[] DidYouMeans { get; set; }
    }
}