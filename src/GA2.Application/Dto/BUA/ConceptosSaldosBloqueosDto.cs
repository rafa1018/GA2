using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class ConceptosSaldosBloqueosDto
    {
        public int CantidadIngresos { get; set; }
        public string Concepto { get; set; }
        public int Documento { get; set; }
        public string EstadoBloqueo { get; set; }
        public DateTime FechaBloqueo { get; set; }
        public DateTime FechaUltimoAporteConcepto { get; set; }
        public int IdConcepto { get; set; }
        public int IdExpd { get; set; }
        public string NroExpd { get; set; }
        public string Origen { get; set; }
        public decimal SaldoConceptoCuenta { get; set; }
        public decimal SaldoInicialAno { get; set; }
        public decimal ValorAcumulado { get; set; }
        public decimal ValorBloqueo { get; set; }
    }
}
