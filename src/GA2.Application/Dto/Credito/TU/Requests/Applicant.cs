using GA2.Application.Dto.Credito.TU.Requests;
using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "Applicant")]
    public class Applicant
    {
        [XmlElement(ElementName = "IdType")]
        public int IdType { get; set; }
        [XmlElement(ElementName = "IdNumber")]
        public string IdNumber { get; set; }
        [XmlElement(ElementName = "LastName")]
        public string LastName { get; set; }
        [XmlElement(ElementName = "RecentPhoneNumber")]
        public string RecentPhoneNumber { get; set; }
        [XmlElement(ElementName = "IdExpeditionDate")]
        public string IdExpeditionDate { get; set; }
        [XmlElement(ElementName = "Occupation")]
        public string Occupation { get; set; }
        [XmlElement(ElementName = "MonthlyIncome")]
        public string MonthlyIncome { get; set; }
        [XmlElement(ElementName = "Score")]
        public string Score { get; set; }

        [XmlElement(ElementName = "CapacidadEndeudamiento")]
        public string CapacidadEndeudamiento { get; set; }

        [XmlElement(ElementName = "PorcEndFinal")]
        public string PorcEndFinal { get; set; }

        [XmlElement(ElementName = "DSOnlineBureauCOLData")]
        public DSOnlineBureauCOLData DSOnlineBureauCOLData { get; set; }
    }
}
