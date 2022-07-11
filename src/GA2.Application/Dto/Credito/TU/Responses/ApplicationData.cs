using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "ApplicationData")]
    public class ApplicationData
    {
        [XmlElement(ElementName = "VelocityCheckReasons")]
        public VelocityCheckReasons VelocityCheckReasons { get; set; }
        [XmlElement(ElementName = "ReturnMessage")]
        public string ReturnMessage { get; set; }
        [XmlElement(ElementName = "IDVReasonsCode")]
        public IDVReasonsCode IDVReasonsCode { get; set; }
        [XmlElement(ElementName = "OTPReasons")]
        public OTPReasons OTPReasons { get; set; }
        [XmlElement(ElementName = "RiskLevel")]
        public string RiskLevel { get; set; }
        [XmlElement(ElementName = "IDAReasons")]
        public IDAReasons IDAReasons { get; set; }
        [XmlElement(ElementName = "IDMReasonsCode")]
        public IDMReasonsCode IDMReasonsCode { get; set; }
        [XmlElement(ElementName = "IDMOutcome")]
        public string IDMOutcome { get; set; }
        [XmlElement(ElementName = "Product")]
        public string Product { get; set; }

        [XmlElement(ElementName = "DecisionHomologada")]
        public string DecisionHomologada { get; set; }

    }
}