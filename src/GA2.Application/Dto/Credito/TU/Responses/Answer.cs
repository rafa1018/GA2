using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "Answer")]
    public class Answer
    {
        [XmlAttribute(AttributeName = "IsSelected")]
        public bool IsSelected { get; set; }
        [XmlAttribute(AttributeName = "CorrectAnswer")]
        public bool CorrectAnswer { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
}
