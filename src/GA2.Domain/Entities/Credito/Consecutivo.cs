using System;
namespace GA2.Domain.Entities
{
    /// <summary>
    /// Tabla de Consecutivos
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>24/04/2021</date>
    public class Consecutivo
    {
        public string CNS_ID { get; set; }
        public string CNS_DESCRIPCION { get; set; }
        public long CNS_ULTIMO_NUMERO { get; set; }
        public int CNS_ESTADO { get; set; }
        public Guid CNS_CREADO_POR { get; set; }
        public DateTime CNS_FECHA_CREACION { get; set; }
        public Guid CNS_ACTUALIZADO_POR { get; set; }
        public DateTime CNS_FECHA_ACTUALIZA { get; set; }
    }
}