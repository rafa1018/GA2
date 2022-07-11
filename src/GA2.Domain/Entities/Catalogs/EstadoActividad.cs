using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class EstadoActividad
    {
        [Key]
        public int ESA_ID { get; set; }
        public string ESA_DESCRIPCION { get; set; }
        public string ESA_ESTADO { get; set; }
        public Guid ESA_CREADO_POR { get; set; }
        public DateTime ESA_FECHA_CREACION { get; set; }
        public Guid ESA_MODIFICADO_POR { get; set; }
        public DateTime ESA_FECHA_MODIFICACION { get; set; }
    }
}
