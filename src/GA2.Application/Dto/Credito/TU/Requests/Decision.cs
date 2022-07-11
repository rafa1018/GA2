using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "Decision")]
    public class Decision
    {
        public string texto { get; set; }
    }
}
