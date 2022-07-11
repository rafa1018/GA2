using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class InsertCuentaConcepto
    {

        public int CTA_ID { get; set; }
        public int CTA_ID_INTEGRACION { get; set; }
        public int CTA_NUMERO { get; set; }
        public int CLI_ID { get; set; }
        public int? TCT_ID { get; set; }
        public int? ECT_ID { get; set; }
        public int? CCN_ID { get; set; }
        public int? DCT_ID { get; set; }
        public DateTime? CTA_FECHA_CREACION { get; set; }
        public DateTime? CTA_FECHA_CIERRE { get; set; }
        public DateTime? CTA_FECHA_PRIMER_APORTE { get; set; }
        public double? CTA_SALDO { get; set; }
        public double? CTA_SALDO_CANJE { get; set; }
        public double? CTA_SALDO_DISPONIBLE { get; set; }
        public int? CTA_CUOTAS { get; set; }
        public bool? CTA_BLOQUEO { get; set; } = false;
        public int? EJE_UNIDAD_EJECUTORA { get; set; }

    }
}
