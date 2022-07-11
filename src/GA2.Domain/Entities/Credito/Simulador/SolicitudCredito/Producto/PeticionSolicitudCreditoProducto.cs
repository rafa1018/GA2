using System;

namespace GA2.Domain.Entities
{
    public class PeticionSolicitudCreditoProducto
    {
        public string SOP_ID { get; set; }
        public Guid SOC_ID { get; set; }
        public int IND { get; set; }
    }
}
