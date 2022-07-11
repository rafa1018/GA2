using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class TerceroEntidadEducativaRespuestaDto
    {
        public string razonSocial { get; set; }
        public Guid idEntidad { get; set; }
        public Guid idNivel { get; set; }
        public string reciboPago { get; set; }
        public string fechalimite { get; set; }
    }
}
