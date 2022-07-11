using System;

namespace GA2.Domain.Entities
{
    public class SolicitudComiteCreacion
    {
        public Guid COS_ID { get; set; }
        public Guid SOC_ID { get; set; }
        public int COC_ID { get; set; }
        public string COS_RESULTADO { get; set; }
        public string COS_APROBADA { get; set; }
        public string COS_RECHAZADA { get; set; }
        public Guid COS_CREADO_POR { get; set; }
        public DateTime COS_FECHA_CREACION { get; set; }
        public Guid COS_ACTUALIZADO_POR { get; set; }
        public DateTime COS_FECHA_ACTUALIZACION { get; set; }
        public decimal COS_VALOR_CREDITO { get; set; }
        public int COS_PLAZO_CREDITO { get; set; }
        public decimal COS_TEA_CREDITO { get; set; }
    }
}
