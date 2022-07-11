

using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Tabla de Aseguradoras
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>27/04/2021</date>
    public class Aseguradoras
    {
        public int ASE_ID { get; set; }
        public string ASE_RAZON_SOCIAL { get; set; }
        public string ASE_SITIO_WEB { get; set; }
        public int ASE_ESTADO { get; set; }
        public Guid ASE_CREADO_POR { get; set; }
        public DateTime ASE_FECHA_CREACION { get; set; }
        public Guid ASE_ACTUALIZADO_POR { get; set; }
        public DateTime ASE_FECHA_ACTUALIZA { get; set; }

    }
}
