using System;

namespace GA2.Domain.Entities
{
    public class TipoSolicitud
    {
        public Guid PCS_ID { get; set; }
        public string PCS_NOMBRE { get; set; }
        public int PCS_ESTADO { get; set; }
    }
}
