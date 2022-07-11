using System;

namespace GA2.Domain.Entities
{
    public class TipoModalidad
    {
        public Guid TIM_ID { get; set; }
        public string TIM_DESCRIPCION { get; set; }
        public int TIM_ACTIVO { get; set; }
        public string TIM_CODIGO { get; set; }
    }
}
