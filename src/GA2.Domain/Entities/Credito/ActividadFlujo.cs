using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Tabla de ActividadFlujo
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>10/05/2021</date>
    public class ActividadFlujo
    {
        public int AFL_ID { get; set; }
        public int FLU_ID { get; set; }
        public int TAC_ID { get; set; }
        public int AFL_ORDEN { get; set; }
        public int AFL_TIEMPO { get; set; }
        public char AFL_ACTIVIDAD_AUTOMATICA { get; set; }
        public char AFL_ACTIVIDAD_PRINCIPAL { get; set; }
        public char AFL_PUEDE_DELEGAR { get; set; }
        public char AFL_CARGA_ARCHIVOS { get; set; }
        public char AFL_VISUALIZA_ARCHIVOS { get; set; }
        public char AFL_CAPTURA_DATOS_TEC { get; set; }
        public char AFL_CAPTURA_DATOS_JUR { get; set; }
        public char AFL_CAPTURA_DATOS_FIN { get; set; }
        public char AFL_VISUALIZA_DATOS_BAS { get; set; }
        public char AFL_VIISUALIZA_DATOS_GAR { get; set; }
        public char AFL_VISUALIZA_DATOS_FIN { get; set; }
        public char AFL_GENERA_PDF_RESUMEN { get; set; }
        public char AFL_CONSULTA_BURO { get; set; }
        public char AFL_ENVIO_NOTIFICACION { get; set; }
        public char AFL_ENVIO_NOTIFICACION_VENC { get; set; }
        public char AFL_ENVIA_NOTIFICACION_CLIENTE { get; set; }
        public int AFL_ESTADO { get; set; }
        public Guid AFL_CREADO_POR { get; set; }
        public DateTime AFL_FECHA_CREACION { get; set; }
        public Guid AFL_MODIFICADO_POR { get; set; }
        public DateTime AFL_FECHA_MODIFICACION { get; set; }

    }
}
