using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "Reason")]
    public class Reason
    {
        [XmlElement(ElementName = "Applicant")]
        public string Applicant { get; set; }
        [XmlElement(ElementName = "Code")]
        public string Code { get; set; }
        [XmlElement(ElementName = "Type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
    }
}
