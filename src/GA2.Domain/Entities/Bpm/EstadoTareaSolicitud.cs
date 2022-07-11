using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities.Bpm
{
    public class EstadoTareaSolicitud
    {
        public int CVL_ID { get; set; }
        public int CAT_ID { get; set; }
        public string CVL_CODIGO { get; set; }
        public string CVL_DESCRIPCION { get; set; }
        public bool CVL_ACTIVO { get; set; }
    }
}
