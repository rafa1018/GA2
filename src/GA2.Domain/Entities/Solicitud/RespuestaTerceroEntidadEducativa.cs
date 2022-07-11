using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class RespuestaTerceroEntidadEducativa
    {
        public Guid ENE_ID_FK { get; set; }
        public String TER_NUMERO_DOCUMENTO { get; set; }
        public String TER_NOMBRE_RAZON_SOCIAL { get; set; }
        public Guid PGN_ID { get; set; }
        public Guid PRN_ID { get; set; }
        public string TER_NUM_RECIBO_PAGO { get; set; }
        public string TER_FECHA_LIMITE_PAGO { get; set; }
    }
}
