using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class AprobarSolicitudTarea
    {
        public Guid SLT_ID { get; set; }
        public int SLT_ESTADO_SOLICITUD { get; set; }
        public int SLT_ESTADO_SOLICITUD_NUEVO { get; set; }
    }
}
