using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "DCRequest", Namespace = "http://transunion.com/dc/extsvc")]
    public class DCRequest
    {
        [XmlElement(ElementName = "Authentication")]
        public Authentication Authentication { get; set; }
        [XmlElement(ElementName = "RequestInfo")]
        public RequestInfo RequestInfo { get; set; }
        [XmlElement(ElementName = "Fields")]
        public Fields Fields { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }
}
