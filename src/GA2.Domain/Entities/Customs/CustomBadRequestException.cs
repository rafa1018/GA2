using System;

namespace GA2.Domain.Entities
{
    public class CustomBadRequestException : ModelBaseException
    {
        public CustomBadRequestException(ApplicationMessage message, Exception exception = null)
              : base(message, exception) { }
        public CustomBadRequestException() : base() { }
        public CustomBadRequestException(string message) : base(message) { }
        public CustomBadRequestException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
