using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class PeticionConsultarSolicitudCesantias
    {
        public DateTime? SOL_FECHA_SOLICITUD { get; set; }
        public string CLI_IDENTIFICACION { get; set; }
        public Guid USR_ID { get; set; }
        public int? CVL_ID { get; set; } //estados
        public Guid? PCS_ID { get; set; } //tipo solicitud
    }
}
