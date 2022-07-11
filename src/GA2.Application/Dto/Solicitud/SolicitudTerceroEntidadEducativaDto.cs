using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class SolicitudTerceroEntidadEducativaDto
    {
        public string Nit { get; set; }
        public string RazonSocial { get; set; }
        public Guid IdEntidad { get; set; }
        public Guid IdNivel { get; set; }
        public string ReciboPago { get; set; }
        public DateTime Fechalimite { get; set; }
    }
}
