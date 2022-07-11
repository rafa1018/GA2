using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class EmbargoCuentaConcepto
    {
        public Guid ECC_ID { get; set; }
        public double ECC_VALOR { get; set; }
        public DateTime ECC_FECHA_INICIO_EMBARGO { get; set; }
        public DateTime ECC_FECHA_FIN_EMBARGO { get; set; }
        public bool  ECC_INDICADOR_CESANTIAS { get; set; }
        public Guid EBA_ID { get; set; }
        public Guid TRE_ID { get; set; }
        public Guid TIE_ID { get; set; }
        public int CTA_ID { get; set; }
        public int CCT_ID { get; set; }
        public DateTime EBA_FECHA_REGISTRO { get; set; }
        public DateTime EBA_FECHA_ACTUALIZACION { get; set; }
        public Guid EBA_CREADOPOR { get; set; }
        public Guid EBA_ACTUALIZADOPOR { get; set; }
        public bool ECC_ESTADO { get; set; }

        public string TIPO_RETENCION { get; set; }

        public string TIPO_EMBARGO { get; set; }

        public string EBA_RADICADO_WORK_MANAGER { get; set; }
    }
}
