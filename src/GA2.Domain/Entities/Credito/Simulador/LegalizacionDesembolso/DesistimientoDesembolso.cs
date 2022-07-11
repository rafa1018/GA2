using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class DesistimientoDesembolso
    {
        public Guid SID_ID { get; set; }
        public Guid SOC_ID { get; set; }
        public int FRC_ID { get; set; }
        public int SID_VALOR_DESEMBOLSO { get; set; }
        public DateTime SID_FECHA_DESEMBOLSO { get; set; }
        public string SID_APLICADO { get; set; }
        public Guid SID_APLICADO_POR { get; set; }
        public DateTime SID_FECHA_APLICACION { get; set; }
        public string SID_ANULADO { get; set; }
        public int CDD_ID { get; set; }
        public Guid SID_ANULADO_POR { get; set; }
        public DateTime SID_FECHA_ANULACION { get; set; }
        public string SID_OBSERVACION_ANULACION { get; set; }
        public Guid SID_CREADO_POR { get; set; }
        public DateTime SID_FECHA_CREACION { get; set; }
        public Guid SID_ACTUALIZADO_POR { get; set; }
    }
}
