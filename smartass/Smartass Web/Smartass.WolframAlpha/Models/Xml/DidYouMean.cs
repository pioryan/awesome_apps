using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Smartass.WolframAlpha.Models.Xml
{
    public class DidYouMean
    {
        [XmlAttribute("score")]
        public float Score { get; set; }

        [XmlAttribute("level")]
        public string Level { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
