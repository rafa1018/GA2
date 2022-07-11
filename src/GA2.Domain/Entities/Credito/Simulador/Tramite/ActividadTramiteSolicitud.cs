using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Domain.Entities
{
    public class ActividadTramiteSolicitud
    {
        [Key]
        public string ACTIVIDAD_PRINCIPAL { get; set; }
        public int AFL_ID { get; set; }
        public Guid TRS_ID { get; set; }
        public string ACT_OBSERVACION { get; set; }
        public Guid ACT_MODIFICADO_POR { get; set; }
        public DateTime ACT_FECHA_MODIFICACION { get; set; }
    }
}
