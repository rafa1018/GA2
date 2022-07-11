using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class CausalEstadoCuenta
    {
        public int CCN_ID { get; set; }
        public int ECT_ID { get; set; }
        public string CCN_DESCRIPCION { get; set; }
        public bool CCN_ACTIVA { get; set; }

    }
}
