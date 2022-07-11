using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class SolicitudTerceroApoderadoDto
    {
        public int? TipoDoc { get; set; }
        public string NumDoc { get; set; }
        public string Razonsocial { get; set; }
        public int? Parentesco { get; set; }
        public bool EsAutorizado { get; set; }
    }
}
