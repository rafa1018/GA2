using System;

namespace GA2.Domain.Entities
{
    public class DatosComiteCredito
    {
        public int COC_ID { get; set; }
        public string COC_FECHA { get; set; }
        public string COC_LUGAR { get; set; }
        public string COC_HORA_INICIO { get; set; }
        public string COC_HORA_FINALIZACION { get; set; }
        public int COC_NUMERO_COMITE { get; set; }
        public string COC_DESARROLLO { get; set; }
        public string COC_TEMAS_APROBACION { get; set; }
        public string COC_ANOTACION { get; set; }
        public string COC_CARGO_ANALISTA { get; set; }
        public string COC_ESTADO { get; set; }
        public Guid COC_CREADO_POR { get; set; }
        public DateTime COC_FECHA_CREACION { get; set; }
        public Guid COC_ACTUALIZADO_POR { get; set; }
        public DateTime COC_FECHA_ACTUALIZA { get; set; }
        public string ESTADO { get; set; }


    }
}
