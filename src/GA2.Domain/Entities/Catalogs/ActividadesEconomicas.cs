using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{

    public class ActividadEconomica
    {
        [Key]
        public int ACC_ID { get; set; }
        public string ACC_DESCRIPCION { get; set; }
        public string ACC_CODIGO_CIUU { get; set; }
        public int ACC_ESTADO { get; set; }
        public Guid ACC_CREADO_POR { get; set; }
        public DateTime ACC_FECHA_CREACION { get; set; }
        public Guid ACC_ACTUALIZADO_POR { get; set; }
        public DateTime ACC_FECHA_ACTUALIZA { get; set; }
    }
}
