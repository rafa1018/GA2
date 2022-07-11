namespace GA2.Domain.Entities
{
    public class ExamDetails
    {
        public Questions Questions { get; set; }
        public string Xsi { get; set; }
        public string Xsd { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public int MatchKeyId { get; set; }
        public bool ErrorGeneratingQA { get; set; }
        public string TimeTakenToAnswer { get; set; }
        public string Text { get; set; }
    }
}
