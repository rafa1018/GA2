using System.Collections.Generic;
using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "Question")]
    public class Question
    {
        [XmlElement(ElementName = "Answer")]
        public List<Answer> Answer { get; set; }
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "QuestionId")]
        public int QuestionId { get; set; }
        [XmlAttribute(AttributeName = "Text")]
        public string Text { get; set; }
        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "IsDummy")]
        public int IsDummy { get; set; }
        [XmlAttribute(AttributeName = "isQuestionTextHasListTypeDataElement")]
        public bool IsQuestionTextHasListTypeDataElement { get; set; }
        [XmlAttribute(AttributeName = "ListAnswerIndex")]
        public int ListAnswerIndex { get; set; }
        [XmlAttribute(AttributeName = "ExpirationTime")]
        public string ExpirationTime { get; set; }
        [XmlAttribute(AttributeName = "TimeTakenToAnswer")]
        public string TimeTakenToAnswer { get; set; }
    }
}
