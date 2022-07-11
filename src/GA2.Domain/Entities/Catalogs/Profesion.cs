using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    /// <summary>
    /// Profesion Table
    /// </summary>
    public class Profesion
    {
        [Key]
        public int PRF_ID { get; set; }
        public string PRF_DESCRIPCION { get; set; }
        public int PRF_ESTADO { get; set; }
        public Guid PRF_CREADO_POR { get; set; }
        public DateTime PRF_FECHA_CREACION { get; set; }
        public Guid PRF_ACTUALIZADO_POR { get; set; }
        public DateTime PRF_FECHA_ACTUALIZA { get; set; }
    }
}
