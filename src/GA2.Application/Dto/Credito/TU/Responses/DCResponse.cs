using GA2.Application.Dto.Credito.TU.Requests;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "DCResponse")]
    public class DCResponse
    {
        [XmlElement(ElementName = "Status")]
        public string Status { get; set; }
        [XmlElement(ElementName = "Authentication")]
        public Authentication Authentication { get; set; }
        [XmlElement(ElementName = "ResponseInfo")]
        public ResponseInfo ResponseInfo { get; set; }
        [XmlElement(ElementName = "ContextData")]
        public ContextData ContextData { get; set; }
        [XmlElement(ElementName = "Fields")]
        public List<Field> Fields { get; set; }
        public ErrorInfo ErrorInfo { get; set; }
    }
}
