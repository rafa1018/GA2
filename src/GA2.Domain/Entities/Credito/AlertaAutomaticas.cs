using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Tabla de ALA_AlertaAutomaticas
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>27/04/2021</date>
    public class AlertaAutomaticas
    {
        public int ALA_ID { get; set; }
        public string ALA_DESCRIPCION { get; set; }
        public string ALA_MENSAJE { get; set; }
        public DateTime ALA_FECHA_CREACION { get; set; }
        public Guid ALA_MODIFICADO_POR { get; set; }
        public DateTime ALA_FECHA_MODIFICACION { get; set; }

    }
}
