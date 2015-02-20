using System.Xml.Serialization;

namespace Smartass.WolframAlpha.Models.Xml
{
    public class Pod
    {
        [XmlElement("subpod")]
        public Subpod[] Subpods { get; set; }

        [XmlAttribute("error")]
        public bool Error { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }
    }
}