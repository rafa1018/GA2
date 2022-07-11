using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "OTPReasons")]
    public class OTPReasons
    {
        [XmlElement(ElementName = "Reason")]
        public Reason Reason { get; set; }
    }
}
