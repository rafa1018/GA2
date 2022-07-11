using System;

namespace GA2.Domain.Entities
{
    public class ParametroTransaccion
    {
        public int PAR_TRA_ID { get; set; }
        public string PAR_CONCEPTO { get; set; }
        public int PAR_CODIGO { get; set; }
        public string PAR_PROCESO { get; set; }
        public Guid PAR_CREADO_POR { get; set; }
        public DateTime PAR_FECHA_CREACION { get; set; }
        public Guid PAR_MODIFICADO_POR { get; set; }
        public DateTime PAR_FECHA_MODIFICACION { get; set; }


    }
}
