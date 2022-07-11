namespace GA2.Domain.Entities
{
    public class ResponseInfo
    {
        public string ApplicationId { get; set; }
        public string QueueName { get; set; }
        public string ExecutionMode { get; set; }
        public string SolutionSetInstanceId { get; set; }
        public string CurrentQueue { get; set; }
    }
}
