using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "Authentication")]
    public class Authentication
    {
        [XmlElement(ElementName = "UserId")]
        public string UserId { get; set; }
        [XmlElement(ElementName = "Password")]
        public string Password { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "Status")]
        public string Status { get; set; }
        [XmlElement(ElementName = "Token")]
        public string Token { get; set; }
    }
}
