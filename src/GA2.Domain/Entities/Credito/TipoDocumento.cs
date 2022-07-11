using System;

namespace GA2.Domain.Entities
{
    /// <summary>
	/// Tabla de Tipo Documento
	/// </summary>
	/// <author>Cristian Gonzalez Parra</author>
	/// <date>10/05/2021</date>
    public class TipoDocumento
    {
        public int TDC_ID { get; set; }
        public string TDC_DESCRIPCION { get; set; }
        public int TDC_ESTADO { get; set; }
        public Guid TDC_CREADO_POR { get; set; }
        public DateTime TDC_FECHA_CREACION { get; set; }
        public Guid TDC_MODIFICADO_POR { get; set; }
        public DateTime TDC_FECHA_MODIFICACION { get; set; }

    }
}
