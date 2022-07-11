using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class SolicitudTerceroBeneficiarioDto
    {
        public int TipoDoc { get; set; }
        public string NumDoc { get; set; }
        public string Razonsocial { get; set; }
        public Guid? Entidad { get; set; }
        public int TipoCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public decimal? ValorRetirarDos { get; set; }
    }
}
