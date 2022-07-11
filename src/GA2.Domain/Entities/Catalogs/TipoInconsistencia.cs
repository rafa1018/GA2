using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class TipoInconsistencia
    {
        public int GIN_GRUPO { get; set; }
        public Guid LIN_ID { get; set; }
        public string LIN_DESCRIPCION { get; set; }
    }
}
