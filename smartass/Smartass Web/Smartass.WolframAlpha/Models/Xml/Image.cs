using System.ComponentModel;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Smartass.WolframAlpha.Models.Xml
{
    public class Image
    {
        private string xmlDocument;

        [XmlAnyAttribute]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public XmlAttribute[] DocumentElements { get; set; }

        [XmlIgnore]
        public string Xml
        {
            get
            {
                if (this.xmlDocument == null)
                {
                    StringBuilder sb = new StringBuilder("<img ");
                    foreach (var node in this.DocumentElements)
                    {
                        sb.AppendFormat("{0} ", node.OuterXml);
                    }

                    this.xmlDocument = sb.Append(" />").ToString();
                }

                return this.xmlDocument;
            }
        }
    }
}