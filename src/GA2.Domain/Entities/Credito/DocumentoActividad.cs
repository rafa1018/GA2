using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Tabla de Documento Actividad
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>10/05/2021</date>
    public class DocumentoActividad
    {
        public int DCA_ID { get; set; }
        public int AFL_ID { get; set; }
        public int TDC_ID { get; set; }
        public int DCA_ORDEN { get; set; }
        public char DCA_OBLIGATORIO { get; set; }
        public char DCA_CARGA { get; set; }
        public char DCA_VISUALIZA { get; set; }
        public char DCA_VISUALIZA_CLIENTE { get; set; }
        public int DCA_ESTADO { get; set; }
        public Guid DCA_CREADO_POR { get; set; }
        public DateTime DCA_FECHA_CREACION { get; set; }
        public Guid DCA_MODIFICADO_POR { get; set; }
        public DateTime DCA_FECHA_MODIFICACION { get; set; }

    }
}
