using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class CausalBloqueoCuenta
    {
        public Guid CSB_ID { get; set; }
        public string CSB_NOMBRE { get; set; }
        public string CSB_DESCIPCION { get; set; }
        public bool CSB_ESTADO { get; set; }
    }
}
