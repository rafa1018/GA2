using System;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Tabla de Flujo
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>10/05/2021</date>
    public class Flujo
    {
        public int FLU_ID { get; set; }
        public string FLU_DESCRIPCION { get; set; }
        public int FLU_ORDEN { get; set; }
        public int FLU_ESTADO { get; set; }
        public Guid FLU_CREADO_POR { get; set; }
        public DateTime FLU_FECHA_CREACION { get; set; }
        public Guid FLU_MODIFICADO_POR { get; set; }
        public DateTime FLU_FECHA_MODIFICACION { get; set; }

    }
}
