using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class TipoCredito
    {
        [Key]
        public int TCR_ID { get; set; }
        public string TCR_DESCRIPCION { get; set; }
        public int TCR_ID_PADRE { get; set; }
        public int TCR_NIVEL { get; set; }
        public int TCR_ESTADO { get; set; }
        public Guid TCR_CREADO_POR { get; set; }
        public DateTime TCR_FECHA_CREACION { get; set; }
        public Guid TCR_MODIFICADO_POR { get; set; }
        public DateTime TCR_FECHA_MODIFICACION { get; set; }
    }
}
