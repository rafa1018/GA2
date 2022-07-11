using System;

namespace GA2.Domain.Entities
{
    public class TemaComiteCredito
    {
        public Guid? COT_ID { get; set; }
        public int COC_ID { get; set; }
        public int TCO_ID { get; set; }
        public int COT_ORDEN { get; set; }
        public string COT_OBSERVACION { get; set; }
        public Guid COT_CREADO_POR { get; set; }
        public DateTime? COT_FECHA_CREACION { get; set; }
        public string DESCRIPCION_TEMA { get; set; }
    }
}
