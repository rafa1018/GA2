using System.Xml.Serialization;

namespace GA2.Application.Dto
{
    [XmlRoot(ElementName = "ResponseInfo")]
    public class ResponseInfo
    {
        [XmlElement(ElementName = "ApplicationId")]
        public string ApplicationId { get; set; }
        [XmlElement(ElementName = "QueueName")]
        public string QueueName { get; set; }
        [XmlElement(ElementName = "ExecutionMode")]
        public string ExecutionMode { get; set; }
        [XmlElement(ElementName = "SolutionSetInstanceId")]
        public string SolutionSetInstanceId { get; set; }
        [XmlElement(ElementName = "CurrentQueue")]
        public string CurrentQueue { get; set; }
    }
}
