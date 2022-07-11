using System;

namespace GA2.Domain.Entities
{
    public class IntegranteComite
    {
        public int ICO_ID { get; set; }
        public string ICO_NOMBRE { get; set; }
        public string ICO_CARGO { get; set; }
        public string ICO_TIPO { get; set; }
        public int ICO_ESTADO { get; set; }
        public Guid ICO_CREADO_POR { get; set; }
        public DateTime ICO_FECHA_CREACION { get; set; }

    }
}
