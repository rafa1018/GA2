using System;

namespace GA2.Domain.Entities
{
    public class RespuestaObservacionTramite
    {
        public Guid ID_TRAMITE { get; set; }
        public Guid ID_ACTIVIDAD_TRAMITE { get; set; }
        public int ID_ACTIVIDAD { get; set; }
        public string ACTIVIDAD { get; set; }
        public string OBSERVACION { get; set; }
        public DateTime FECHA_INGRESO { get; set; }
        public string USUARIO_INGRESO { get; set; }
    }
}
