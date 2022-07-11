using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class TerceroBeneficiarioRespuestaDto
    {
        public Guid id { get; set; }
        public int tipoDoc { get; set; }
        public LlaveValorDto tipoDocObj { get; set; }
        public string numDoc { get; set; }
        public string razonsocial { get; set; }
        public Guid? entidad { get; set; }
        public LlaveValortextoDto entidadObj { get; set; }
        public int tipoCuenta { get; set; }
        public LlaveValorDto tipoCuentaObj { get; set; }
        public string numeroCuenta { get; set; }
        public decimal? valorRetirarDos { get; set; }
    }
}
