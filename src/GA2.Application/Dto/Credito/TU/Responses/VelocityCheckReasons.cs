using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "VelocityCheckReasons")]
    public class VelocityCheckReasons
    {
        [XmlElement(ElementName = "Reason")]
        public Reason Reason { get; set; }
    }
}
