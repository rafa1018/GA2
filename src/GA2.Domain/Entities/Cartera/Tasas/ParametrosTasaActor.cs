using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class ParametrosTasaActor
    {
        public int PAR_ID { get; set; }
        public int SIM_ID { get; set; }
        public int TPA_ID { get; set; }
        public decimal PAR_TASA_EA { get; set; }
        public int PAR_ESTADO { get; set; }
        public Guid PAR_CREADO_POR { get; set; }
        public DateTime PAR_FECHA_CREACION { get; set; }
        public Guid PAR_MODIFICADO_POR { get; set; }
        public DateTime PAR_FECHA_MODIFICACION { get; set; }

      
    }

        
}
