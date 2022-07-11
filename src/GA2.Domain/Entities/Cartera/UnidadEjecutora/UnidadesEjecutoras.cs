using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class UnidadesEjecutoras
    {
        public int PAR_ID { get; set; }
        public int SIM_ID { get; set; }
        public int UEJ_ID { get; set; }
        public decimal PAR_TASA_EA { get; set; }
        public int PAR_ESTADO { get; set; }
        public string UEJ_NOMBRE { get; set; }
        public Guid PAR_CREADO_POR { get; set; }
        public DateTime PAR_FECHA_CREACION { get; set; }
        public Guid PAR_MODIFICADO_POR { get; set; }
        public DateTime PAR_FECHA_MODIFICACION { get; set; }
        public string UEJ_IDENTIFICACION { get; set; }
        public string UEJ_SIGLA { get; set; }
    }
}
