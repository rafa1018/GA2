using System.Collections.Generic;
using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "Questions")]
    public class Questions
    {
        [XmlElement(ElementName = "Question")]
        public List<Question> Question { get; set; }
    }
}
