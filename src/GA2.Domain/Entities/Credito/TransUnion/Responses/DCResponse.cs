using System.Collections.Generic;

namespace GA2.Domain.Entities
{
    public class DCResponse
    {
        public string Status { get; set; }
        public Authentication Authentication { get; set; }
        public ResponseInfo ResponseInfo { get; set; }
        public ContextData ContextData { get; set; }
        public List<Field> Fields { get; set; }
        public ErrorInfo ErrorInfo { get; set; }
    }
}
