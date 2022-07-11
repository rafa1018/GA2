using System;
using System.Runtime.Serialization;

namespace GA2.Domain.Entities
{
    public class ModelBaseException : Exception
    {
        public ApplicationMessage ApplicationMessage { get; set; }

        public ModelBaseException() : base() { }
        public ModelBaseException(string message) : base(message) { }
        public ModelBaseException(string message, Exception innerException)
            : base(message, innerException) { }

        public ModelBaseException(ApplicationMessage message, Exception innerException = null)
       : base(message.Message, innerException)
        {
            this.ApplicationMessage = message;
        }

        public ModelBaseException(SerializationInfo info, StreamingContext context)
        {
            ApplicationMessage.Message = (string)info.GetValue("ApplicationMessage", typeof(string));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("ApplicationMessage", ApplicationMessage, typeof(string));
        }
    }
}
