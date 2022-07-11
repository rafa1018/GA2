using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class RespuestaDocumentosPorSubModalidad
    {
        public Guid PAM_ID { get; set; }
        public string PAM_NOMBRE_ARCHIVO { get; set; }
        public string PAM_DESCRIPCION_ARCHIVO { get; set; }
        public bool PAM_REQUERIDO { get; set; }
        public int PAM_ORDEN { get; set; }
        public bool PAM_MULTIPLE_ARCHIVO { get; set; }
        public string PAM_FORMATO { get; set; }
    }
}
