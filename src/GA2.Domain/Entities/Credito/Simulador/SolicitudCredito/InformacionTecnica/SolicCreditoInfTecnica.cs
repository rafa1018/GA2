using System;

namespace GA2.Domain.Entities
{
    public class SolicCreditoInfTecnica
    {
        public Guid SIT_ID { get; set; }
        public Guid SOC_ID { get; set; }
        public int SIT_VALOR_AVALUO_COMERCIAL { get; set; }
        public int SIT_VALOR_VENTA_INMUEBLE { get; set; }
        public string SIT_CONSIDERACIONES_FINALES { get; set; }
        public string SIT_DECLARA_CUMPLIMIENTO { get; set; }
        public string SIT_CONDICIONES_SALVEADES { get; set; }
        public string SIT_CONCEPTO_EST_TECNICO { get; set; }
        public string SIT_ESTRATO { get; set; }
        public string NOMBRE_ALIADO { get; set; }
        public Guid SIT_CREADO_POR { get; set; }
        public DateTime SIT_FECHA_CREACION { get; set; }
    }
}
