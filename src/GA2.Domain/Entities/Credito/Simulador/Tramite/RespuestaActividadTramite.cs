using System;
using System.Collections.Generic;

namespace GA2.Domain.Entities
{
    public class RespuestaActividadTramite
    {
        public Guid ACT_ID { get; set; }
        public Guid TRS_ID { get; set; }
        public int AFL_ID { get; set; }
        public Guid ID_USER { get; set; }
        public int MyProperty { get; set; }
        public DateTime ACT_FECHA_INICIO { get; set; }
        public DateTime ACT_FECHA_FINALIZA { get; set; }
        public string ACT_OBSERVACION { get; set; }
        public int ACT_ESTADO { get; set; }
        public Guid ACT_CREADO_POR { get; set; }
        public DateTime ACT_FECHA_CREACION { get; set; }
        public Guid ACT_APROVADO_POR { get; set; }
        public DateTime ACT_FECHA_APROVACION { get; set; }
        public Guid ACT_MODIFICADO_POR { get; set; }
        public DateTime ACT_FECHA_MODIFICACION { get; set; }
        public IEnumerable<string> PANELES { get; set; }

    }
}
