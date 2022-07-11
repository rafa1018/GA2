using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class InconsistenciaSolicitud
    {
        public Guid INC_ID { get; set; }
        public Guid LIN_ID_FK { get; set; }
        public int GIN_GRUPO { get; set; }
        public Guid HER_ID_FK { get; set; }
        public Guid PTA_ID_FK { get; set; }
        public Guid SOL_ID_FK { get; set; }
        public Guid USR_ID_FK { get; set; }
        public string INC_OBJETO_ESTUDIO { get; set; }
        public string INC_ANALISIS_REALIZADO { get; set; }
        public string INC_OBSERVACION { get; set; }
        public bool INC_ESTADO { get; set; }
        public Guid INC_CREATEDOPOR { get; set; }
        public Guid INC_MODIFICADOPOR { get; set; }
        public DateTime INC_FECHAMODIFICACION { get; set; }
    }
}
