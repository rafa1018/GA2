using System;

namespace GA2.Domain.Entities
{
    public class ActualizarSolicitud
    {
        public Guid SOL_ID { get; set; }
        public decimal SOL_VALOR_A_RETIRAR { get; set; }
    }
}
