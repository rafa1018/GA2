using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class RequestEliminarFuentesRecursosDto
    {
        public Guid IdSolicitudCredito { get; set; }
        public Guid IdSolicitudDesembolso { get; set; }
    }
}
