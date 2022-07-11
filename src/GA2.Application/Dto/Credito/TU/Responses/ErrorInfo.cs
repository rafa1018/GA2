using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "ErrorInfo")]
    public class ErrorInfo
    {
        [XmlElement(ElementName = "Message")]
        public string Message { get; set; }
    }
}
