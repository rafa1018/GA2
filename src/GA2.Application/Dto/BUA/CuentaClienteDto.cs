using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class CuentaClienteDto
    {
        public int CuentaId { get; set; }
        public int CuentaIdIntegracion{ get; set; }
        public int NumeroCuenta { get; set; }
        public int ClinteId { get; set; }
        public int TipoCuentaId { get; set; }
        public int EstadoCuentaId { get; set; }
        public int CausalEstadoId { get; set; }
        public int DocumentoId { get; set; }
        public DateTime FechaCreacion{ get; set; }
        public DateTime FechaCierre { get; set; }
        public DateTime FechaPrimerAporte { get; set; }
        public double Saldo{ get; set; }
        public double SaldoCanje { get; set; }
        public double SaldoDisponible { get; set; }
        public int Cueotas { get; set; }
        public bool CuentaBloqueo { get; set; }
        public List<MovimientosCuentaDto> Movimientos { get; set; }
        public List<ConceptoCuentaDto> Conceptos { get; set; }
        public string NombreCuenta { get; set; }





    }
}
