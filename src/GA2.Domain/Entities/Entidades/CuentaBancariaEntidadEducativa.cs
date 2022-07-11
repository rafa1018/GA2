using System;

namespace GA2.Domain.Entities
{
    public class CuentaBancariaEntidadEducativa
    {
        public Guid ENE_CTA_BANCARIA { get; set; }
        public Guid ENE_ID { get; set; }
        public Guid ENE_ENT_ID { get; set; }
        public string ENT_NOMBRE_RAZON_SOCIAL { get; set; }
        public string ENE_NUMERO_CTA  { get; set; }
        public bool ENE_CTA_ESTADO  { get; set; }
    }
}
