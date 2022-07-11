using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "IDAReasons")]
    public class IDAReasons
    {
        [XmlElement(ElementName = "Reason")]
        public Reason Reason { get; set; }
    }
}
