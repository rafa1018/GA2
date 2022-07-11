using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entidad de un procedimiento almacenado de mombre VerificarAfiliado
    /// </summary>
    /// <author>Cristian Gonzalez </author>
	/// <date>09/08/2021</date>
    public class VerificarAfiliado
    {
	    public int CLI_ID { get; set; }
		public int TCT_ID { get; set; }
		public int ECT_ID { get; set; }
		public int CCN_ID { get; set; }
		public int DCT_ID { get; set; }
		public DateTime CTA_FECHA_CREACION { get; set; }
		public DateTime CTA_FECHA_CIERRE { get; set; }
		public DateTime CTA_FECHA_PRIMER_APORTE { get; set; }
		public decimal CTA_SALDO { get; set; }
		public int CTA_SALDO_CANJE { get; set; }
		public decimal CTA_SALDO_DISPONIBLE { get; set; }
		public int CTA_CUOTAS { get; set; }
		// Tabla  Movimiento
	    public int CNC_ID  { get; set; }
		public decimal MVT_VALOR { get; set; }
		public string CAT_TIPO_MOVIMIENTO { get; set; }
		public DateTime MVT_FECHA_PROCESO { get; set; }
		public string MVT_ANO_PERIODO { get; set; }
		public DateTime MVT_FECHA_MOVIMIENTO { get; set; }

	}
}
