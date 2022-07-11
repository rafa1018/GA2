using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class RespuestaTerceroEntidadSeguroEducativo
    {
        public Guid ESE_ID { get; set; }
        public Guid SOL_ID_FK { get; set; }
        public int? ESE_TIPO_TERCERO_FK { get; set; }
        public int TID_ID_FK { get; set; }
        public string ESE_NUMERO_IDENTIFICACION { get; set; }
        public string ESE_NOMBRE_RAZON_SOCIAL { get; set; }
        public Guid ESE_CREATEDOPOR { get; set; }
        public string TER_NUM_POLIZA { get; set; }
    }
}
