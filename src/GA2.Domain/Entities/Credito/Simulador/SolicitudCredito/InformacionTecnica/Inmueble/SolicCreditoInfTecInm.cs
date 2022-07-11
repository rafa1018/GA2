using System;

namespace GA2.Domain.Entities
{
    public class SolicCreditoInfTecInm
    {
        public Guid STI_ID { get; set; }
        public Guid SIT_ID { get; set; }
        public Guid SOC_ID { get; set; }
        public string STI_NUMERO_MATRICULA { get; set; }
        public DateTime STI_FECHA_MATRICULA { get; set; }
        public string STI_NUMERO_CHIP { get; set; }
        public string STI_CEDULA_CATASTRAL { get; set; }
        public Guid STI_CREADO_POR { get; set; }
        public DateTime STI_FECHA_CREACION { get; set; }
    }
}
