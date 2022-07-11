using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "Field")]
    public class Field
    {
        [XmlAttribute(AttributeName = "key")]
        public string Key { get; set; }
        [XmlText]
        public string Text { get; set; }
        [XmlElement(ElementName = "ApplicationData")]
        public ApplicationData ApplicationData { get; set; }
    }
}
