using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class RequestFichaRiesgo
    {
        public Guid IdSolicitud { get; set; }
        public string NombreSolicitante { get; set; }
        public string IdSolicitante { get; set; }
    }
}
