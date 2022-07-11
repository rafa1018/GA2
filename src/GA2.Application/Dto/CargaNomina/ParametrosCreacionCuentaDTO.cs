using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// Creacion Dto parametros para la creacion de las cuentas en GA2
/// </summary>
/// <author>Cristian Gonzalez</author>
/// <Date>31/08/2021</Date>

namespace GA2.Application.Dto
{
    public class ParametrosCreacionCuentaDTO
    {

		public int ClienteId { get; set; }
		public int TipoCuentaId { get; set; }
		public int EstadodCuentaId { get; set; }
		public int CausalEstadId { get; set; }
		public int NumeroDocumetoId { get; set; }
		public DateTime CuentaFechaCreacion { get; set; }
		public DateTime CuentaFechaCierre { get; set; }
		public DateTime CuentaFechaPrimerAporte { get; set; }
		public int CuentaSaldo { get; set; }
		public int CuentaSaldoCanje { get; set; }
		public int CuentaSaldoDisponible { get; set; }
		public int CuentaCuotas { get; set; }
		// Tabla  Movimiento
		public int MovimientoConceptoId { get; set; }
		public int MovimientoValor { get; set; }
		public string TipoMovimiento { get; set; }
		public DateTime MovimientoFechaProceso { get; set; }
		public int DocumentoId { get; set; }
		public string MovimientoAnoPeriodo { get; set; }
		public DateTime FechaMovimiento { get; set; }
	}
}
