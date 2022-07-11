using System;

namespace GA2.Domain.Entities
{
    public class SolicCreditoInfJuridica
    {
        public Guid SIJ_ID { get; set; }
        public Guid SOC_ID { get; set; }
        public string SIJ_LINDEROS { get; set; }
        public string SIJ_TIPO_PARQUEADERO { get; set; }
        public string SIJ_EDAD_JURIDICA { get; set; }
        public DateTime SIJ_FECHA_PRIMER_ACTO { get; set; }
        public string SIJ_TRADICION_INMUEBLE { get; set; }
        public string SIJ_ANALISIS_ULT_20_AÑOS { get; set; }
        public string SIJ_ANALISIS_SIT_JURIDICA { get; set; }
        public string SIJ_ANALISIS_REG_PROP_HOR { get; set; }
        public string SIJ_ANALISIS_PAZ_Y_SALVO { get; set; }
        public string SIJ_ANALISIS_VENDEDOR { get; set; }
        public string SIJ_VIABILIDAD_JUR_NEGOCIO { get; set; }
        public string SIJ_RECOMENDACIONES { get; set; }
        public string SIJ_CONCEPTO_JURIDICO_FIN { get; set; }
        public string SIJ_CONCEPTO_EST_JURIDICO { get; set; }
        public int DPD_ID { get; set; }
        public int DPC_ID { get; set; }
        public string DEPARTAMENTO { get; set; }
        public string CIUDAD { get; set; }
        public string NOMBRE_ALIADO { get; set; }
        public string SIJ_DIRECCION { get; set; }
        public Guid SIJ_CREADO_POR { get; set; }
        public DateTime SIJ_FECHA_CREACION { get; set; }
    }
}
