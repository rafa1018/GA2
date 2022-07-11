using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "Applicants")]
    public class Applicants
    {
        public Applicant Applicant { get; set; }
    }
}
