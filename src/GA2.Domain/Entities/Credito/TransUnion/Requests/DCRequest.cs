namespace GA2.Domain.Entities
{
    class DCRequest
    {
        public Authentication Authentication { get; set; }
        public RequestInfo RequestInfo { get; set; }
        public Fields Fields { get; set; }
        public string Xmlns { get; set; }
    }
}
