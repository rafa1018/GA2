using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class RequestSolicitudCreditoDto
    {
        public string IdSolicitud { get; set; }
        public string Documento { get; set; }
        public int Indicador { get; set; }
    }
}
