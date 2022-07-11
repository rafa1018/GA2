using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "IDMReasonsCode")]
    public class IDMReasonsCode
    {
        [XmlElement(ElementName = "Reason")]
        public Reason Reason { get; set; }
    }
}
