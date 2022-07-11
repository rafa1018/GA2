using System;

namespace GA2.Application.Dto
{
    public class ActividadTramiteSolicitudDto
    {
        public string ACTIVIDAD_PRINCIPAL { get; set; }
        public int AFL_ID { get; set; }
        public Guid TRS_ID { get; set; }
        public string ACT_OBSERVACION { get; set; }
        public Guid ACT_MODIFICADO_POR { get; set; }
        public DateTime ACT_FECHA_MODIFICACION { get; set; }
    }
}
