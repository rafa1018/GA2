using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class SolicitudDesembolso
    {
        public Guid SID_ID { get; set; }
        public Guid SOC_ID { get; set; }
        public string NUMERO_SOLICITUD { get; set; }
        public string TIPO_CREDITO { get; set; }
        public string DOCUMENTO_CLIENTE { get; set; }
        public string NOMBRE_CLIENTE { get; set; }
        public int FRC_ID { get; set; }
        public string FUENTE_RECURSOS { get; set; }
        public DateTime SID_FECHA_DESEMBOLSO { get; set; }
        public int SID_VALOR_DESEMBOLSO { get; set; }
        public string APLICADO { get; set; }
        public DateTime FECHA_APLICACION { get; set; }
        public Guid? SID_APLICADO_POR { get; set; }
        public string ANULADO { get; set; }
        public DateTime FECHA_ANULACION { get; set; }
        public string OBSERVACION_ANULACION { get; set; }
        public Guid SID_ANULADO_POR { get; set; }
        public string CAUSA_ANULACION { get; set; }
        public Guid SID_CREADO_POR { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public Guid ACTUALIZADO_PRO { get; set; }
        public DateTime FECHA_ACTUALIZACION { get; set; }
    }
}
