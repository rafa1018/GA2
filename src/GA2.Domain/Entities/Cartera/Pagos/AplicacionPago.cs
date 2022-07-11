using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class AplicacionPago
    {
        public Guid CPG_ID { get; set; }
        public Guid CRE_ID { get; set; }
        public DateTime CPG_FECHA_PAGO { get; set; }
        public DateTime CPG_FECHA_APLICACION { get; set; }
        public decimal CPG_ABONO_SEGURO_HOGAR { get; set; }
        public decimal CPG_ABONO_SEGURO_VIDA { get; set; }
        public decimal CPG_ABONO_INTERES_CORRIENTE { get; set; }
        public decimal CPG_ABONO_INTERES_MORA { get; set; }
        public decimal CPG_ABONO_CAPITAL { get; set; }
        public decimal CPG_VALOR_PAGO { get; set; }
        public int DCT_ID { get; set; }
        public Guid CPG_CREADO_POR { get; set; }
        public DateTime CPG_FECHA_CREACION { get; set; }
        public Guid CPG_MODIFICADO_POR { get; set; }
        public DateTime CPG_FECHA_MODIFICACION { get; set; }
    }
}
