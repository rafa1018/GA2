using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class RespuestaTerceroApoderado
    {
        public Guid TER_ID { get; set; }
        public int TID_ID_FK { get; set; }
        public string TID_DESCRIPCION { get; set; }
        public string TER_NUMERO_DOCUMENTO { get; set; }
        public string TER_NOMBRE_RAZON_SOCIAL { get; set; }
        public int CVL_ID { get; set; }
        public string CVL_DESCRIPCION { get; set; }
        public bool TER_ESAUTORIZADO { get; set; }
    }
}
