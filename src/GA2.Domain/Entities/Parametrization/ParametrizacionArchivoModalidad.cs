using System;

namespace GA2.Domain.Entities
{
    public class ParametrizacionArchivoModalidad
    {
        public Guid PAM_ID { get; set; }
        public string PAM_NOMBRE_ARCHIVO { get; set; }
        public string PAM_DESCRIPCION_ARCHIVO { get; set; }
        public Boolean PAM_REQUERIDO { get; set; }
        public Boolean PAM_ESTADO { get; set; }
        public int PAM_ORDEN { get; set; }
    }
}
