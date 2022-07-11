using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class RequestIntegracionesAfiliadoDto
    {
        public int TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string FechaExpedicionIdentificacion { get; set; }
        public string Apellidos { get; set; }
    }
}
