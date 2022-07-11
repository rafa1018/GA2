using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class ConceptoCuentaDto
    {
        public int Id { get; set; }
        public int CuentaId { get; set; }
        public int ConceptoId { get; set; }
        public double saldo { get; set; }
        public DateTime FechaUltimoAporte { get; set; }
        public int Ingresos { get; set; }
        public double Sva { get; set; }

        public List<MovimientosCuentaDto> Movimientos { get; set; }
    }
}
