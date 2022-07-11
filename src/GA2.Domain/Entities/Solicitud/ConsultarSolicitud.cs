using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class ConsultarSolicitud
    {
        public Guid TPS_SUB_ID { get; set; }
        public int CLI_ID { get; set; }
        public int SOL_ESTADO_ANULADO { get; set; }

    }
}
