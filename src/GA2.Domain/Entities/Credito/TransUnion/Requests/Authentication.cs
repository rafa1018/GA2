namespace GA2.Domain.Entities
{
    public class Authentication
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Token { get; set; }
    }
}
