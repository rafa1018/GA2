using System;

namespace GA2.Domain.Entities
{
    public class SolicCreditoInfJurInm
    {
        public Guid SJI_ID { get; set; }
        public Guid SIJ_ID { get; set; }
        public Guid SOC_ID { get; set; }
        public string SJI_NUMERO_MATRICULA { get; set; }
        public string SJI_CEDULA_CATASTRAL { get; set; }
        public int SJI_AREA_PRIVADA { get; set; }
        public int SJI_VALOR_AVALUO_COMERCIAL { get; set; }
        public int SJI_VALOR_AVALUO_CATASTRAL { get; set; }
        public Guid SJI_CREADO_POR { get; set; }
        public DateTime SJI_FECHA_CREACION { get; set; }

    }
}
