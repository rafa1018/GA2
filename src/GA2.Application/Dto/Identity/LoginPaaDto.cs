using GA2.Transversals.Commons;
using System;

namespace GA2.Application.Dto.Identity
{
    public class LoginPaaDto : BaseRequest
    {
        public string TipoDocumento { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string NumeroCelular { get; set; }
        public DateTime FechaExpedicion { get; set; }
    }
}
