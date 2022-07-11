using System;

namespace GA2.Domain.Entities
{
    /// <summary>
	/// Tabla de Tipo Actividad
	/// </summary>
	/// <author>Cristian Gonzalez Parra</author>
	/// <date>10/05/2021</date>
    public class TipoActividad
    {
        public int TAC_ID { get; set; }
        public string TAC_DESCRIPCION { get; set; }
        public int TAC_ESTADO { get; set; }
        public Guid TAC_CREADO_POR { get; set; }
        public DateTime TAC_FECHA_CREACION { get; set; }
        public Guid TAC_MODIFICADO_POR { get; set; }
        public DateTime TAC_FECHA_MODIFICACION { get; set; }

    }
}
