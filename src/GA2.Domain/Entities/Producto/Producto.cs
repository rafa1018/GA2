using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Entidad producto
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>12/04/2021</date>
    public class Producto
    {
        public int TCR_ID { get; set; }
        public int PRD_NUMERO_CREDITO { get; set; }
        public DateTime PRD_FECHA_ALTA { get; set; }
        public string PRD_ESTADO { get; set; }
        public DateTime PRD_FECHA_ESTADO { get; set; }
        public DateTime PRD_FECHA_PAGO { get; set; }
        public int PRD_DIAS_MORA { get; set; }
        public int PRD_VALOR { get; set; }
        public int TIV_VIVIENDA_ID { get; set; }
        public int ESV_ESTADO_VIVIENDA { get; set; }
        public int PRD_CREDITO { get; set; }
        public int PRD_DEUDA { get; set; }
        public int PRD_MORA { get; set; }
        public int PRD_CUOTA_ANO { get; set; }
        public int PRD_CUOTA_MES { get; set; }
        public float PRD_SEGURO_VIDA { get; set; }
        public float PRD_SEGURO_TODO_RIESGO { get; set; }
        public float PRD_TASA_EFECTIVA_ANUAL { get; set; }
        public float PRD_TASA_NOMINAL_MENSUAL { get; set; }
        public bool PRD_TASA_FRECH_APLICA { get; set; }
        public float PRD_TASA_FRECH { get; set; }
        public bool PRD_ALIVIO_CUOTA_APLICA { get; set; }
        public float PRD_ALIVIO_CUOTA { get; set; }

    }
}
