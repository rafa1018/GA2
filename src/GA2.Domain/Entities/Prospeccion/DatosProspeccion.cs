using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class DatosProspeccion
    {
        public int ID_DATOS_PROSPECCION { get; set; }
        public Guid SDP_ID { get; set; }
        public int ETR_ID { get; set; }
        public int ID_NVA { get; set; }
        public int ID_TVP { get; set; }
        public int ID_TIC { get; set; }
        public int ID_PEC { get; set; }
        public decimal TOTAL_ACTIVOS { get; set; }
        public decimal TOTAL_PASIVOS { get; set; }
        public string DESICION_HOMOLOGADA { get; set; }
        public decimal RIESGO_CREDITO { get; set; }
        public decimal CAPACIDAD_PAGO_LIBRANZA { get; set; }
        public bool VIABILIDAD { get; set; }
    }
}
