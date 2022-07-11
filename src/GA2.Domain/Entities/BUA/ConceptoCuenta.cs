using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class ConceptoCuenta
    {

        public int CCT_ID { get; set; }
        public int CTA_ID { get; set; }
        public int CNC_ID { get; set; }
        public double CCT_SALDO { get; set; }
        public DateTime CCT_FECHA_ULTIMO_APORTE { get; set; }
        public int CCT_INGRESOS { get; set; }
        public double CCT_SVA { get; set; }
    }
}
