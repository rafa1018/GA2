namespace GA2.Domain.Entities
{
    public class ApplicationMessage
    {
        public string Message { get; set; }
        public int Code { get; set; }
        public override string ToString()
        {
            return string.Format("[{0}]- {1}", Code, Message);
        }
    }
}
