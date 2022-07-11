using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Tabla de Usuario Actividad
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>10/05/2021</date>
    public class UsuarioActividad
    {
        public long USA_ID { get; set; }
        public int AFL_ID { get; set; }
        public Guid ID_USERS { get; set; }
        public int USA_ESTADO { get; set; }
        public Guid USA_CREADO_POR { get; set; }
        public DateTime USA_FECHA_CREACION { get; set; }
        public Guid USA_MODIFICADO_POR { get; set; }
        public DateTime USA_FECHA_MODIFICACION { get; set; }

    }
}
