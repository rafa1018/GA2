using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "ExamDetails")]
    public class ExamDetails
    {
        [XmlElement(ElementName = "Questions")]
        public Questions Questions { get; set; }
        [XmlAttribute(AttributeName = "xsi")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "xsd")]
        public string Xsd { get; set; }
        [XmlAttribute(AttributeName = "Title")]
        public string Title { get; set; }
        [XmlAttribute(AttributeName = "Language")]
        public string Language { get; set; }
        [XmlAttribute(AttributeName = "MatchKeyId")]
        public int MatchKeyId { get; set; }
        [XmlAttribute(AttributeName = "ErrorGeneratingQA")]
        public bool ErrorGeneratingQA { get; set; }
        [XmlAttribute(AttributeName = "TimeTakenToAnswer")]
        public string TimeTakenToAnswer { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
}
