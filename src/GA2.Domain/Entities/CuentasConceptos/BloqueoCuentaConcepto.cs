using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class BloqueoCuentaConcepto
    {
	public Guid	BCC_ID { get; set; }	
	public Guid CSB_ID { get; set; }
	public int CTA_ID { get; set; }
	public int CCT_ID { get; set; }
	public string BCC_TIPO_BLOQUEO { get; set; }
	public bool	BCC_MONTO { get; set; }
	public double BCC_VALOR { get; set; }
	// public DateTime	BCC_FECHA { get; set; }
	public Guid BCC_CREADOPOR { get; set; }
	public bool	BCC_ESTADO { get; set; }

	}
}
