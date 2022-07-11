using System;

namespace GA2.Domain.Entities
{
    public class TiposProcesos
    {
        public Guid TPE_ID { get; set; }
        public string TPE_NOMBRE { get; set; }
        public string TPE_DESCRIPCION { get; set; }
        public bool TPE_ESTADO { get; set; }

    }
}
