using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Domain.Entities
{
    public class SolicitudTerceroEntidadSeguroEducativo
    {
        public int TID_ID_FK { get; set; }
        public string TER_NUMERO_DOCUMENTO { get; set; }
        public string TER_NOMBRE_RAZON_SOCIAL { get; set; }
        public int? TER_TIPO_TERCERO_FK { get; set; }
        public Guid SOL_ID_FK { get; set; }
        public Guid TER_CREATEDOPOR { get; set; }
        public Guid ESE_ID_FK { get; set; }
        public string TER_NUM_POLIZA { get; set; }

        // campos adicionales
        public Guid TER_ID { get; set; }
    }
}