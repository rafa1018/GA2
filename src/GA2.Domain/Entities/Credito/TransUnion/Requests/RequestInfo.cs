namespace GA2.Domain.Entities
{
    public class RequestInfo
    {
        public string SolutionSetId { get; set; }
        public string ExecuteLatestVersion { get; set; }
        public string ExecutionMode { get; set; }
        public string ApplicationId { get; set; }
        public string QueueName { get; set; }
    }
}
