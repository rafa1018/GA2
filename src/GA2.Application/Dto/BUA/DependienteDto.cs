using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class DependienteDto
    {
        public int IdCliente { get; set; }
        public int TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public decimal Participacion { get; set; }
    }
}
