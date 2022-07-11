using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class BloqueoCuentaConceptoDto
    {
		public Guid Id { get; set; }
		public Guid CausalBloqueoId { get; set; }
		public int CuentaId { get; set; }
		public int ConceptoId { get; set; }
		public string TipoBloqueo { get; set; }
		public bool Monto { get; set; }
		public double Valor { get; set; }
		// public DateTime Fecha { get; set; }
		public Guid CreadoPor { get; set; }
		public bool Estado { get; set; }

	}
}
