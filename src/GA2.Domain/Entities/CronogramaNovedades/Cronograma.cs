using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class Cronograma
    {
        public int CRO_ID { get; set; }
        public int FRZ_ID { get; set; }
        public string FRZ_DESCRIPCION { get; set; }
        public int UEJ_ID { get; set; }
        public string UEJ_NOMBRE { get; set; }
        public DateTime CRO_FECHA_REPORTE { get; set; }
        public DateTime CRO_FECHA_INICIO { get; set; }
        public DateTime CRO_FECHA_FIN { get; set; }
        public string CRO_PERIODO { get; set; }
        public string FRT_ID { get; set; }
        public string FRT_DESCRIPCION { get; set; }
        public string MDE_ID { get; set; }
        public string MDE_DESCRIPCION { get; set; }
    }
}
