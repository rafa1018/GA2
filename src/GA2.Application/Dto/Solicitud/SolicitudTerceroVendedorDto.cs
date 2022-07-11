using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class  SolicitudTerceroVendedorDto
    {
        public int TipoDoc { get; set; }
        public string NumDoc { get; set; }
        public string Razonsocial { get; set; }
        public string Direccion { get; set; }
        public int Ciudad { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
    }
}
