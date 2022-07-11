using System;

namespace GA2.Domain.Entities
{
    public class PeticionSolicitudObtenerTramite
    {
        public DateTime? FECHA_SOL { get; set; }
        public string CLI_IDENTIFICACION { get; set; }
        public Guid USUARIO_ID { get; set; }
        public int? ESTADO_ACT { get; set; }
        public int? TCR_ID { get; set; }
    }
}
