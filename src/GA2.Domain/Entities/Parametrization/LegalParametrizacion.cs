using System;

namespace GA2.Domain.Entities
{
    public class LegalParametrizacion
    {
        public int PAR_LEG_ID { get; set; }
        public decimal PAR_TASA_FRECH { get; set; }
        public DateTime PAR_VIGENCIA_TASA_FRECH { get; set; }
        public decimal PAR_ALIVIO_CUOTA { get; set; }
        public DateTime PAR_VIGENCIA_ALIVIO_CUOTA { get; set; }
        public decimal PAR_GMF { get; set; }
        public DateTime PAR_VIGENCIA_GMF { get; set; }
        public DateTime PAR_FECHA_MODIFICACION { get; set; }
        public int PAR_MODIFICADO_POR { get; set; }
        public bool PAR_ESTADO { get; set; }


    }
}
