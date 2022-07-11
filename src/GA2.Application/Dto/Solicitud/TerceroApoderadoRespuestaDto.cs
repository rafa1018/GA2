using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class TerceroApoderadoRespuestaDto
    {
        public Guid id { get; set; }
        public int tipoDoc { get; set; }
        public LlaveValorDto tipoDocObj { get; set; }
        public string numDoc { get; set; }
        public string razonsocial { get; set; }
        public int parentesco { get; set; }
        public LlaveValorDto parentescoObj { get; set; }
        public bool esAutorizado { get; set; }
    }
}
