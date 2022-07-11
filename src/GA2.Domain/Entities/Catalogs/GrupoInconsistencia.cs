using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class GrupoInconsistencia
    {
        public Guid GIN_ID { get; set; }
        public int GIN_GRUPO { get; set; }
        public bool GIN_ESTADO { get; set; }
    }
}
