using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Tabla de ColorGrilla
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>30/04/2021</date>
    public class ColorGrilla
    {
        public int CLG_ID { get; set; }
        public string CLG_DESCRIPCION { get; set; }
        public string CLG_ESTILO_COLOR { get; set; }
        public int CLG_ESTADO { get; set; }
        public Guid CLG_CREADO_POR { get; set; }
        public DateTime CLG_FECHA_CREACION { get; set; }
        public Guid CLG_ACTUALIZADO_POR { get; set; }
        public DateTime CLG_FECHA_ACTUALIZA { get; set; }

    }
}
