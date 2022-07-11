using System.Collections.Generic;

namespace GA2.Domain.Entities
{
    public class Question
    {
        public List<Answer> Answer { get; set; }
        public string Id { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public int IsDummy { get; set; }
        public bool IsQuestionTextHasListTypeDataElement { get; set; }
        public int ListAnswerIndex { get; set; }
        public string ExpirationTime { get; set; }
        public string TimeTakenToAnswer { get; set; }
    }
}
