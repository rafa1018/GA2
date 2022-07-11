using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class ParametrosAplicacionPagosDto
    {
        public Guid IdParametros { get; set; }
        public decimal TasaMora { get; set; }
        public int FactorDias { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
