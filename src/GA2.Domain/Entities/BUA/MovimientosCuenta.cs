using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class MovimientosCuenta
    {

        public int MVT_ID { get; set; }
        public int CTA_ID { get; set; }
        public int CNC_ID { get; set; }
        public double MVT_VALOR { get; set; }
        public string CAT_TIPO_MOVIMIENTO { get; set; }
        public DateTime MVT_FECHA_PROCESO { get; set; }
        public int  DCT_ID { get; set; }
        public string MVT_ANO_PERIODO { get; set; }
        public DateTime MVT_FECHA_MOVIMIENTO { get; set; }
    }
}
