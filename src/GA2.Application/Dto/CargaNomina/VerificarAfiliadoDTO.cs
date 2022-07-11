using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
	/// <summary>
	/// Entidad DTO de un procedimiento almacenado de mombre VerificarAfiliado
	/// </summary>
	/// <author>Cristian Gonzalez</author>
	/// <date>09/08/2021</date>
	public class VerificarAfiliadoDTO
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
		public int CcuentaSaldoDisponible { get; set; }
		public int CuentaCuotas { get; set; }
		// Tabla  Movimiento
		public int MovimientoConceptoId { get; set; }
		public int MovimientoValor { get; set; }
		public string TipoMovimiento { get; set; }
		public DateTime MovimientoFechaProceso { get; set; }
		//public int DCT_ID { get; set; }
		public string MovimientoAnoPeriodo { get; set; }
		public DateTime FechaMovimiento { get; set; }
	}
}
