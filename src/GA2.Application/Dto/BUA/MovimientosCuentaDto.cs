using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class MovimientosCuentaDto
    {

        public int MovimientoId { get; set; }
        public int Cuentaid { get; set; }
        public int ConceptoId { get; set; }
        public double Valor { get; set; }
        public string TipoMovimiento { get; set; }
        public DateTime FechaProceso { get; set; }
        public int DocumentoId { get; set; }
        public string PeriodoAno { get; set; }
        public DateTime FechaMovimiento { get; set; }

    }
}
