using Newtonsoft.Json;
using System;

namespace GA2.Transversals.Commons
{
    /// <summary>
    /// Clase base respuesta apis
    /// </summary>
    /// <typeparam name="T">Modelo generico de respuesta</typeparam>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/04/2021</date>
    public class Response<T> : BaseMessage
    {
        public Response() : base()
        {
            this.SetCorrelation(base._correlationId);
        }

        private Guid correlation;

        public Guid GetCorrelation()
        {
            return correlation;
        }

        private void SetCorrelation(Guid value)
        {
            correlation = value;
        }

        public bool IsSuccess { get; set; } = true;
        public string ReturnMessage { get; set; }
        public T Data { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
