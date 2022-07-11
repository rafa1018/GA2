namespace GA2.Domain.Entities
{
    public class Root
    {
        public QueueRequest QueueRequest { get; set; }
        public Response Response { get; set; }
        public string Request { get; set; }
        public OnlineBureauDDCall OnlineBureauDDCall { get; set; }
        public string IssueDate { get; set; }
        public string IssuePlace { get; set; }
        public string IdType { get; set; }
    }
}