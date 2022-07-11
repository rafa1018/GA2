using System;

namespace GA2.Domain.Entities
{
    public class TipoEmbargos
    {
        public Guid TIE_ID { get; set; }
        public string TIE_NOMBRE { get; set; }
        public string TIE_DESCRIPCION { get; set; }
        public bool TIE_ESTADO { get; set; }

    }
}
