using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class BeneficiariosPagoEmbargo
    {
	    public Guid BPE_ID { get; set; }
		public Guid EBA_ID { get; set; }
		public int TID_ID { get; set; }
		public string BPE_NUMERO_IDENTIFICACION { get; set; }
		public string BPE_PRIMER_NOMBRE { get; set; }
		public string BPE_SEGUNDO_NOMBRE { get; set; }
		public string BPE_PRIMER_APELLIDO { get; set; }
		public string BPE_SEGUNGO_APELLIDO { get; set; }
		public DateTime BPE_FECHA_REGISTRO { get; set; }
		public DateTime BPE_FECHA_ACTUALIZACION { get; set; }
		public Guid BPE_CREADOPOR { get; set; } 
		public Guid BPE_ACTUALIZADOPOR { get; set; }
		public bool BPE_ESTADO { get; set; }
		public string TIPO_IDENTIFICACION { get; set; }
		public string EBA_RADICADO_WORK_MANAGER { get; set; }

	}
}
