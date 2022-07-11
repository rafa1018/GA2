using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entidad de una cuenta del cargue de nomina
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public class Cuenta
    {
        public int CTA_ID { get; set; }
        public int CTA_ID_INTEGRACION { get; set; }
        public int CTA_NUMERO { get; set; }
        public int CLI_ID { get; set; }
        public int TCT_ID { get; set; }
        public int ECT_ID { get; set; }
        public int CCN_ID { get; set; }
        public int DCT_ID { get; set; }
        public int TPA_ID { get; set; }
        public DateTime CTA_FECHA_CREACION { get; set; }
        public DateTime CTA_FECHA_CIERRE { get; set; }
        public DateTime CTA_FECHA_PRIMER_APORTE { get; set; }
        public int CTA_SALDO { get; set; }
        public int CTA_SALDO_CANJE { get; set; }
        public int CTA_SALDO_DISPONIBLE { get; set; }
        public int CTA_CUOTAS { get; set; }

        public int CCT_ID { get; set;}
    }
}