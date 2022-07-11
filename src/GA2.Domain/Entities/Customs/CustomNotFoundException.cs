using System;

namespace GA2.Domain.Entities
{
    public class CustomNotFoundException : ModelBaseException
    {
        public CustomNotFoundException(ApplicationMessage message, Exception exception = null)
           : base(message, exception) { }
        public CustomNotFoundException() : base() { }
        public CustomNotFoundException(string message) : base(message) { }
        public CustomNotFoundException(string message, Exception innerException)
            : base(message, innerException) { }

    }
}
