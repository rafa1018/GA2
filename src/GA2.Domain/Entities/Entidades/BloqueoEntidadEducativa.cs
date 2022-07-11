using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entidad educativa
    /// </summary>
    public class BloqueoEntidadEducativa
    {
        public Guid ENE_BLOQUEO { get; set; }
        public Guid ENE_ID { get; set; }
        public int ENE_TIPO_OPERACION { get; set; }
        public int ENE_CAUSAL_BLOQUEO { get; set; }
        public DateTime ENE_FECHA_BLOQUEO { get; set; }
        public Guid ENE_FUNCIONARIO_BLOQUEO { get; set; }

    }
}