using System;

namespace GA2.Domain.Entities
{
    public class ComiteIntegrante
    {
        public Guid COI_ID { get; set; }
        public int COC_ID { get; set; }
        public int ICO_ID { get; set; }
        public int COI_ORDEN { get; set; }
        public Guid COI_CREADO_POR { get; set; }
        public DateTime COI_FECHA_CREACION { get; set; }
    }
}
