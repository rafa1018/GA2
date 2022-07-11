using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "IDVReasonsCode")]
    public class IDVReasonsCode
    {
        [XmlElement(ElementName = "Reason")]
        public Reason Reason { get; set; }
    }
}
