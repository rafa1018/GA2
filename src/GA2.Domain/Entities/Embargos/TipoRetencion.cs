using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class TipoRetencion
    {
        public Guid TRE_ID { get; set; }
        public string TRE_NOMBRE { get; set; }
        public string TRE_DESCRIPCION { get; set; }
        public bool TRE_ESTADO { get; set; }

    }
}
