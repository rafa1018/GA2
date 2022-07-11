using System;

namespace GA2.Domain.Entities
{
    public class TemaComite
    {
        public int TCO_ID { get; set; }
        public string TCO_DESCRIPCION { get; set; }
        public int TCO_ESTADO { get; set; }
        public Guid TCO_CREADO_POR { get; set; }
        public DateTime TCO_FECHA_CREACION { get; set; }
    }
}
