using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class EstadoTareaSolicitud
    {
        [Key]
        public int CVL_ID { get; set; }
        public string CVL_CODIGO { get; set; }
        public string CVL_DESCRIPCION { get; set; }
        public string CVL_ACTIVO { get; set; }
    }
}
