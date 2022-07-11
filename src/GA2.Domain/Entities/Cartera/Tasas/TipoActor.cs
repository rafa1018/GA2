using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class TipoActor
    {
        public int TPA_ID { get; set; }
        public string TPA_DESCRIPCION { get; set; }
        public bool TPA_ACTIVO { get; set; }
        public bool TPA_APLICA_CUENTA { get; set; }
        public bool TPA_APLICA_CLIENTE { get; set; }
        public bool TPA_APLICA_BLOQUEO { get; set; }
        public bool TPA_APLICA_USUARIO { get; set; }
        public bool TPA_ORDEN_PAGO { get; set; }
    }
}









