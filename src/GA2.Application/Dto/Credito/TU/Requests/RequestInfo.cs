using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "RequestInfo")]
    public class RequestInfo
    {
        [XmlElement(ElementName = "SolutionSetId")]
        public string SolutionSetId { get; set; }
        [XmlElement(ElementName = "ExecuteLatestVersion")]
        public string ExecuteLatestVersion { get; set; }
        [XmlElement(ElementName = "ExecutionMode")]
        public string ExecutionMode { get; set; }
        [XmlElement(ElementName = "ApplicationId")]
        public string ApplicationId { get; set; }
        [XmlElement(ElementName = "QueueName")]
        public string QueueName { get; set; }

    }
}
