using System;

namespace GA2.Domain.Entities
{
    public class CustomConflictException : ModelBaseException
    {
        public CustomConflictException(ApplicationMessage message, Exception exception = null)
           : base(message, exception) { }
        public CustomConflictException() : base() { }
        public CustomConflictException(string message) : base(message) { }
        public CustomConflictException(string message, Exception innerException)
            : base(message, innerException) { }

    }
}
