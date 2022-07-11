using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class EntidadSeguroEducativo
    {
        public Guid ESE_ID { get; set; }
        public string ESE_NUMERO_IDENTIFICACION { get; set; }
        public string ESE_NOMBRE_RAZON_SOCIAL { get; set; }
        public int TID_ID_FK { get; set; }
    }
}
